using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcApplication1.Models;

namespace MvcApplication1.Controllers
{
    public class AppController : BaseController
    {
        //
        // GET: /App/

        public ActionResult Index()
        {

            return View(new ViewModel());
        }

        //
        // GET: /App/Details/5

        public ActionResult Details(int id)
        {
            return View();
        }

   
        //
        // GET: /App/Edit/5

        public ActionResult Edit(int id)
        {
            return View();
        }

        //
        // POST: /App/Edit/5

        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

    }
}
