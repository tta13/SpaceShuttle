using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PlanetInfoPopup : GenericPopup
{
    [SerializeField] private TMP_Text passengers;
    [SerializeField] private TMP_Text fuel;

    public void SetPosition(Vector3 position)
    {
        position = new Vector3(position.x, position.y + .25f, position.z);
        transform.position = position;
    }

    public void SetPassengerCount(int passengerCount)
    {
        passengers.text = passengerCount.ToString();
    }

    public void SetFuelCount(int fuelCount)
    {
        fuel.text = fuelCount.ToString();
    }
}
