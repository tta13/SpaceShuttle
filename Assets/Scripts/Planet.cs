using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Planet : MonoBehaviour
{
    [SerializeField] private TMP_Text planetNameText;
    [SerializeField] private Suplies planetSuplies;

    private Button _btn;

    private void Awake()
    {
        Ship.OnGoToPlanet += OnShipGoingToPlanet;
        Ship.OnArrive += OnShipArrived;
    }

    private void Start()
    {
        if(planetNameText != null)
            planetNameText.text = gameObject.name;
    }

    private void OnShipArrived()
    {
        GetButton();
        _btn.interactable = true;
    }

    private void OnShipGoingToPlanet()
    {
        GetButton();
        _btn.interactable = false;
    }

    private void GetButton()
    {
        if (_btn == null)
            _btn = GetComponent<Button>();
    }

    private void OnDestroy()
    {
        Ship.OnGoToPlanet -= OnShipGoingToPlanet;
        Ship.OnArrive -= OnShipArrived;
    }

    public Suplies GetSuplies() => planetSuplies;
}
