using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ship : MonoBehaviour
{
    [SerializeField] private float speed = 10f;
    [SerializeField] private LineDrawer drawer;
    private Vector3 _destination;

    public void SetDestination(Transform newDestination)
    {
        _destination = newDestination.position;
        SetRotation();
        drawer.DrawLine(transform.position, _destination);
    }

    public void Go()
    {
        transform.DOMove(_destination, CalculateTime());
    }

    private float CalculateTime() => Vector3.Distance(_destination, transform.position) / speed;

    private void SetRotation()
    {
        var pos = transform.position;
        var direction = _destination - pos;
        var quat = Quaternion.LookRotation(Vector3.forward, direction);
        transform.DORotateQuaternion(quat, 1f);
    }
}
