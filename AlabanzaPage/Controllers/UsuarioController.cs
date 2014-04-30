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
    public class UsuarioController : Controller
    {
        //
        // GET: /Usuario/
        public readonly Context context = new Context();

        public ActionResult Index()
        {
            var listado = context.GetCollection<Usuario>(Settings.Default.UsuariosCollection).FindAll();
            return View(listado);
        }

        //
        // GET: /Usuario/Details/5

        //public ActionResult Details(int id)
        //{
        //    return View();
        //}

        //
        // GET: /Usuario/Create

        public ActionResult Create()
        {
            ViewBag.ListRoles = getRoles();
            return View();
        }

        //
        // POST: /Usuario/Create

        [HttpPost]
        public ActionResult Create(Usuario collection)
        {
            try
            {
                // TODO: Add insert logic here
                context.GetCollection<Usuario>(Settings.Default.UsuariosCollection).Save(collection);
                context.RemoveCache(Settings.Default.UsuariosCollection);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        //
        // GET: /Usuario/Edit/5
        public ActionResult Edit(string id)
        {
            ViewBag.ListRoles = getRoles();
            var user=context.GetCollection<Usuario>(Settings.Default.UsuariosCollection).Find(Query.EQ("_id",id));
            return View(user.First());
        }

        private List<SelectListItem> getRoles()
        { 
            List<SelectListItem> list= new List<SelectListItem>();
            foreach(var a in Settings.Default.Roles)
            {
                SelectListItem sli= new SelectListItem();
                sli.Text  = a;
                sli.Value = a;
                list.Add(sli);
            }
        return list;
        }

        //
        // POST: /Usuario/Edit/5

        [HttpPost]
        public ActionResult Edit(string id, Usuario collection)
        {
            try
            {
                // TODO: Add update logic here

                context.GetCollection<Usuario>(Settings.Default.UsuariosCollection).Update(Query.EQ("_id", id), Update.Set("Role", collection.Role).Set("User", collection.User));
                context.RemoveCache(Settings.Default.UsuariosCollection);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        //
        // GET: /Usuario/Delete/5

        public ActionResult Delete(int id)
        {
            return View();
        }

        //
        // POST: /Usuario/Delete/5

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
