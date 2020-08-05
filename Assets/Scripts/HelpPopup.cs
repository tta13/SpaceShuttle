using System.Collections.Generic;
using UnityEngine;

public class HelpPopup : GenericPopup
{
    [SerializeField] private GameObject fuelPanel;
    [SerializeField] private GameObject passengerPanel;
    [SerializeField] private Transform content;
    [SerializeField] private GameObject passengerContainer;

    private List<GameObject> _containers;

    public void TogglePanels(bool activateFuel)
    {
        fuelPanel.SetActive(activateFuel);
        passengerPanel.SetActive(!activateFuel);
    }

    public void SetPassengers(List<Passenger> passengers)
    {
        if (_containers == null)
            _containers = new List<GameObject>();

        foreach (var p in passengers)
        {
            var container = Instantiate(passengerContainer, content);
            container.GetComponent<PassengerInfoContainer>().SetPassenger(p);
            _containers.Add(container);
        }
    }

    public override void RequestHide()
    {
        PopupManager.Instance.ClosePopup<HelpPopup>();
        DestroyGarbage();
    }

    private void DestroyGarbage()
    {
        foreach(var c in _containers)
        {
            Destroy(c);
        }

        _containers.RemoveRange(0, _containers.Count);
    }
}
