using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPref : MonoBehaviour
{
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.S))
        {
            GuardarDatos();
        }
    }

    private void Start()
    {
        CargarDatos();
    }

    private void GuardarDatos()
    {
        PlayerPrefs.SetString("Nombre", "Yo");
        PlayerPrefs.Save();
    }

    private void CargarDatos()
    {
        string nombre = PlayerPrefs.GetString("Nombre");
    }
}
