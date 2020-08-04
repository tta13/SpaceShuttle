using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SingletonsSceneManger : MonoBehaviour
{
    [SerializeField] string termsSceneName = "TermsAndPrivacy";
    [SerializeField] string loginSceneName = "Login";
    [SerializeField] string menuSceneName = "MainMenu";
    [SerializeField] string singletonsSceneName = "Singletons";

    private void Start()
    {
        var firstTime = SaveSystemManager.Instance.GetPlayerData().firstTime;

        if (firstTime)
        {
            SceneLoader.LoadAdditiveScene(termsSceneName);
            SceneLoader.LoadAdditiveScene(loginSceneName);
        }

        SceneLoader.LoadAdditiveScene(menuSceneName).completed += OnMenuLoaded;
    }

    private void OnMenuLoaded(AsyncOperation obj)
    { 
        SceneLoader.SetActiveScene(menuSceneName);
        SceneLoader.UnloadScene(singletonsSceneName);
        obj.completed -= OnMenuLoaded;
    }
}
