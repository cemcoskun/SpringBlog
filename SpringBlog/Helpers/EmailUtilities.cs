using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;
using System.Web;

namespace SpringBlog.Helpers
{
    public static class EmailUtilities
    {
        public static async Task SendEmailAsync(string destination, string subject, string body)
        {
            // http://csharp.net-informations.com/communications/csharp-smtp-mail.htm
            MailMessage mail = new MailMessage();

            mail.To.Add(destination);
            mail.Subject = subject;
            mail.Body = body;
            mail.IsBodyHtml = true;

            using (var smtpClient = new SmtpClient())
            {
                smtpClient.Credentials = new NetworkCredential(
                    ConfigurationManager.AppSettings["mailAccount"],
                    ConfigurationManager.AppSettings["mailPassword"]
                    );
                await smtpClient.SendMailAsync(mail);
            }
        }
    }
}