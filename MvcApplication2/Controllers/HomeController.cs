using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcApplication2.Models;

namespace MvcApplication2.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.Message = "Listado Cnaciones!";

            return View(new ViewModel());
        }

        public ActionResult Model()
        {
            return Json(new ViewModel(true),JsonRequestBehavior.AllowGet);
        }
    }
}
