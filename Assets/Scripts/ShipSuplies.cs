using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipSuplies : MonoBehaviour
{

    [SerializeField] private Suplies shipSuplies;
    [SerializeField] private int peopleCapacity = 20;
    [SerializeField] private float fuelCapacity = 20;
    [Range(0f, 1f)]
    [SerializeField] private float distanceToFuelRatio = .25f;


    public Suplies GetShipSuplies() => shipSuplies;

    public float GetDistanceToFuelRatio() => distanceToFuelRatio;

    public bool HasFuel(float distance)
    {
        return distance * distanceToFuelRatio <= shipSuplies.fuelAmount;
    }

    public void TransferSuplies(Suplies planetSuplies)
    {
        
    }

    public void ConsumeFuel(float distance)
    {
        shipSuplies.fuelAmount -= distance * distanceToFuelRatio;
    }
}
