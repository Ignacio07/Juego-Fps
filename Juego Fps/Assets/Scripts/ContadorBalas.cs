using UnityEngine;
using UnityEngine.UI;

public class ContadorBalas : MonoBehaviour
{
    public int balasRestantes = 10; // N�mero inicial de balas

    private Text textoContador; //Texto que se le asociara

    private void Start()
    {
        textoContador = GetComponent<Text>();
        ActualizarContador();
    }

    public void Disparar()
    {
        if (balasRestantes > 0)
        {
            balasRestantes--;
            ActualizarContador();
        }
    }

    private void ActualizarContador()
    {
        textoContador.text = "Balas: " + balasRestantes.ToString();
    }
}

