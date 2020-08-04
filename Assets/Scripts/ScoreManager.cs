using TMPro;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    [SerializeField] private TMP_Text textToUpdate;

    private int _exponent = 5;
    private float _passengersDelivered = 0f;

    private void Awake()
    {
        ShipSuplies.OnDeliverPassenger += UpdateScore;
    }

    private void Start()
    {
        UpdateText();
    }

    private void UpdateScore(int newPassengers)
    {
        _passengersDelivered += newPassengers;

        if(_passengersDelivered >= 10f)
        {
            _passengersDelivered /= 10f;
            _exponent += 1;
        }

        UpdateText();
    }

    private void UpdateText()
    {
        textToUpdate.text = _passengersDelivered.ToString("F1") + " x 10^" + _exponent.ToString();
    }

    private void OnDestroy()
    {
        ShipSuplies.OnDeliverPassenger -= UpdateScore;
    }
}
