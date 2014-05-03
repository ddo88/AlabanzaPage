using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace AlabanzaPage.Tools
{
    public class ValidateSecurity:ActionMethodSelectorAttribute
    {
        public override bool IsValidForRequest(ControllerContext context, System.Reflection.MethodInfo methodInfo)
        {

            HttpCookie authCookie = context.HttpContext.Request.Cookies[FormsAuthentication.FormsCookieName];
            bool sw = false;
            if (authCookie != null)
            {
                FormsAuthenticationTicket authTicket = FormsAuthentication.Decrypt(authCookie.Value);
                string roles = authTicket.UserData;
                if (roles=="Root" || roles=="Administrator") 
                        sw = true;
            }
            //string Accion = methodInfo.Name;
            //string Modulo = methodInfo.ReflectedType.Name.Replace("Controller", "");
            //bool sw = false;
            return sw;
        }
    }

    //public class ValidateSecurity : ActionMethodSelectorAttribute
    //{

    //    List<ConfPermisoRol> PermisosRol = null;
    //    public override bool IsValidForRequest(ControllerContext controllerContext, System.Reflection.MethodInfo methodInfo)
    //    {

    //        string Accion = methodInfo.Name;
    //        string Modulo = methodInfo.ReflectedType.Name.Replace("Controller", "");

    //        //HttpContext.Application["PermisosRoles"]
    //        //string t = ((FormsIdentity) controllerContext.HttpContext.User.Identity).Ticket.UserData;
    //        HttpCookie authenticationCookie = controllerContext.HttpContext.Request.Cookies[FormsAuthentication.FormsCookieName];

    //        if (authenticationCookie != null)
    //        {
    //            FormsAuthenticationTicket authenticationTicket = FormsAuthentication.Decrypt(authenticationCookie.Value);
    //            if (!authenticationTicket.Expired)
    //            {
    //                if (controllerContext.HttpContext.Session["UniqueUserId"] == null)
    //                {
    //                    //This means for some reason the session expired before the authentication ticket. Force a login.
    //                    FormsAuthentication.SignOut();
    //                    return false;
    //                }
    //                else
    //                {
    //                    string[] b = authenticationTicket.UserData.Split(',');
    //                    List<ConfPermisoRol> list = controllerContext.HttpContext.Application["PermisosRoles"] as List<ConfPermisoRol>;
    //                    if (list != null)
    //                        return ValidarPermisos(list.Where(c => c.Rol.Id == Convert.ToInt32(b[1])).ToList(), Accion, Modulo);
    //                    else
    //                        return false;
    //                }
    //            }
    //            else
    //                return false;
    //        }
    //        else
    //            return false;
    //        //ConfPersonaRol user = HttpContext.Current.Application["usuario"] as ConfPersonaRol;
    //        //    if (user != null)
    //        //    {
    //        //        if (user.Usuario.IsActivo)
    //        //            return true;
    //        //            //return ValidarPermisos(HttpContext.Current.Application["permisos"] as List<ConfPermisoRol>,Accion,Modulo);
    //        //        else
    //        //            return false;
    //        //    }
    //        //    else
    //        //        throw new HttpException(401, "El usuario no se ha logueado");            
    //    }

    //    private bool ValidarPermisos(List<ConfPermisoRol> list, string Accion, string Modulo)
    //    {
    //        string m, n;
    //        if (Accion == "Registradora")
    //        {
    //            m = new AppControl().GetModulo(Modulo + "-" + Accion);
    //            n = new AppControl().GetPermiso(Accion);
    //        }
    //        else
    //        {
    //            m = new AppControl().GetModulo(Modulo);
    //            n = new AppControl().GetPermiso(Accion);
    //        }
    //        if (m.Equals("All"))
    //            return true;
    //        else
    //        {
    //            var q = list.Where(c => c.Modulo.Modulo.Contains(m)).ToList();
    //            if (q.Count > 0)
    //            {
    //                ConfPermisoRol p = q.First();
    //                if (n == "R")
    //                    return p.R;
    //                else
    //                    return p.W;
    //            }
    //            else
    //                return false;
    //        }
    //    }
    //}
}