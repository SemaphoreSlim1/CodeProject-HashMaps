using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HashMaps.Model.Dto
{
    public  class DtoMessage
    {
        public int ID { get; set; }
        public String PlainBody { get; set; }
        public String WebUrl { get; set; }
        public DtoPerson Composer { get; set; }
    }

    public class DtoPerson
    {
        public int ID { get; set; }
        public String FullName { get; set; }
        public String Location { get; set; }
        public String MugshotUrl { get; set; }
    }
}
