using UnityEngine;

public class GameManager : Singleton<GameManager>
{
    public void PauseGame()
    {
        PopupManager.Instance.ShowPopup<PausePopup>();
        Time.timeScale = 0f;
    }

    public void ResumeGame()
    {
        Time.timeScale = 1f;
    }
}
