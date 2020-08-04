public interface IMailSender
{
    void SendEmail(string body);
    void SetMailReceiver(string receiver);
    void SetMailSubject(string subject);
    string MyEscapeURL(string url);
}
