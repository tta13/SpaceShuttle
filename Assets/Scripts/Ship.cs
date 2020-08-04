using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ship : MonoBehaviour
{
    [SerializeField] private float speed = 10f;
    [SerializeField] private LineDrawer drawer;

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
        var distanceTraveled = 0f;
        var shipSuplies = mySuplies.GetShipSuplies();
        var distanceToFuelRatio = mySuplies.GetDistanceToFuelRatio();

        if (mySuplies.HasFuel(GetDistance()))
        {
            transform.DOMove(_destination, CalculateTime()).OnComplete(() => OnArrive());
            distanceTraveled = GetDistance();
        }
        else
        {
            distanceTraveled = (shipSuplies.fuelAmount / distanceToFuelRatio);
            var partialDestination = (_destination - transform.position).normalized * distanceTraveled;
            transform.DOMove(partialDestination, CalculateTime());
        }

        mySuplies.ConsumeFuel(distanceTraveled);
    }

    private float CalculateTime() =>  GetDistance() / speed;

    private void SetRotation()
    {
        var pos = transform.position;
        var direction = _destination - pos;
        var quat = Quaternion.LookRotation(Vector3.forward, direction);
        transform.DORotateQuaternion(quat, 1f);
    }

    private void OnArrive()
    {
        TransferSuplies();
    }

    private void TransferSuplies()
    {
        mySuplies.TransferSuplies(_destinationPlanet);
    }    

    private float GetDistance() => Vector3.Distance(_destination, transform.position);
}
