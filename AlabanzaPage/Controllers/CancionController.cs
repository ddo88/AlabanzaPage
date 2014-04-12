using AlabanzaPage.App_Start;
using AlabanzaPage.Models;
using AlabanzaPage.Properties;
using MongoDB.Driver;
using MongoDB.Driver.Builders;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AlabanzaPage.Controllers
{
    public class CancionController : Controller
    {

        public readonly Context context = new Context(); 
        
        //
        // GET: /Canciones/
        public ActionResult Index()
        {
            //var listado=context.GetCollection<Cancion>(Settings.Default.CancionesCollection).FindAll();
            //List<Cancion> listado = context.GetCollection<Cancion>(Settings.Default.CancionesCollection).FindAll().ToList<Cancion>();
            //return View(listado);
            return View();
        }

        [OutputCache(Duration = 60)]
        public ActionResult Listado()
        {
            var listado = context.GetCollection<Cancion>(Settings.Default.CancionesCollection).FindAll();
            return Json(listado, JsonRequestBehavior.AllowGet);
        }

        //
        // GET: /Canciones/Create
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Canciones/Create
        [HttpPost]
        public ActionResult Save()//FormCollection collection
        {
            try
            {
                context.GetCollection<Cancion>(Settings.Default.CancionesCollection).Insert(JsonConvert.DeserializeObject<Cancion>(Request.Form[0]));                
                // TODO: Add insert logic here
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        //
        // GET: /Canciones/Edit/5
        //[HttpPost]
        public ActionResult Edit(string id)
        {
            //var q = JsonConvert.DeserializeObject<Cancion>(Request.Form[0]);
            //context.GetCollection<Cancion>(Settings.Default.CancionesCollection).Update(Query.EQ("_id", id), Update.Replace(JsonConvert.DeserializeObject<Cancion>(Request.Form[0])), UpdateFlags.Upsert)
            var q = context.GetCollection<Cancion>(Settings.Default.CancionesCollection).Find(Query.EQ("_id", id)).First();
            return View(q);
        }
        [HttpPost]
        public ActionResult Edit()
        {
            var q = JsonConvert.DeserializeObject<Cancion>(Request.Form[0]);
            context.GetCollection<Cancion>(Settings.Default.CancionesCollection).Update(Query.EQ("_id", q.Id), Update.Replace(q), UpdateFlags.Upsert);
            return View(q);
        }

        ////
        //// POST: /Canciones/Edit/5

        //[HttpPost]
        //public ActionResult Edit(int id, FormCollection collection)
        //{
        //    try
        //    {
        //        // TODO: Add update logic here
        //        context.GetCollection<Cancion>(Settings.Default.CancionesCollection).Update(Query.EQ("_id", id), Update.Replace(JsonConvert.DeserializeObject<Cancion>(Request.Form[0])), UpdateFlags.Upsert);
        //        return RedirectToAction("Index");
        //    }
        //    catch
        //    {
        //        return View();
        //    }
        //}

        //
        // GET: /Canciones/Delete/5

        public ActionResult Delete(int id)
        {
            return View();
        }

        //
        // POST: /Canciones/Delete/5

        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
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
