using UnityEngine;
using UnityEngine.UI;

public class BrightnessPopup : GenericPopup
{
    [SerializeField] private Slider _brightness;

    public void SetCurrentBrightness(float value)
    {
        _brightness.value = value;
    }

    public void ChangeBrightness(float value)
    {
        Debug.Log(value);
        BrightnessUtility.SetScreenBrightness(value);
    }

    public override void RequestHide()
    {
        PopupManager.Instance.ClosePopup<BrightnessPopup>();
    }
}
