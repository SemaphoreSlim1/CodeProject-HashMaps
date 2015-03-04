using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace HashMaps.Model
{
    public class UserPrincipal : IPrincipal
    {
        public UserPrincipal(UserIdentity identity)
        {
            this.Identity = identity;
        }

        public UserIdentity Identity { get; set; }

        IIdentity IPrincipal.Identity { get { return Identity; } }

        public bool IsInRole(string role)
        {
            return true;
        }
    }

    public class UserIdentity : IIdentity
    {
        public String AuthToken { get; set; }
        public int ID { get; set; }

        public string AuthenticationType
        {
            get { return "OAuth"; }
        }

        public bool IsAuthenticated
        {
            get { return true; }
        }

        public string Name { get; set; }
    }
}
