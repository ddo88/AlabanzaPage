﻿using AlabanzaPage.App_Start;
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
            return Json("{State:'OK'}", JsonRequestBehavior.AllowGet);            
        }

    }
}
