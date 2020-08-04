using UnityEngine;
using UnityEngine.SceneManagement;

public class PausePopup : GenericPopup
{
    [SerializeField] private string menuSceneName = "MainMenu";

    public void ResumeGame()
    {
        GameManager.Instance.ResumeGame();
        RequestHide();
    }

    public void BackToMenu()
    {
        var popup = PopupManager.Instance.ShowPopup<ConfirmationPopup>();
        popup.SetPositiveCase(GoBackToMenu);
        popup.SetText("Deseja voltar para o menu?");
    }

    private void GoBackToMenu()
    {
        ResumeGame();
        SceneManager.LoadScene(menuSceneName);
    }

    public override void RequestHide()
    {
        PopupManager.Instance.ClosePopup<PausePopup>();
    }
}
