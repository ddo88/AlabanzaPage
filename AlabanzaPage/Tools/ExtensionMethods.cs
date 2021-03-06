﻿using System;
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

        public static MvcHtmlString ValidatedActionLink(this HtmlHelper helper, HttpRequestBase request, string text, string action, string controller)
        {
            if (request.GetRole() == "Root" || request.GetRole() == "Administrador")
                return new MvcHtmlString(helper.ActionLink(text, action, controller).ToHtmlString());

            return new MvcHtmlString(String.Empty);
        }
        public static MvcHtmlString ValidatedActionLink(this HtmlHelper helper, HttpRequestBase request, string text, string action, string controller,object htmlAttributes)
        {
            if (request.GetRole() == "Root" || request.GetRole() == "Administrador")
                return new MvcHtmlString(helper.ActionLink(text, action, controller,htmlAttributes).ToHtmlString());

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


    /*
     *  public class MailCls
    {
        private readonly string _acount;
        private readonly string _pass;

        public MailCls(string acount, string pass)
        {
            _acount = acount;
            _pass = pass;
        }

        public bool Send(string destinatarios,Lista l,string url)
        {
            SmtpClient client = new SmtpClient();
            client.Port = 587;
            client.Host = "smtp.live.com";
            client.EnableSsl = true;
            client.Timeout = 10000;
            client.DeliveryMethod = SmtpDeliveryMethod.Network;
            client.UseDefaultCredentials = false;
            client.Credentials = new System.Net.NetworkCredential(_acount,_pass);

            MailMessage mm  = new MailMessage(_acount, destinatarios);
            mm.BodyEncoding = UTF8Encoding.UTF8;
            mm.IsBodyHtml   = true;
            mm.DeliveryNotificationOptions = DeliveryNotificationOptions.OnFailure;
            mm.Subject = String.Format("Listado Cancion Domingo ,{0}.", l.Fecha.ToString("yyyy-MM-dd"));
            mm.Body = GetBody(l,url);

            client.Send(mm);
            return true;
        }

        private string GetBody(Lista l,string url)
        {
            StringBuilder sb = new StringBuilder();
            int i = 0;
            sb.Append(String.Format("<b>Listado Para el Domingo {0}</b></br>",l.Fecha.ToString("yyyy-MM-dd")));
            sb.Append("<hr/></br>");
            sb.Append("<ol>");
            foreach (var a in l.Canciones)
            {
                sb.Append(String.Format("<li>{0}-{1}</li>", a.Tipo, a.Nombre));
            }
            sb.Append("</ol>");
            //            sb.Append("<hr/></br>");
            sb.Append("<b>Ver Pagina</b></br>");
            sb.Append(string.Format("<a HREF='{0}'>Listado</a>",url));
            return sb.ToString();
        }

        //public bool Send()
        //{
        //    MailMessage mail  = new MailMessage("ddo88@hotmail.com", "ddo88@outlook.com");
        //    SmtpClient client = new SmtpClient();
        //    client.Port = 465;
        //    client.DeliveryMethod = SmtpDeliveryMethod.Network;
        //    //client.UseDefaultCredentials = false;
        //    client.Credentials = new NetworkCredential("ddo88@hotmail.com", "@@hellsing01");
        //    client.Host = "smtp.live.com";
        //    mail.Subject = String.Format("Listado Cancion Domingo ,{0}.", l.Fecha.ToString("yyyy-MM-dd"));
            
        //    mail.Body = sb.ToString();
        //    client.Send(mail);
        //}
    }

    
     */
}