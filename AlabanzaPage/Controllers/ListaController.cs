using AlabanzaPage.App_Start;
using AlabanzaPage.Models;
using AlabanzaPage.Properties;
using MongoDB.Driver;
using MongoDB.Driver.Builders;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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
            //var a = context.GetCollection<Lista>(Settings.Default.ListaCollection).FindAll().SetSortOrder(SortBy.Descending("Fecha")).First();
            return View();
        }

        public ActionResult Ultima()
        {
            var a = context.GetCollection<Lista>(Settings.Default.ListaCollection).FindAll().SetSortOrder(SortBy.Descending("Fecha")).ToList();
            if(a.Count>0)                
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
        public ActionResult Edit(string id)
        {
            //var query = context.GetCollection<Lista>(Settings.Default.ListaCollection).Find(Query.EQ("_id",id)).ToList();
            //if (query.Count > 0)
            //    return View(query.First());
            //else
            //    return RedirectToAction("Index");
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


        [HttpPost]
        public ActionResult Save()//FormCollection collection
        {
            try
            {
                var q       = JsonConvert.DeserializeObject<Lista>(Request.Form[0]);
                if (q.Id != null)
                {
                    if (q.Final)//debo actualizar las canciones
                    {
                        Task.Factory.StartNew(() => {
                            foreach (var a in q.Canciones)
                            {
                                Cancion c = context.GetCollection<Cancion>(Settings.Default.CancionesCollection).Find(Query.EQ("_id", a.Id)).First();
                                c.UltimaVez = DateTime.Now;
                                context.GetCollection<Cancion>(Settings.Default.CancionesCollection).Update(Query.EQ("_id", c.Id), Update.Set("UltimaVez",DateTime.Now));
                                context.RemoveCache(Settings.Default.CancionesCollection);
                            }
                        });                        
                    }
                    context.GetCollection<Lista>(Settings.Default.ListaCollection).Update(Query.EQ("_id", q.Id), Update.Replace(q), UpdateFlags.Upsert);  
                }
                else
                {
                    q.IdUsuario = User.Identity.Name;
                    q.Fecha = DateTime.Now;
                    q.Final = false;
                    context.GetCollection<Lista>(Settings.Default.ListaCollection).Insert(q);
                }
                context.RemoveCache(Settings.Default.ListaCollection);

                context.RemoveCache(Settings.Default.ListaCollection);
                return Json("{state:ok}", JsonRequestBehavior.AllowGet);
                //return RedirectToAction("Index");
            }
            catch
            {
                return Json("{state:false}", JsonRequestBehavior.AllowGet);
                //return View();
            }
        }
    }
}
