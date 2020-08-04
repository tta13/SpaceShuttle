using DG.Tweening;
using UnityEngine;

public class Credits : MonoBehaviour
{
    [SerializeField] private Transform creditsPanel;
    [SerializeField] private float targetPosition;
    [SerializeField] private float tweenTime;
    [SerializeField] private Ease easing;

    private void Start()
    {
        TweenCredits();
    }

    public void TweenCredits()
    {
        creditsPanel.DOMoveY(targetPosition, tweenTime).SetEase(easing).OnComplete(() => SkipCredits());
    }

    public void SkipCredits()
    {
        creditsPanel.DOKill();
        SceneLoader.UnloadScene("Credits");
    }
}
