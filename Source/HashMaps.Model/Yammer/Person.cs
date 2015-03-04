using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HashMaps.Model.Yammer
{
    public class Im
    {
        public string provider { get; set; }
        public string username { get; set; }
    }

    public class PhoneNumber
    {
        public string type { get; set; }
        public string number { get; set; }
    }

    public class EmailAddress
    {
        public string type { get; set; }
        public string address { get; set; }
    }

    public class Contact
    {
        public Im im { get; set; }
        public List<PhoneNumber> phone_numbers { get; set; }
        public List<EmailAddress> email_addresses { get; set; }
        public bool has_fake_email { get; set; }
    }

    public class Settings
    {
        public string xdr_proxy { get; set; }
    }

    public class Person
    {
        public string type { get; set; }
        public int id { get; set; }
        public int network_id { get; set; }
        public string state { get; set; }
        public string guid { get; set; }
        public string job_title { get; set; }
        public string location { get; set; }
        public string significant_other { get; set; }
        public string kids_names { get; set; }
        public object interests { get; set; }
        public string summary { get; set; }
        public object expertise { get; set; }
        public string full_name { get; set; }
        public string activated_at { get; set; }
        public bool show_ask_for_photo { get; set; }
        public string first_name { get; set; }
        public string last_name { get; set; }
        public string network_name { get; set; }
        public List<string> network_domains { get; set; }
        public string url { get; set; }
        public string web_url { get; set; }
        public string name { get; set; }
        public string mugshot_url { get; set; }
        public string mugshot_url_template { get; set; }
        public object hire_date { get; set; }
        public string birth_date { get; set; }
        public string timezone { get; set; }
        public List<object> external_urls { get; set; }
        public string admin { get; set; }
        public string verified_admin { get; set; }
        public string can_broadcast { get; set; }
        public string department { get; set; }
        public List<object> previous_companies { get; set; }
        public List<object> schools { get; set; }
        public Contact contact { get; set; }
        public Stats stats { get; set; }
        public Settings settings { get; set; }
    }
}
