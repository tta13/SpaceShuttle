using UnityEngine;
using UnityEngine.UI;

public class SettingsPopup : GenericPopup
{
    [SerializeField] private string creditsSceneName = "Credits";
    [SerializeField] private Button BGMBtn;
    [SerializeField] private Sprite[] BGMSprites;
    [SerializeField] private Button SFXButton;
    [SerializeField] private Sprite[] SFXSprites;

    private void Start()
    {
        UpdateBGMSprite();
        UpdateSFXSprite();
    }

    public void ShowCredits()
    {
        SceneLoader.LoadAdditiveScene(creditsSceneName);
    }

    public void ShowMECPopup()
    {
        var popup = PopupManager.Instance.ShowPopup<MecPopup>();
    }

    public void ShowViitraPopup()
    {
        var popup = PopupManager.Instance.ShowPopup<ViitraPopup>();
    }

    public void ToggleSound()
    {
        AudioManager.Instance.ToggleSounds();
        UpdateSFXSprite();
    }

    public void ToggleMusic()
    {
        AudioManager.Instance.ToggleMusic();
        UpdateBGMSprite();
    }

    private void UpdateBGMSprite()
    {
        BGMBtn.image.sprite = AudioManager.Instance.IsMusicPlaying() ? BGMSprites[0] : BGMSprites[1];
    }

    private void UpdateSFXSprite()
    {
        SFXButton.image.sprite = AudioManager.Instance.IsSoundPlaying() ? SFXSprites[0] : SFXSprites[1];
    }

    public void OpenMoreGames()
    {
        RequestHide();
        PopupManager.Instance.ShowPopup<MoreGamesPopup>();
    }

    public override void RequestHide()
    {
        PopupManager.Instance.ClosePopup<SettingsPopup>();
    }
}
