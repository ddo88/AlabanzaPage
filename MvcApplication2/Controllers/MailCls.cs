using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Web;
using MvcApplication2.Models;

namespace MvcApplication2.Controllers
{
    public class MailCls
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
            sb.Append("-----------------------------------------\n");
            sb.Append("\n");
            foreach (var a in l.Canciones)
            {
                sb.Append(String.Format("[{0}]  {1}-{2} \n", i, a.Tipo, a.Nombre));
                i++;
            }
            sb.Append("\n");
            sb.Append("-----------------------------------------\n");
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

    
}