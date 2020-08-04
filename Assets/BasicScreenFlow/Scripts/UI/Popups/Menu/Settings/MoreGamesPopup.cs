using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoreGamesPopup : GenericPopup
{
    public void OpenSettings()
    {
        RequestHide();
        PopupManager.Instance.ShowPopup<SettingsPopup>();
    }

    public override void RequestHide()
    {
        PopupManager.Instance.ClosePopup<MoreGamesPopup>();
    }
}
