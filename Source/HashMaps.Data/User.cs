using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HashMaps.Data
{
    public class User
    {
        public int ID { get; set; }
        public String AuthorizationCode { get; set; }
        public String AuthenticationToken { get; set; }
        public String Name { get; set; }
        public String MugshotUrl { get; set; }
        public String Location { get; set; }
    }
}
