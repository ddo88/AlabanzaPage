using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace MvcApplication2.Controllers
{
    public class ValidateSecurity : ActionMethodSelectorAttribute
    {

        List<string> PermisosRol = null;
        public override bool IsValidForRequest(ControllerContext controllerContext, System.Reflection.MethodInfo methodInfo)
        {

            string Accion = methodInfo.Name;
            string Modulo = methodInfo.ReflectedType.Name.Replace("Controller", "");

            //HttpContext.Application["PermisosRoles"]
            //string t = ((FormsIdentity) controllerContext.HttpContext.User.Identity).Ticket.UserData;
            HttpCookie authenticationCookie = controllerContext.HttpContext.Request.Cookies[FormsAuthentication.FormsCookieName];

            if (authenticationCookie != null)
            {
                FormsAuthenticationTicket authenticationTicket = FormsAuthentication.Decrypt(authenticationCookie.Value);
                if (!authenticationTicket.Expired)
                {
                    if (controllerContext.HttpContext.Session["UniqueUserId"] == null)
                    {
                        //This means for some reason the session expired before the authentication ticket. Force a login.
                        FormsAuthentication.SignOut();
                        return false;
                    }
                    else
                    {
                        string[] b = authenticationTicket.UserData.Split(',');
                        List<string> list = controllerContext.HttpContext.Application["Roles"] as List<string>;
                        if (list != null)
                            return ValidarPermisos(list, Accion, Modulo);
                        else
                            return false;
                    }
                }
                else
                    return false;
            }
            else
                return false;
        }

        private bool ValidarPermisos(List<string> list, string Accion, string Modulo)
        {

            //Root to do   guardar borrar editar crear
            //publicator public listados, añade crea o edita
            //Miembro sugerencias

            if (list.Contains(("Root").ToLower()))
                return true;

            if (list.Contains(("Publicador").ToLower()))
                return true;

            if (list.Contains(("Miembro").ToLower()))
                return true;


            return false;
        }
    }
}