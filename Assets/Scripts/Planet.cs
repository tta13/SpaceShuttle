using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Planet : MonoBehaviour
{
    [SerializeField] private TMP_Text planetNameText;
    [SerializeField] private Suplies planetSuplies;

    private void Start()
    {
        if(planetNameText != null)
            planetNameText.text = gameObject.name;
    }

    public Suplies GetSuplies() => planetSuplies;
}
