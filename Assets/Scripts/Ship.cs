using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ship : MonoBehaviour
{
    [SerializeField] private float speed = 10f;
    [SerializeField] private LineDrawer drawer;
    [SerializeField] private int peopleCapacity = 20;
    [SerializeField] private float fuelCapacity = 20;
    [SerializeField] private Suplies shipSuplies;
    [Range(0f, 1f)]
    [SerializeField] private float distanceToFuelRatio = .25f;

    private Vector3 _destination;
    private Suplies _destinationSuplies = null;

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
        if (HasFuel())
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

        ConsumeFuel(distanceTraveled);
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

        if(shipSuplies.peopleAmount + _destinationSuplies.peopleAmount > peopleCapacity)
        {
            _destinationSuplies.peopleAmount -= peopleCapacity - shipSuplies.peopleAmount;
            shipSuplies.peopleAmount = peopleCapacity;
        }
        else
        {
            shipSuplies.peopleAmount += _destinationSuplies.peopleAmount;
            _destinationSuplies.peopleAmount = 0;
        }

        if (shipSuplies.fuelAmount + _destinationSuplies.fuelAmount > fuelCapacity)
        {
            _destinationSuplies.fuelAmount -= fuelCapacity - shipSuplies.fuelAmount;
            shipSuplies.fuelAmount = fuelCapacity;
        }
        else
        {
            shipSuplies.fuelAmount += _destinationSuplies.fuelAmount;
            _destinationSuplies.fuelAmount = 0;
        }

        _destinationSuplies = null;
    }

    private bool HasFuel()
    {
        return GetDistance() * distanceToFuelRatio <= shipSuplies.fuelAmount;
    }

    private float GetDistance() => Vector3.Distance(_destination, transform.position);

    private void ConsumeFuel(float distance)
    {
        shipSuplies.fuelAmount -= distance * distanceToFuelRatio;
    }
}
