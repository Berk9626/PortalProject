

using Newtonsoft.Json;
using System.Net;
using System.Net.Http;
using System.Net.Mail;

//using System.Net.Mail;
using System.Text;




namespace Portal.WEBUI.Models.MailViewModel
{
    public class MailSender
    {
        public static void SendEmail (string email, string subject, string body)
        {
            //Email Message Part;
            System.Net.Mail.MailMessage sender = new System.Net.Mail.MailMessage();
            sender.From = new System.Net.Mail.MailAddress("muzafferberkmen1@gmail.com","PortalProject");
            sender.Subject = subject;
            sender.Body = body;
            sender.BodyEncoding = Encoding.UTF8;
            sender.To.Add(email);

            //Smtp Part;
            SmtpClient smtpClient = new SmtpClient();
            smtpClient.Credentials = new NetworkCredential("muzafferberkmen1@gmail.com", "vjne aqes jdin qdei");
            smtpClient.Port = 587;
            smtpClient.Host = "smtp.gmail.com";
            smtpClient.EnableSsl = true;
            smtpClient.Send(sender);

        }
    }
}


