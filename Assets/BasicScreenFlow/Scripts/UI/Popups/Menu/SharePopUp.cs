using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class SharePopUp : GenericPopup
{
    [SerializeField] private TextMeshProUGUI inputField;
    [SerializeField] private Toggle checkbox;
    [SerializeField] private string appUrl;
    [SerializeField] private string guiaUrl;

    private string _defaultMessage = "Baixe agora o RED: ";

    public void Share()
    {
        Debug.Log(inputField.text);
        Debug.Log(checkbox.isOn);
        StartCoroutine(ShareMsg());
    }

    private IEnumerator ShareMsg()
    {
        yield return new WaitForEndOfFrame();
        /*
        NativeShare _share = new NativeShare();

        _share.SetSubject("Venha Jogar!");
        _share.SetTitle("Venha Jogar!");

        var inputTxt = inputField.text;
        var msgText = "";

        if (inputTxt.Length > 0 && inputTxt != "Digite uma mensagem...")
        {
            msgText += inputTxt;
            msgText += " - ";
        }

        msgText += _defaultMessage;
        msgText += appUrl;

        var includeGuide = checkbox.isOn;
        if (includeGuide)
        {
            Debug.Log("incluindo guia");
            msgText += " - Acesse o Guia do Professor em: ";
            msgText += guiaUrl;
        }

        _share.SetText(msgText);

        _share.Share();*/
    }

    public override void RequestHide()
    {
        PopupManager.Instance.ClosePopup<SharePopUp>();
    }
}
