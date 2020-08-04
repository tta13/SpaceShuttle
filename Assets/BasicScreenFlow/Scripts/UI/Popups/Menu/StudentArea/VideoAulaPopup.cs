public class VideoAulaPopup : GenericPopup
{
    public override void RequestHide()
    {
        PopupManager.Instance.ClosePopup<VideoAulaPopup>();
    }
}
