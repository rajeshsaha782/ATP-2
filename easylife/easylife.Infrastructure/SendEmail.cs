using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Mail;

namespace easylife.Infrastructure
{
    public class SendEmail
    {
        public bool Email(string ToemailAddress,string subject,string body)
        {
            try
            {

                MailMessage mail = new MailMessage("easylife@gmail.com", ToemailAddress);

                mail.Subject = subject;
                mail.Body = body;

                SmtpClient client = new SmtpClient("smtp.gmail.com", 587);
                client.Credentials = new System.Net.NetworkCredential("easylife@gmail.com", "fourRs");
                client.EnableSsl = true;
                client.Send(mail);

                return true;
              
            }
            catch(Exception ex)
            {
                return false;
            }
            
        }
    }
}
