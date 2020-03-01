using FlightManager.Services;
using Microsoft.Extensions.Configuration;
namespace FlightManager.Web.Infrastructure
{
    public static class EmailSenderFactory
    {
        public static EmailSender Instance(IConfiguration configuration)
        {
            string smtpServer = configuration["Email:SmtpServer"];
            string username = configuration["Email:Username"];
            string password = configuration["Email:Password"];
            int port = int.Parse(configuration["Email:Port"]);
            return new EmailSender(smtpServer, username, password, port);
        }
    }
}
