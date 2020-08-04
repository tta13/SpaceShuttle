public class AboutTheRedPopup : GenericPopup
{
    public override void RequestHide()
    {
        PopupManager.Instance.ClosePopup<AboutTheRedPopup>();
    }
}
