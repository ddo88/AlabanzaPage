using AlabanzaPage.App_Start;
using AlabanzaPage.Models;
using AlabanzaPage.Properties;
using MongoDB.Driver.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AlabanzaPage.Controllers
{
    public class ListaController : Controller
    {

        public readonly Context context = new Context(); 
        //
        // GET: /Lista/
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Ultima()
        {
            var a = context.GetCollection<Lista>(Settings.Default.ListaCollection).FindAll().SetSortOrder(SortBy.Descending("_id"));
            if (a.Count() > 0)
            {
                return Json(a.First(),JsonRequestBehavior.AllowGet);                
            }
            return Json("", JsonRequestBehavior.AllowGet);
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
        public ActionResult Lista()
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
