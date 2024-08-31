using System.Net;
using System.Net.Mail;

namespace FreshShop.MvcWebUI.Helpers
{
    public static class MailHelper
    {
        public static void SendMail( string to , string title , string message) {
            MailMessage msg = new MailMessage("muhammet021mtk@gmail.com",to);
            msg.Subject = title;
            msg.Body = message;
            msg.IsBodyHtml = true;
            //qptq ztsd lcak slcy
            //smtp.Port = 587;
            SmtpClient smtp = new SmtpClient();
            smtp.Credentials = new NetworkCredential("muhammet021mtk@gmail.com", "qptq ztsd lcak slcy");
            smtp.Host = ("smtp.gmail.com");
            smtp.Port = 587;
            smtp.EnableSsl = true;
            smtp.Send(msg);
        }
    }
}
