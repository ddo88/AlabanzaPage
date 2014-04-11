using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AlabanzaPage.Controllers
{
    public class ListaController : Controller
    {
        //
        // GET: /Lista/

        public ActionResult Index()
        {
            return View();
        }

        //
        // GET: /Lista/Create
        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Lista/Create

        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        //
        // GET: /Lista/Edit/5

        public ActionResult Edit(int id)
        {
            return View();
        }

        //
        // POST: /Lista/Edit/5

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

        //
        // GET: /Lista/Delete/5
        public ActionResult Suggestions()
        {
            return View();
        }

        //
        // POST: /Lista/Delete/5

        [HttpPost]
        public ActionResult Suggestions(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
