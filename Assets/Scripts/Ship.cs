using DG.Tweening;
using System;
using UnityEngine;

public class Ship : MonoBehaviour
{
    [SerializeField] private float speed = 10f;
    [SerializeField] private LineDrawer drawer;

    public static event Action OnGoToPlanet;
    public static event Action OnArrive;

    private ShipSuplies mySuplies;
    private Vector3 _destination;
    private Planet _destinationPlanet;

    private void Awake()
    {
        mySuplies = GetComponent<ShipSuplies>();
    }

    public void SetDestination(Transform newDestination)
    {
        _destination = newDestination.position;
        SetRotation();
        drawer.DrawLine(transform.position, _destination);
    }

    public void SetPlanet(Planet planet)
    {
        _destinationPlanet = planet;
    }

    public void Go()
    {
        OnGoToPlanet?.Invoke();

        var distanceTraveled = 0f;
        var shipSuplies = mySuplies.GetShipSuplies();
        var distanceToFuelRatio = mySuplies.GetDistanceToFuelRatio();
        var pos = transform.position;

        if (mySuplies.HasFuel(GetDistance()))
        {
            distanceTraveled = GetDistance();
            transform.DOMove(_destination, CalculateTime(distanceTraveled)).OnComplete(() => Arrive());
        }
        else
        {
            distanceTraveled = (shipSuplies.fuelAmount / distanceToFuelRatio);
            var partialDestination = (_destination).normalized * (distanceTraveled);
            transform.DOMove(partialDestination, CalculateTime(distanceTraveled / 2f));
        }

        mySuplies.ConsumeFuel(distanceTraveled);
    }

    private float CalculateTime(float distance) =>  distance / speed;

    private void SetRotation()
    {
        var pos = transform.position;
        var direction = _destination - pos;
        var quat = Quaternion.LookRotation(Vector3.forward, direction);
        transform.DORotateQuaternion(quat, 1f);
    }

    private void Arrive()
    {
        OnArrive?.Invoke();
        TransferSuplies();
    }

    private void TransferSuplies()
    {
        mySuplies.TransferSuplies(_destinationPlanet);
    }    

    private float GetDistance() => Vector3.Distance(_destination, transform.position);
}
