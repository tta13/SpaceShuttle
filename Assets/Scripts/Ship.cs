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
    private Suplies _destinationSuplies = null;

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

    public void SetSuplies(Planet planet)
    {
        _destinationSuplies = planet.GetSuplies();
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
            var partialDestination = _destination.normalized * distanceTraveled;
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
        if (_destinationSuplies == null) return;

        mySuplies.TransferSuplies(_destinationSuplies);

        _destinationSuplies = null;
    }
    

    private float GetDistance() => Vector3.Distance(_destination, transform.position);
}
