using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using HashMaps.Model;
using Newtonsoft.Json;
using System.Threading.Tasks;
using HashMaps.Data;
using HashMaps.Model.Yammer;

namespace HashMaps.Controllers
{
    public class YammerUpdatesController : ApiController
    {
        [Authorize]
        public IEnumerable<HashMaps.Model.Dto.DtoMessage> Get()
        {
            var user = this.User as UserPrincipal;
            String searchResults = null;
            var authToken = user.Identity.AuthToken;

            using (var cli = new WebClient())
            {
                cli.Headers.Add("Authorization", "Bearer " + authToken);
                cli.QueryString.Add("search", "AvaTS14");
                try
                {
                    searchResults = cli.DownloadString("https://www.yammer.com/api/v1/search.json");
                }
                catch (Exception ex)
                {
                    return new List<HashMaps.Model.Dto.DtoMessage>();
                }//TODO: add logging. we might have gotten rate limited by the api
            }

            var feed = JsonConvert.DeserializeObject<RootObject>(searchResults);
            var dtos = new List<HashMaps.Model.Dto.DtoMessage>();


            foreach (var msg in feed.messages.messages)
            {
                try
                {
                    var dto = new HashMaps.Model.Dto.DtoMessage();
                    dto.ID = msg.id;
                    dto.PlainBody = msg.body.plain;
                    dto.WebUrl = msg.web_url;
                    dto.Composer = new HashMaps.Model.Dto.DtoPerson() { ID = msg.sender_id };
                    dtos.Add(dto);
                }
                catch (Exception ex)
                { } //add logging later
            }


            var distinctSenderIDs = feed.messages.messages.Select(m => m.sender_id).Distinct();
            var distinctSenders = new List<Model.Dto.DtoPerson>();
            using (var db = new HashMapContext())
            {
                foreach (var senderID in distinctSenderIDs)
                {
                    //first look in the database to see if we know about this person
                    var dbSender = db.Users.Where(u => u.ID == senderID).FirstOrDefault();
                    if (dbSender != null)
                    {
                        //jackpot, now copy it over
                        var sender = new Model.Dto.DtoPerson();
                        sender.FullName = dbSender.Name;
                        sender.ID = dbSender.ID;
                        sender.Location = dbSender.Location;
                        sender.MugshotUrl = dbSender.MugshotUrl;
                        distinctSenders.Add(sender);
                        continue;
                    }

                    using (var cli = new WebClient())
                    {
                        cli.Headers.Add("Authorization", "Bearer " + authToken);
                        try
                        {
                            var userJson = cli.DownloadString("https://www.yammer.com/api/v1/users/" + senderID.ToString() + ".json");
                            var parsedUser = JsonConvert.DeserializeObject<Person>(userJson);
                            var sender = new Model.Dto.DtoPerson();
                            sender.FullName = parsedUser.full_name;
                            sender.ID = parsedUser.id;
                            sender.Location = parsedUser.location;
                            sender.MugshotUrl = parsedUser.mugshot_url;
                            distinctSenders.Add(sender);
                        }
                        catch (Exception ex)
                        { continue; } //add logging later
                    }
                }
            }

            foreach (var dto in dtos)
            {
                //find the composer
                var composer = distinctSenders.Where(s => s.ID == dto.Composer.ID).FirstOrDefault();
                if (composer != null)
                {
                    dto.Composer = composer;
                }
            }

            //only return yams that have location. We don't want to push out stuff we can't see.
            return dtos.Where(dto => String.IsNullOrWhiteSpace(dto.Composer.Location) == false);
        }
    }
}
