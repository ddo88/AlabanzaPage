using AlabanzaPage.Properties;
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

            string Accion = methodInfo.Name;
            string Modulo = methodInfo.ReflectedType.Name.Replace("Controller", "");
            bool   sw     = false;
            
            string roles = context.HttpContext.Request.GetRole();
            //falta ver como se maneja esta parte
            switch (roles)
            {
                case "Root": sw = true; break;
                case "Administrador": sw = true; break;
                default: break;
            }
            return sw;
        }
    }
}