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
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace AlabanzaPage.Controllers
{
    public class ListaController : Controller
    {
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(typeof(ListaController));
        private                 Context      context {get;set;}

        protected override void Initialize(RequestContext requestContext)
        {
            if (context == null)
                context = Context.GetInstance();
            base.Initialize(requestContext);
        }

        //
        // GET: /Lista/
        public ActionResult Index()
        {
            //var a = context.GetCollection<Lista>(Settings.Default.ListaCollection).FindAll().SetSortOrder(SortBy.Descending("Fecha")).First();
            return View();
        }

        public ActionResult Ultima()
        {
            try
            {
                var a = context.GetCollection<Lista>(Settings.Default.ListaCollection).FindAll().SetSortOrder(SortBy.Descending("Fecha")).ToList();
                if (a.Count > 0)
                {
                    return Json(a.First(), JsonRequestBehavior.AllowGet);
                }
            }
            catch (Exception ex)
            {
                log.Error("Ultima Lista", ex);
            }
            return Json("", JsonRequestBehavior.AllowGet);
        }

        //
        // GET: /Lista/Create
        public ActionResult Create()
        {
            return View();
        }

        ////
        //// POST: /Lista/Create
        //[HttpPost]
        //public ActionResult Create(FormCollection collection)
        //{
        //    try
        //    {
        //        // TODO: Add insert logic here
        //        return RedirectToAction("Index");
        //    }
        //    catch(Exception ex)
        //    {
        //        log.Error("Create", ex);
        //        return View();
        //    }
        //}

        //
        // GET: /Lista/Edit/5
        public ActionResult Edit(string id)
        {
            return View();
        }

        ////
        //// POST: /Lista/Edit/5
        //[HttpPost]
        //public ActionResult Edit(int id, FormCollection collection)
        //{
        //    try
        //    {
        //        // TODO: Add update logic here
        //        return RedirectToAction("Index");
        //    }
        //    catch(Exception ex)
        //    {
        //        log.Error("Edit", ex);
        //        return View();
        //    }
        //}

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
            catch(Exception ex)
            {
                log.Error("Suggestions", ex);
                return View();
            }
        }
        
        [HttpPost]
        public ActionResult Save(string dataSave)//FormCollection collection
        {
            try
            {
                Lista q= new Lista();
                if (!String.IsNullOrEmpty(dataSave))
                    q = JsonConvert.DeserializeObject<Lista>(dataSave);
                else
                    q = JsonConvert.DeserializeObject<Lista>(Request.Form[0]);
                //log.Info("data: " + dataSave);
                //log.Info("data: " + Request.Form[0]);
                if (q.Id != null)
                {
                    if (q.Final)//debo actualizar las canciones
                    {
                        Task.Factory.StartNew(() =>
                        {
                            foreach (var a in q.Canciones)
                            {
                                Cancion c = context.GetCollection<Cancion>(Settings.Default.CancionesCollection).Find(Query.EQ("_id", a.Id)).First();
                                c.UltimaVez = DateTime.Now;
                                context.GetCollection<Cancion>(Settings.Default.CancionesCollection).Update(Query.EQ("_id", c.Id), Update.Set("UltimaVez", DateTime.Now));
                                context.RemoveCache(Settings.Default.CancionesCollection);
                            }

                        });
                        q.Sugerencias = new List<Cancion>();
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
                try
                {
                    SendEmail(q);
                }
                catch (Exception ex)
                {
                    log.Error("Error al enviar Correo",ex);
                }

                return Json(new { state = "Ok" }, JsonRequestBehavior.AllowGet);
            }
            catch(Exception ex)
            {
                log.Error("Save", ex);
                return Json(new { state = "Error" }, JsonRequestBehavior.AllowGet);
            }
        }


        public ActionResult Presentation(string id)
        {

            try {
                var a = context.GetCollection<Lista>(Settings.Default.ListaCollection).Find(Query.EQ("_id", id)).ToList();
                StringBuilder sb = new StringBuilder();
                if (a.Count > 0)
                {
                    Lista l= a.First();
                    for (int i = 0; i < l.Canciones.Count;i++ )
                    {
                        l.Canciones[i] = context.GetCollection<Cancion>(Settings.Default.CancionesCollection).Find(Query.EQ("_id", l.Canciones[i].Id)).First();
                        l.Canciones[i].Letra = Chord.GetChords(l.Canciones[i].Letra);
                    }
                    //como voy a mostrar las canciones??
                    return View(l);
                }
                
            }
            catch (Exception ex)
            { 
            }
            return View();
        }


        public bool SendEmail(Lista l)
        {
            MailClass mc = new MailClass("alabanza.iglesiapagiel@hotmail.com", "@@gato01");
            mc.Send(String.Join(",",context.GetCollection<Usuario>(Settings.Default.UsuariosCollection).FindAll().ToList().Select(x => x.Id).ToArray()), l, "http://alabanza.iglesiapagiel.com/Lista/Index");
            return true;
        }
    }
}
