using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index(FormCollection form)
        {
            //checking whether admin logged IN or not
            string uname = form["uid"];
            string password = form["pass"];

            if (uname == "admin" && password == "admin")
            {
                return Redirect("ItemList/Index");
            }
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
    }
}