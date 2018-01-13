using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using DRS.DataBase;

namespace DRS.Controllers
{
    public class HomeController : Controller
    {
        private DRSEntities db;

        public HomeController()
        {
            db = new DRSEntities();
        }

        [AllowAnonymous]
        public ActionResult Index()
        {
            return View();
        }

        [AllowAnonymous]
        public ActionResult About()
        {
            ViewBag.Message = "Distress Report System.";

            return View();
        }

        [AllowAnonymous]
        public ActionResult Contact()
        {
            ViewBag.Message = "Distress Report System.";

            return View();
        }

        [AllowAnonymous]
        public ActionResult Error(string error)
        {
            ViewBag.error = error;
            return View();
        }
    }
}