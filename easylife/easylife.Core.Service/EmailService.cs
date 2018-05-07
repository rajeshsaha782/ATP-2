using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Mail;
namespace easylife.Core.Service
{
    public class EmailService
    {
        public bool SendEmail(string emailAddress,string subject,string body)
        {
            bool sent = true;
            try {
                MailMessage mail = new MailMessage("easylifebder3@gmail.com", emailAddress);

                mail.Subject = subject;
                mail.Body = body;

                SmtpClient client = new SmtpClient("smtp.gmail.com", 587);
                client.Credentials = new System.Net.NetworkCredential("easylifebder3@gmail.com", "Easylife@er3");
                client.EnableSsl = true;
                client.Send(mail);
            }
            catch (Exception ex)
            {
                sent = false;
            }
            return sent;

        }
    }
}
