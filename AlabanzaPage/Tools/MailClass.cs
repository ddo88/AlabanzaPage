using AlabanzaPage.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Web;

namespace AlabanzaPage.Tools
{
    public class MailClass
    {
        private readonly string _acount;
        private readonly string _pass;

        public MailClass(string acount, string pass)
        {
            _acount = acount;
            _pass = pass;
        }

        public bool Send(string destinatarios,Lista l,string url)
        {
            SmtpClient client            = new SmtpClient();
            client.Port                  = 587;
            client.Host                  = "smtp.live.com";
            client.EnableSsl             = true;
            client.Timeout               = 60000;
            client.DeliveryMethod        = SmtpDeliveryMethod.Network;
            client.UseDefaultCredentials = false;
            client.Credentials           = new System.Net.NetworkCredential(_acount,_pass);
            
            MailMessage mm                 = new MailMessage(_acount, destinatarios);
            mm.BodyEncoding                = UTF8Encoding.UTF8;
            mm.IsBodyHtml                  = true;
            mm.DeliveryNotificationOptions = DeliveryNotificationOptions.OnFailure;
            mm.Subject                     = String.Format("Listado Cancion Domingo ,{0}.", l.Fecha.ToString("yyyy-MM-dd"));
            mm.Body                        = GetBody(l,url);

            client.Send(mm);
            return true;
        }

        private string GetBody(Lista l,string url)
        {
            StringBuilder sb = new StringBuilder();
            int i = 0;
            sb.Append(String.Format("<b>Listado Para el Domingo {0}</b></br>",l.Fecha.ToString("yyyy-MM-dd")));
            sb.Append("<hr/></br>");
            sb.Append("<b>Canciones</b>");
            sb.Append("<ol>");
            foreach (var a in l.Canciones)
            {
                sb.Append(String.Format("<li>{0}  -  {1}</li>", a.Tipo, a.Nombre));
            }
            sb.Append("</ol></br>");
            sb.Append("<hr/></br>");
            if (l.Sugerencias.Count>0)
            {
                sb.Append("<b>sugerencias</b>");
                sb.Append("<ol>");
                foreach (var a in l.Sugerencias)
                {
                    sb.Append(String.Format("<li>{0}  -  {1}</li>", a.Tipo, a.Nombre));
                }
                sb.Append("</ol>");
            }
            //            sb.Append("<hr/></br>");
            sb.Append("<b>Ver Pagina</b></br>");
            sb.Append(string.Format("<a HREF='{0}'>Listado</a>",url));
            return sb.ToString();
        }
                
    }
}