using System.Net;
using System.Net.Mail;

namespace FlightManager.Services
{
    public class EmailSender : IEmailSender
    {
        private const int Port = 465;
        private readonly SmtpClient client;

        public EmailSender(string smtpServer, string username, string password)
        {
            client = new SmtpClient(smtpServer, Port)
            {
                Credentials = new NetworkCredential(username, password),
                EnableSsl = true
            };
        }

        public void Send(string from, string to, string body, string subject, bool isBodyHtml = false)
        {
            var mailMessage = new MailMessage();
            mailMessage.From = new MailAddress(from);
            mailMessage.To.Add(to);
            mailMessage.Body = body;
            mailMessage.IsBodyHtml = isBodyHtml;
            mailMessage.Subject = subject;
            client.Send(mailMessage);
        }
    }
}
