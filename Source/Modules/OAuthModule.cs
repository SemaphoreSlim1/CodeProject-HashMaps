using HashMaps.Data;
using Newtonsoft.Json;
using System;
using System.Net;
using System.Web;
using System.Linq;
using HashMaps.Model;
using HashMaps.Model.Yammer;
using System.Configuration;

namespace Modules
{
    public class OAuthModule : IHttpModule
    {
        #region IHttpModule Members

        public void Dispose()
        {
            //clean-up code here.
        }

        public void Init(HttpApplication context)
        {
            context.AuthenticateRequest += context_AuthenticateRequest;
        }

        void context_AuthenticateRequest(Object sender, EventArgs e)
        {
            var app = sender as HttpApplication;

            if (app.Context.User != null)
            { return; } //user has alerady been authenticated.

            if (app.Request.Cookies.Keys.Cast<String>().Contains(System.Web.Security.FormsAuthentication.FormsCookieName))
            {
                //the user is re-visiting within the same 'session'.
                //attempt to extract the information from the encrypted ticket
                
                try 
                {
                    var authCookie = app.Request.Cookies[System.Web.Security.FormsAuthentication.FormsCookieName];
                    var ticket = System.Web.Security.FormsAuthentication.Decrypt(authCookie.Value);

                    if(ticket.Expired == false)
                    {
                        var userID = Convert.ToInt32(ticket.Name);
                        var authtoken = ticket.UserData;
                        app.Context.User = new UserPrincipal(new UserIdentity() { AuthToken = authtoken, ID = userID });
                        return;
                    }                    
                }
                catch (Exception ex)
                { }                
            }
            
            //the user has authorized the third party to utilized the app.
            //now attempt to authenticate them.
            if (String.IsNullOrWhiteSpace(app.Request.Params.Get("code")) == false)
            {
                using (var cli = new WebClient())
                {
                    var authorizeCode = app.Request.Params.Get("code");
                    var yammerClientID = ConfigurationManager.AppSettings["YammerClientID"];
                    var yammerClientSecret = ConfigurationManager.AppSettings["YammerClientSecret"];
                    var authenticateUrl = String.Format("https://www.yammer.com/oauth2/access_token.json?client_id={0}&client_secret={1}&code={2}", yammerClientID, yammerClientSecret, authorizeCode);
                    var authenticationResponse = cli.DownloadString(authenticateUrl);
                    var authenticationObject = JsonConvert.DeserializeObject<AuthenticationResult>(authenticationResponse);
                    var authenticationToken = authenticationObject.access_token.token.ToString();
                    using (var db = new HashMapContext())
                    {
                        
                        var user = db.Users.Where(u => u.ID == authenticationObject.user.id).FirstOrDefault();
                        if(user == null)
                        { //this is a brand new user. create them.
                            user = db.Users.Create();
                            user.ID = authenticationObject.user.id;
                            user.Location = authenticationObject.user.location;
                            user.MugshotUrl = authenticationObject.user.mugshot_url;
                            user.Name = authenticationObject.user.full_name;
                            user.AuthorizationCode = authorizeCode;
                            user.AuthenticationToken = authenticationToken;
                            db.Users.Add(user);
                        }
                        else
                        { //we've seen this user before, update their authentication token.
                            user.AuthenticationToken = authenticationToken;
                        }
                        db.SaveChanges();
                    }

                    var expirationDate = DateTime.UtcNow.AddHours(1);
                    var ticket = new System.Web.Security.FormsAuthenticationTicket(1, authenticationObject.user.id.ToString(), DateTime.UtcNow, expirationDate, true, authenticationToken);
                    var cookieString = System.Web.Security.FormsAuthentication.Encrypt(ticket);
                    var authCookie = new HttpCookie(System.Web.Security.FormsAuthentication.FormsCookieName, cookieString);
                    authCookie.Expires = expirationDate;
                    authCookie.Path = System.Web.Security.FormsAuthentication.FormsCookiePath;
                    app.Response.Cookies.Set(authCookie);
                                        
                    app.Context.User = new UserPrincipal(new UserIdentity() { ID = authenticationObject.user.id, AuthToken = authenticationToken });                    
                }
                return;
            }

            
        }

        #endregion
    }
}
