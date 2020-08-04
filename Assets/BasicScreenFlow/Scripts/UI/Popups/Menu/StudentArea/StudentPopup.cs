using TMPro;
using UnityEngine;

public class StudentPopup : GenericPopup
{
    [SerializeField] private GameObject subjectPanel;
    [SerializeField] private GameObject coursesPanel;
    [SerializeField] private TMP_Text greeting;

    private void Start()
    {
        subjectPanel.SetActive(false);
        coursesPanel.SetActive(false);

        var playerName = SaveSystemManager.Instance.GetPlayerData().playerName;

        if(playerName != "")
        {
            greeting.text = "Olá, " + playerName + "!\nÁrea do estudante";
        }
    }

    public void ShowCoursesPanel()
    {
        subjectPanel.SetActive(false);
        coursesPanel.SetActive(true);
    }

    public void ShowSubjectPanel()
    {
        subjectPanel.SetActive(true);
        coursesPanel.SetActive(false);
    }

    public void ShowVideos()
    {
        PopupManager.Instance.ShowPopup<VideoAulaPopup>();
    }

    public override void RequestHide()
    {
        PopupManager.Instance.ClosePopup<StudentPopup>();
    }
}
