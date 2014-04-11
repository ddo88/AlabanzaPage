using System;
using System.Collections.Generic;
using System.Web.Mvc;
using MvcApplication2.Models;
using Newtonsoft.Json;

namespace MvcApplication2.Controllers
{
    public class HomeController : Controller
    {
        [ValidateSecurity]
        public ActionResult Index(string id)
        {
            ViewBag.WithId = false;
            if (id != null)
            {
                ViewBag.ListId = id;
                ViewBag.WithId = true;
            }
                
            ViewBag.Message = "Listado Canciones!";

            return View(new ViewModel());
        }
        
        public ActionResult Model()
        {
            return Json(new ViewModel(true),JsonRequestBehavior.AllowGet);
        }

        public ActionResult List(string id)
        {
            Lista l = new Db().GetListado(id);
            return Json(new ViewModel(l), JsonRequestBehavior.AllowGet);
        }

        //public ActionResult List(string id)
        //{
        //    Lista l = new Db().GetListado(id);
        //    return Json(new ViewModel(l), JsonRequestBehavior.AllowGet);
        //}

        [HttpPost]
        [ValidateSecurity]
        public ActionResult SaveModel()
        {
            int i = 0;
            try
            {
                Db db= new Db();
                string _url=Request.Url.AbsoluteUri.Replace("SaveModel/", "");
                if (db.SaveListado(JsonConvert.DeserializeObject<List<Cancion>>(Request.Form[0]), "ddo88@hotmail.com",_url))
                {
                    var result = new { Success = "True", Message = "Se ha guardado y enviado correctamente la información." };
                    return Json(result);
                }
                else
                {
                    var result = new { Success = "False", Message = "No se pudo guardar la lista." };
                    return Json(result);
                }
            }catch(Exception ex){}

    return Json("Ok");
        }
    }
}
