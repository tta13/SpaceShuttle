using DG.Tweening;
using TMPro;
using UnityEngine;

public class HUD : MonoBehaviour
{
    [SerializeField] private ShipSuplies suplies;
    [SerializeField] RectTransform button;
    [SerializeField] TMP_Text passengerCount;
    [SerializeField] TMP_Text fuelCount;
    [SerializeField] private Vector2 goalPos;
    [SerializeField] private Vector2 initialPos;

    private RectTransform _rect;
    private string _maxFuel;

    private void Awake()
    {
        _rect = GetComponent<RectTransform>();
        _maxFuel = suplies.GetMaxFuel().ToString("F1");
    }

    private void Update()
    {
        passengerCount.text = suplies.GetPassengerCount().ToString();
        fuelCount.text = suplies.GetFuelCount().ToString("F1") + "/" + _maxFuel;
    }

    public void ToggleHUD()
    {
        _rect.DOAnchorPos(goalPos, .75f);
        var endValue = new Vector3(button.rotation.eulerAngles.x, button.rotation.eulerAngles.y,
            button.rotation.eulerAngles.z + 180f);
        button.DORotate(endValue, .75f);
        SwapPositions();
    }

    private void SwapPositions()
    {
        var aux = goalPos;
        goalPos = initialPos;
        initialPos = aux;
    }
}
