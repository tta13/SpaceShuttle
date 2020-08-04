using System.Net;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerInfoSetter : MonoBehaviour
{
    [SerializeField] private TMP_InputField nameField;
    [SerializeField] private TMP_InputField ageField;
    [SerializeField] private Button skipButton;
    [SerializeField] private Button continueButton;
    [SerializeField] private string loginSceneName = "Login";

    private string _playerName;
    private bool _hasName = false;
    private string _playerAge;
    private bool _hasAge = false;

    private void Start()
    {
        skipButton.gameObject.SetActive(true);
        continueButton.gameObject.SetActive(false);
    }

    public void OnNameChanged(string newName)
    {
        if (newName != "Nome..." && newName != "")
        {
            _hasName = true;
            _playerName = newName;
        }
        else
        {
            _hasName = false;
        }
        CanContinue();
    }

    public void OnAgeChanged(string newAge)
    {
        if (newAge != "Idade..." && newAge != "")
        {
            _hasAge = true;
            _playerAge = newAge;
        }
        else
        {
            _hasAge = false;
        }
        CanContinue();
    }

    public void Skip()
    {
        var playerData = SaveSystemManager.Instance.GetPlayerData();
        playerData.firstTime = false;
        SaveSystemManager.Instance.Save();

        SceneLoader.UnloadScene(loginSceneName);
    }

    public void Continue()
    {
        var playerData = SaveSystemManager.Instance.GetPlayerData();
        playerData.playerName = _playerName;
        playerData.playerAge = _playerAge;
        SaveSystemManager.Instance.Save();

        Skip();
    }

    private void CanContinue()
    {
        if (_hasName && _hasAge)
        {
            skipButton.gameObject.SetActive(false);
            continueButton.gameObject.SetActive(true);
        }
        else
        {
            skipButton.gameObject.SetActive(true);
            continueButton.gameObject.SetActive(false);
        }
    }
}
