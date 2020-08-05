using UnityEngine;

public class GameOverController : MonoBehaviour
{
    public void PlayAgain()
    {
        SceneLoader.LoadUsingLoadingScene(6);
    }
}
