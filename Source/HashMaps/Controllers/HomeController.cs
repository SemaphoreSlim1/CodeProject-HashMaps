using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Newtonsoft.Json;

namespace HashMaps.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            return View();
        }

        public class DisplayModel {
            public String AccessToken { get; set; }
        }

        [Authorize]
        public ActionResult Display()
        {
            

            //using(var cli = new WebClient())
            //{
            //    cli.Headers.Add("Authorization", "Bearer " + authenticationToken);
            //    var response = cli.DownloadString("https://www.yammer.com/api/v1/users.json");
            //    var users = JsonConvert.DeserializeObject(response);
            //    var i = 0;
            //}

            //return View(new DisplayModel() { AccessToken = authenticationToken });
            return View();
        }
    }
}