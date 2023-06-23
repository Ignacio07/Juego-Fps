using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMotor : MonoBehaviour
{
    private CharacterController controller;
    private Vector3 playerVelocity;
    public float speed = 5f;
    private bool isGrounded;
    private bool wasGrounded; // Variable para verificar si estaba en el suelo en el frame anterior
    public float gravity = -9.8f;
    public float jumpH = 3f;
    public Animator animator;
    private AudioSource audioSource; // Fuente de audio
    public AudioClip walkSound; // Sonido al caminar
    public AudioClip jumpSound; // Sonido al saltar
    public AudioClip landSound; // Sonido al aterrizar

    void Start()
    {
        controller = GetComponent<CharacterController>();
        audioSource = GetComponent<AudioSource>();
    }

    void Update()
    {
        wasGrounded = isGrounded;
        isGrounded = controller.isGrounded;

        if (!wasGrounded && isGrounded)
        {
            // Reproducir sonido de aterrizaje
            audioSource.PlayOneShot(landSound);
        }
    }

    public void ProcessMove(Vector2 input)
    {
        Vector3 moveDirection = Vector3.zero;
        moveDirection.x = input.x;
        moveDirection.z = input.y;

        bool isWalking = (moveDirection.x != 0f || moveDirection.z != 0f);

        // Activar el estado "walk" en el Animator según el valor de la variable booleana
        animator.SetBool("Walk", isWalking);

        controller.Move(transform.TransformDirection(moveDirection) * speed * Time.deltaTime);
        playerVelocity.y += gravity * Time.deltaTime;

        if (isGrounded && playerVelocity.y < 0)
        {
            playerVelocity.y = -2f;
        }

        controller.Move(playerVelocity * Time.deltaTime);

        if (isWalking && isGrounded && !audioSource.isPlaying)
        {
            audioSource.clip = walkSound;
            audioSource.Play();
        }
        else if ((!isWalking || !isGrounded) && audioSource.clip == walkSound)
        {
            // Detener la reproducción del sonido de caminar si el jugador deja de moverse o no está en el suelo
            audioSource.Stop();
        }
    }

    public void Jump()
    {
        if (isGrounded)
        {
            playerVelocity.y = Mathf.Sqrt(jumpH * -3.0f * gravity);

            // Reproducir el sonido de salto (jump)
            audioSource.clip = jumpSound;
            audioSource.Play();
        }
    }
}