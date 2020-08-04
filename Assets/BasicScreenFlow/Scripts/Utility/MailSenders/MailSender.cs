using UnityEngine;
using UnityEngine.Networking;

public class MailSender : MonoBehaviour, IMailSender
{
    private string _mail;
    private string _subject;

    public void SendEmail(string body)
    {
        //on windows' unity is not possible to use a return character in the editor
        body = body.Replace("\\n", "\n");
        string escapedBody = MyEscapeURL(body);

        Application.OpenURL("mailto:" + _mail + "?subject=" + _subject + "&body=" + escapedBody);
    }

    public void SetMailReceiver(string mail)
    {
        _mail = mail;
    }

    public void SetMailSubject(string subject)
    {
        _subject = subject;
    }

    public string MyEscapeURL(string url) => UnityWebRequest.EscapeURL(url).Replace("+", "%20");
}
