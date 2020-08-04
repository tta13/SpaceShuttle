using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    [SerializeField] private string gameSceneName = "Game";
    [Range(0f, 1f)]
    [SerializeField] private float brightnessTreshold = .7f;

    private void Start()
    {
        CheckBrightness();
    }

    public void PlayGame()
    {
        SceneLoader.LoadUsingLoadingScene(gameSceneName);
    }

    public void ShowTeacherArea()
    {
        PopupManager.Instance.ShowPopup<TeacherPopup>();
    }

    public void ShowStudentArea()
    {
        PopupManager.Instance.ShowPopup<StudentPopup>();
    }

    public void ShowSettings()
    {
        PopupManager.Instance.ShowPopup<SettingsPopup>();
    }

    private void CheckBrightness()
    {
        if (!PopupManager.Instance.AlreadyShownBrightnessPopup())
        {
            var brightness = BrightnessUtility.GetScreenBrightness();
            var currentTime = System.DateTime.Now.Hour;
            if (brightness > brightnessTreshold && (currentTime >= 20 || currentTime < 4))
            {
                var popup = PopupManager.Instance.ShowPopup<BrightnessPopup>();
                popup.SetCurrentBrightness(brightness);
                PopupManager.Instance.BrightnessPopupShowed();
            }
        }
    }    
}
