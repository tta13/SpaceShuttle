using TMPro;
using UnityEngine;

public class PassengerInfoContainer : MonoBehaviour
{
    [SerializeField] private TMP_Text passenger;
    [SerializeField] private TMP_Text destiny;

    private Passenger _passenger;

    public void SetPassenger(Passenger p)
    {
        _passenger = p;
        UpdateText();
    }

    private void UpdateText()
    {
        passenger.text = _passenger.name;
        destiny.text = _passenger.destiny.name;
    }
}
