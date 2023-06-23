using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseController : MonoBehaviour
{
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked; // Bloquear el cursor en el centro
        Cursor.visible = false; // Hacer el cursor invisible
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Cursor.lockState = CursorLockMode.None; // Desbloquear el cursor
            Cursor.visible = true; // Hacer el cursor visible
        }

        if (Input.GetMouseButtonDown(0))
        {
            Cursor.lockState = CursorLockMode.Locked; // Bloquear el cursor en el centro
            Cursor.visible = false; // Hacer el cursor invisible
        }
    }
}

