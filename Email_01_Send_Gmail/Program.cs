using System;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;

namespace Email_01_Send_Gmail
{
    class Program
    {
        static void Main(string[] args)
        {


            var fromAddress = new MailAddress("from_gmail_address_here", "From Name");
            var toAddress = new MailAddress("to_email_address_here", "To Name");
            const string fromPassword = "FastestBrain4";
            const string subject = "Subject";
            const string body = "Body";

            var smtp = new SmtpClient
            {
                Host = "smtp.gmail.com",
                Port = 587,
                EnableSsl = true,
                DeliveryMethod = SmtpDeliveryMethod.Network,
                UseDefaultCredentials = false,
                Credentials = new NetworkCredential(fromAddress.Address, fromPassword)
            };
            using (var message = new MailMessage(fromAddress, toAddress)
            {
                Subject = subject,
                Body = body
            })

                smtp.Send(message);
        }

    }
}
