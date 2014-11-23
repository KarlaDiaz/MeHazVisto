using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MeHazVisto.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.Message = "¿Me Haz Visto?.";

            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "¿Me Haz Visto?.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "¿Me Haz Visto?.";

            return View();
        }
    }
}
