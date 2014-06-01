using AlabanzaPage.App_Start;
using AlabanzaPage.Models;
using AlabanzaPage.Properties;
using AlabanzaPage.Tools;
using MongoDB.Driver;
using MongoDB.Driver.Builders;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Caching;
using System.Web.Mvc;

using PagedList; 

namespace AlabanzaPage.Controllers
{
    public class CancionController : Controller
    {
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(typeof(CancionController));
        public readonly Context context = Context.GetInstance();

        public ActionResult Index(string sortOrder, string currentFilter, string searchString, int? page)
        {
            ViewBag.CurrentSort = sortOrder;
            ViewBag.NameSortParm = String.IsNullOrEmpty(sortOrder) ? "name_desc" : "";
            ViewBag.DateSortParm = sortOrder == "Date" ? "date_desc" : "Date";

            if (searchString != null)
                page = 1;
            else
                searchString = currentFilter;


            ViewBag.CurrentFilter = searchString;

            var listado = context.GetCollection<Cancion>(Settings.Default.CancionesCollection).FindAll().ToList();

            if (!String.IsNullOrEmpty(searchString))
            {
                listado = listado.Where<Cancion>(s => s.Nombre.ToUpper().Contains(searchString.ToUpper())).ToList();
            }
            switch (sortOrder)
            {
                case "name_desc":
                    listado = listado.OrderByDescending(a => a.Nombre).ToList();
                    break;
                case "Date":
                    listado = listado.OrderBy(a => a.UltimaVez).ToList();
                    break;
                case "date_desc":
                    listado = listado.OrderByDescending(a => a.UltimaVez).ToList();
                    break;
                default:  // Name ascending  
                    listado = listado.OrderBy(a => a.Nombre).ToList();
                    break;
            }

            int pageSize = 50;
            int pageNumber = (page ?? 1);
            return View(listado.ToPagedList(pageNumber, pageSize)); 
            ///
            //return View(listado);
        }
        //
        // GET: /Canciones/
        public ActionResult Index2()
        {
            return View();
        }

        [OutputCache(Duration = 60)]
        public ActionResult Listado()
        {
            var listado = context.GetCollection<Cancion>(Settings.Default.CancionesCollection).FindAll().ToList();
            listado = listado.OrderBy(x => x.Nombre).ToList();
            return Json(listado, JsonRequestBehavior.AllowGet);
        }

        public ActionResult VerLetra  (string id)
        {
            var query = context.GetCollection<Cancion>(Settings.Default.CancionesCollection).Find(Query.EQ("_id",id));
            Cancion c = query.First();
            c.Letra=Chord.GetLyrics(c.Letra);
            return View(c);
        }
        public ActionResult VerAcordes(string id)
        {
            var query = context.GetCollection<Cancion>(Settings.Default.CancionesCollection).Find(Query.EQ("_id", id));
            Cancion c = query.First();
            c.Letra = Chord.GetChords(c.Letra);
            return View(c);
        }

        //
        // GET: /Canciones/Create
        [HttpGet]
        [ValidateSecurity]
        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Canciones/Create
        [HttpPost]
        public ActionResult Save(string dataSave)
        {
            try
            {
                Cancion c = new Cancion();
                if (!String.IsNullOrEmpty(dataSave))
                    c = JsonConvert.DeserializeObject<Cancion>(dataSave);
                else
                    c = JsonConvert.DeserializeObject<Cancion>(Request.Form[0]);
                context.GetCollection<Cancion>(Settings.Default.CancionesCollection).Insert(c);                
                return RedirectToAction("Index");
            }
            catch(Exception ex)
            {
                log.Error("Save", ex);
                return View();
            }
        }

        //
        // GET: /Canciones/Edit/5
        //[HttpPost]
        [HttpGet]
        [ValidateSecurity]
        public ActionResult Edit(string id)
        {
            try
            {
                var q = context.GetCollection<Cancion>(Settings.Default.CancionesCollection).Find(Query.EQ("_id", id)).First();
                return View(q);
            }
            catch (Exception ex) {
                log.Error("Edit", ex);
                return RedirectToAction("Index");
            }
            
        }

        [HttpPost]
        public ActionResult SaveEdit(string dataEdit)
        {
            try {

                Cancion q = new Cancion();
                if (!String.IsNullOrEmpty(dataEdit))
                    q = JsonConvert.DeserializeObject<Cancion>(dataEdit);
                else
                    q = JsonConvert.DeserializeObject<Cancion>(Request.Form[0]);
                log.Info(dataEdit);
                log.Info(Request.Form[0]);

                context.GetCollection<Cancion>(Settings.Default.CancionesCollection).Update(Query.EQ("_id", q.Id), Update.Replace(q), UpdateFlags.Upsert);
                context.RemoveCache(Settings.Default.CancionesCollection);
                return Json("{State:'OK'}", JsonRequestBehavior.AllowGet);            
            }
            catch (Exception ex) {
                return Json("{State:'ERROR'}", JsonRequestBehavior.AllowGet);            
            }
            
        }

    }
}
