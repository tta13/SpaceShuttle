using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class SwipeAnimation : MonoBehaviour
{
    [SerializeField] private Vector2 targetPosition;
    [SerializeField] private float swipeTime = .25f;

    private RectTransform _rectTransform;

    private void Awake()
    {
        _rectTransform = GetComponent<RectTransform>();
    }

    private void Start()
    {
        SlideToPosition(targetPosition, swipeTime);
    }

    public void SlideToPosition(Vector2 position, float time)
    {
        if(_rectTransform != null)
        {
            _rectTransform.DOAnchorPos(position, time);
        }
    }
}
