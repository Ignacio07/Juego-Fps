using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputManager : MonoBehaviour
{
    private PlayerInput playerInput;
    public PlayerInput.NormalActions normal;
    private PlayerMotor motor;
    private PlayerLook look;

    void Awake()
    {
        playerInput = new PlayerInput();
        normal = playerInput.Normal;
        motor = GetComponent<PlayerMotor>();
        look = GetComponent<PlayerLook>();
        normal.Saltar.performed += ctx => motor.Jump();
    }
    private void FixedUpdate()
    {
        motor.ProcessMove(normal.Movimiento.ReadValue<Vector2>());
    }
    private void LateUpdate()
    {
        look.ProcessLook(normal.Mirar.ReadValue<Vector2>());
    }
    private void OnEnable(){
        normal.Enable();
    }
    private void OnDisable(){
        normal.Disable();
    }
}
