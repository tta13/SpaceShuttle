using System.Collections.Generic;
using UnityEngine;

public class PopupManager : Singleton<PopupManager>
{
    private Stack<GenericPopup> _popups = new Stack<GenericPopup>();
    private bool _brightnessShown = false;

    public T ShowPopup<T>() where T : GenericPopup
    {
        T popupWindow = GetPopup<T>();
        Debug.Log(popupWindow);

        _popups.Push(popupWindow);
        popupWindow.transform.SetAsLastSibling();
        popupWindow.Show();

        return popupWindow;
    }

    public T ClosePopup<T>() where T : GenericPopup
    {
        T popupWindow = (T)_popups.Pop();
        popupWindow.Hide();
        return popupWindow;
    }

    public T GetPopup<T>() where T : GenericPopup
    {
        var foundPopups = Resources.FindObjectsOfTypeAll<T>();
        if (foundPopups.Length > 0)
        {
            return foundPopups[0];
        }

        Debug.LogError("Popup not found!");
        return null;
    }

    public bool AlreadyShownBrightnessPopup() => _brightnessShown;

    public void BrightnessPopupShowed() { _brightnessShown = true; }
}
