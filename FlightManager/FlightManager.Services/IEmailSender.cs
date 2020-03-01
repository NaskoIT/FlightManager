namespace FlightManager.Services
{
    public interface IEmailSender
    {
        void Send(string from, string to, string body, string subject, bool isBodyHtml = false);
    }
}
