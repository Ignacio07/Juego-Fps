using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{
    private Animator animador;
    private bool enPiso;
    private bool caminando;
    private bool corriendo;
    private bool volando;
    private bool buceando;
    private bool atacando;
    private bool agachado;
    private bool saltando;

    private void Start()
    {
        animador = GetComponent<Animator>();
    }

    private void Update()
    {
        Movimiento();
        Correr();
        Volar();
        Bucear();
        Saltar();
        Ataque();
        Agacharse();
    }

    private void Movimiento()
    {
        float movimientoHorizontal = Input.GetAxis("Horizontal");
        float movimientoVertical = Input.GetAxis("Vertical");
        bool enMovimiento = Mathf.Abs(movimientoHorizontal) > 0.1f || Mathf.Abs(movimientoVertical) > 0.1f;

        animador.SetBool("Caminando", enMovimiento);

        if (!enMovimiento)
        {
            animador.SetBool("Corriendo", false);
            animador.SetBool("Volando", false);
            animador.SetBool("Buceando", false);
        }
    }

    private void Correr()
    {
        bool inputCorrer = caminando && Input.GetKey(KeyCode.LeftShift);
        corriendo = inputCorrer;
        animador.SetBool("Corriendo", corriendo);
    }

    private void Volar()
    {
        bool inputVolar = caminando && Input.GetKey(KeyCode.RightShift);
        volando = inputVolar;
        animador.SetBool("Volando", volando);
    }

    private void Bucear()
    {
        bool inputBucear = caminando && Input.GetKey(KeyCode.L);
        buceando = inputBucear;
        animador.SetBool("Buceando", buceando);
    }

    private void Saltar()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (enSuelo)
            {
                animador.SetTrigger("Saltar");
            }
            else
            {
                animador.SetTrigger("SaltoHorizontal");
            }
        }
    }

    private void Ataque()
    {
        bool inputAtaque = Input.GetKey(KeyCode.E);
        atacando = inputAtaque;
        animador.SetBool("Atacando", atacando);

        if (!atacando)
        {
            animador.SetTrigger("DetenerAtaque");
        }
    }

    private void Agacharse()
    {
        bool inputAgacharse = Input.GetKey(KeyCode.V);
        agachado = inputAgacharse;
        animador.SetBool("Agachado", agachado);

        if (!agachado)
        {
            animador.SetTrigger("DetenerAgacharse");
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Piso"))
        {
            enPiso = true;
            animador.SetBool("Saltando", false);
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag("Piso"))
        {
            enPiso = false;
            animador.SetBool("Saltando", true);
        }
    }
}
