using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Planet : MonoBehaviour
{
    [SerializeField] private TMP_Text planetNameText;
    [SerializeField] private Suplies planetSuplies;

    private Button _btn;
    private static PlanetInfoPopup _popup;

    private void Awake()
    {
        Ship.OnGoToPlanet += OnShipGoingToPlanet;
        Ship.OnArrive += OnShipArrived;

        if (_btn == null)
            _btn = GetComponent<Button>();

        _btn.onClick.AddListener(() => ShowInfo());
    }

    private void Start()
    {
        if(planetNameText != null)
            planetNameText.text = gameObject.name;
    }

    private void OnShipArrived()
    {
        _btn.interactable = true;
    }

    private void OnShipGoingToPlanet()
    {
        _btn.interactable = false;

        if (_popup.gameObject.activeSelf)
            PopupManager.Instance.ClosePopup<PlanetInfoPopup>();

        if (planetNameText != null)
            planetNameText.gameObject.SetActive(true);
    }

    private void OnDestroy()
    {
        Ship.OnGoToPlanet -= OnShipGoingToPlanet;
        Ship.OnArrive -= OnShipArrived;
    }

    public Suplies GetSuplies() => planetSuplies;

    public void ShowInfo()
    {
        if (_popup == null || !_popup.gameObject.activeSelf)
            _popup = PopupManager.Instance.ShowPopup<PlanetInfoPopup>();

        planetNameText.gameObject.SetActive(false);
        _popup.SetPosition(planetNameText.transform.position);
        _popup.SetPassengerCount(planetSuplies.passengers.Count);
        _popup.SetFuelCount((int) planetSuplies.fuelAmount);
    }
}
