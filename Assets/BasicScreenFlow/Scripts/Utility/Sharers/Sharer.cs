using System.Collections;
using UnityEngine;

public class Sharer : MonoBehaviour//, ISharer
{
    [SerializeField] private string appUrl;
    [SerializeField] private string defaultMessage = "Baixe agora o RED: ";
    [SerializeField] private string title = "Venha Jogar!";
    [SerializeField] private string subject = "Venha Jogar!";

    /*private NativeShare _share;

    private void Awake()
    {
        if(_share == null)
            _share = new NativeShare();
    }

    public void Share()
    {
        StartCoroutine(ShareMsg());
    }

    private IEnumerator ShareMsg()
    {
        yield return new WaitForEndOfFrame();

        _share.SetSubject(subject);
        _share.SetTitle(title);
        
        var msgText = "";

        msgText += defaultMessage;
        msgText += appUrl;

        _share.SetText(msgText);

        _share.Share();
    }*/
}
