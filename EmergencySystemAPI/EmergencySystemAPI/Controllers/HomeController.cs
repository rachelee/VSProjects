using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using EmergencySystemAPI.DAL;



namespace EmergencySystemAPI.Controllers
{
    public class HomeController : Controller
    {
        private EmergencyContext db = new EmergencyContext();
        public ActionResult Index()
        {
            ViewBag.Title = "Home Page";

            return View();
        }

    }
}