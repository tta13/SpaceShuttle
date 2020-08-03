using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Planet : MonoBehaviour
{
    [SerializeField] private TMP_Text planetNameText;

    private void Start()
    {
        planetNameText.text = gameObject.name;
    }
}
