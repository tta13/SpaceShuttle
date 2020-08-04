using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BnccPopup : GenericPopup
{
    public void ShowSkills()
    {
        var popup = PopupManager.Instance.ShowPopup<BnccItemPopup>();
        popup.SetSkills();
    }

    public void ShowCompetences()
    {
        var popup = PopupManager.Instance.ShowPopup<BnccItemPopup>();
        popup.SetCompetences();
    }

    public override void RequestHide()
    {
        PopupManager.Instance.ClosePopup<BnccPopup>();
    }
}
