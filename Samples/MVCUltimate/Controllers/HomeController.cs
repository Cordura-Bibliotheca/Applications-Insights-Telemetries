using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCUltimate.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
        public int GetData(int number)
        {
            return number;
        }

        [HttpPost]
        public string  PostData(ModelClass myModel)
        {

            return myModel.name;
        }
    }

    public class ModelClass
    {
        public string name { get; set; }
        public int age { get; set; }


    }
}