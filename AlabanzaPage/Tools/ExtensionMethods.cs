using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Html;


namespace AlabanzaPage.Tools
{
    public static class ExtensionMethods
    {
        public static MvcHtmlString ValidatedElement(this HtmlHelper helper, HttpRequestBase request, string htmltext)
        {
            if (request.Cookies["Role"] != null && ("Root" == request.Cookies["Role"].Value || "Administrador" == request.Cookies["Role"].Value))
                return new MvcHtmlString(String.Format("{0}", htmltext));

            
            helper.Label("");
            return new MvcHtmlString(String.Empty);
        }
        public static MvcHtmlString ValidatedListActionList(this HtmlHelper helper, HttpRequestBase request, string text,string action,string controller)
        {
            if (request.Cookies["Role"] != null && ("Root" == request.Cookies["Role"].Value || "Administrador" == request.Cookies["Role"].Value))
                return new MvcHtmlString("<li>" + helper.ActionLink(text, action, controller).ToHtmlString() + "</li>");

            return new MvcHtmlString(String.Empty);
        }
    }
}