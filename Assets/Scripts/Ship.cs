using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ship : MonoBehaviour
{
    [SerializeField] private float speed = 10f;
    [SerializeField] private LineDrawer drawer;
    [SerializeField] private int peopleCapacity = 20;
    [SerializeField] private int fuelCapacity = 20;
    [SerializeField] private Suplies shipSuplies;
    [Range(0f, 1f)]
    [SerializeField] private float fuelToDistanceRatio = .25f;

    private Vector3 _destination;
    private Suplies _destinationSuplies;

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
        transform.DOMove(_destination, CalculateTime()).OnComplete(() => OnArrive());
    }

    private float CalculateTime() => Vector3.Distance(_destination, transform.position) / speed;

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
    }
}
