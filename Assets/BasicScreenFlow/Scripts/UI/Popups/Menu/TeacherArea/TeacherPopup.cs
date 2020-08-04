using UnityEngine;

public class TeacherPopup : GenericPopup
{
    [SerializeField] private GameObject guidePanel;
    [SerializeField] private GameObject redOnClassPanel;

    private void Start()
    {
        guidePanel.SetActive(false);
        redOnClassPanel.SetActive(false);
    }

    public void ShowRedOnClassPanel()
    {
        guidePanel.SetActive(false);
        redOnClassPanel.SetActive(true);
    }

    public void ShowGuidePanel()
    {
        guidePanel.SetActive(true);
        redOnClassPanel.SetActive(false);
    }

    public void ShowRedInfo()
    {
        PopupManager.Instance.ShowPopup<AboutTheRedPopup>();
    }

    public void ShowBncc()
    {
        PopupManager.Instance.ShowPopup<BnccPopup>();
    }

    public override void RequestHide()
    {
        PopupManager.Instance.ClosePopup<TeacherPopup>();
    }
}
