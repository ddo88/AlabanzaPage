using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;
using System.Web.Script.Serialization;
using MvcApplication2.Models;
using Newtonsoft.Json;

namespace MvcApplication2.Controllers
{
    public class HomeController : Controller
    {
//        [ValidateSecurity]
        public ActionResult Index()
        {
            ViewBag.Message = "Listado Cnaciones!";

            return View(new ViewModel());
        }

        public ActionResult Model()
        {
            return Json(new ViewModel(true),JsonRequestBehavior.AllowGet);
        }

        public ActionResult List(string id)
        {
            Db db= new Db();
            Lista l =db.GetListado(id);
            return Json("{p:otra}", JsonRequestBehavior.AllowGet);
        }

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
