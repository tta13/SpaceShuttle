using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class LineDrawer : MonoBehaviour
{
    [SerializeField] private TMP_Text distanceText;

    private LineRenderer _rend;
    private float distance;

    private void Start()
    {
        if (_rend == null)
            _rend = GetComponent<LineRenderer>();
        _rend.positionCount = 2;
    }

    public void DrawLine(Vector3 from, Vector3 to)
    {
        _rend.SetPosition(0, new Vector3(from.x, from.y, 0f));
        _rend.SetPosition(1, new Vector3(to.x, to.y, 0f));
        distance = (to - from).magnitude / 10f;
        distanceText.text = distance.ToString("F2") + " x 10^7 km";
    }

    public void EraseLine()
    {
        _rend.SetPosition(0, Vector3.zero);
        _rend.SetPosition(1, Vector3.zero);
    }
}
