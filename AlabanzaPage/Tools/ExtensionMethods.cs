using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Html;
using System.Web.Security;


namespace AlabanzaPage.Tools
{
    public static class ExtensionMethods
    {
        public static MvcHtmlString ValidatedElement(this HtmlHelper helper, HttpRequestBase request, string htmltext)
        {
            if (request.GetRole() == "Root" || request.GetRole() == "Administrador")                
                return new MvcHtmlString(String.Format("{0}", htmltext));

            return new MvcHtmlString(String.Empty);
        }
        public static MvcHtmlString ValidatedListActionList(this HtmlHelper helper, HttpRequestBase request, string text,string action,string controller)
        {
            if(request.GetRole() == "Root" || request.GetRole() == "Administrador")                
                return new MvcHtmlString("<li>" + helper.ActionLink(text, action, controller).ToHtmlString() + "</li>");

            return new MvcHtmlString(String.Empty);
        }


        public static string GetMD5(this string value)
        {

            value = value + "salt";
            MD5 md = MD5.Create();
            StringBuilder sBuilder = new StringBuilder();
            byte[] data = md.ComputeHash(System.Text.Encoding.ASCII.GetBytes(value));
            // Loop through each byte of the hashed data 
            // and format each one as a hexadecimal string.
            for (int i = 0; i < data.Length; i++)
            {
                sBuilder.Append(data[i].ToString("x2"));
            }
            return sBuilder.ToString();

        }

        public static string GetRole(this HttpRequestBase request)
        {
            HttpCookie authCookie = request.Cookies[FormsAuthentication.FormsCookieName];
            string data="";
            if (authCookie != null)
            {
                FormsAuthenticationTicket authTicket = FormsAuthentication.Decrypt(authCookie.Value);
                data = authTicket.UserData;
            }
            return data;
        }
    }
}