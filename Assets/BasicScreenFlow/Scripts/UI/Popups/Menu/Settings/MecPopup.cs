public class MecPopup : GenericPopup
{
    private ILinkOpener _linkOpener;

    private void Start()
    {
        if (_linkOpener == null)
            _linkOpener = gameObject.AddComponent<LinkOpener>() as ILinkOpener;
    }

    public void OpenLink(string url)
    {
        _linkOpener.OpenURL(url);
    }

    public override void RequestHide()
    {
        PopupManager.Instance.ClosePopup<MecPopup>();
    }
}
