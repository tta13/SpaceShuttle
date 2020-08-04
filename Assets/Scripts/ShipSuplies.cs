using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class ShipSuplies : MonoBehaviour
{

    [SerializeField] private Suplies shipSuplies;
    [SerializeField] private int passengerCapacity = 20;
    [SerializeField] private float fuelCapacity = 20f;
    [Range(0f, 1f)]
    [SerializeField] private float distanceToFuelRatio = .25f;

    private Dictionary<string, List<Passenger>> planetsPassengers;

    private void Awake()
    {
        if (planetsPassengers == null)
            planetsPassengers = new Dictionary<string, List<Passenger>>();

        var planets = FindObjectsOfType<Planet>();
        
        foreach(var planet in planets)
        {
            planetsPassengers.Add(planet.name, new List<Passenger>());
        }
    }

    public Suplies GetShipSuplies() => shipSuplies;

    public float GetDistanceToFuelRatio() => distanceToFuelRatio;

    public bool HasFuel(float distance)
    {
        return distance * distanceToFuelRatio <= shipSuplies.fuelAmount;
    }

    public void TransferSuplies(Planet planet)
    {
        LeavePassengers(planet);
        AddSuplies(planet);
    }

    private void LeavePassengers(Planet planet)
    {
        var passengersToLeave = planetsPassengers[planet.name];

        foreach(var passenger in passengersToLeave)
        {
            shipSuplies.passengers.Remove(passenger);
        }

        planetsPassengers[planet.name].RemoveRange(0, planetsPassengers[planet.name].Count);
    }

    private void AddSuplies(Planet planet)
    {
        var planetSuplies = planet.GetSuplies();
        var passengerCount = 0;

        foreach (var passenger in planetSuplies.passengers)
        {
            if (IsShipFull())
                continue;

            shipSuplies.passengers.Add(passenger);
            planetsPassengers[passenger.destiny.name].Add(passenger);
            passengerCount += 1;
        }

        planetSuplies.passengers.RemoveRange(0, passengerCount);

        shipSuplies.fuelAmount += planetSuplies.fuelAmount;
        planetSuplies.fuelAmount = 0;

        if (IsFuelFull())
        {
            planetSuplies.fuelAmount += shipSuplies.fuelAmount - fuelCapacity;
            shipSuplies.fuelAmount = fuelCapacity;
        }
    }

    public void ConsumeFuel(float distance)
    {
        shipSuplies.fuelAmount -= distance * distanceToFuelRatio;
    }

    public bool IsShipFull() => shipSuplies.passengers.Count >= passengerCapacity;

    public bool IsFuelFull() => shipSuplies.fuelAmount >= fuelCapacity;
}
