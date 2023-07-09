using UnityEngine;
using UnityEngine.SceneManagement;

public class CambiarEscena : MonoBehaviour
{
    public string Campo; // Nombre de la escena a la que quieres cambiar

    public void CambiarAEscena()
    {
        SceneManager.LoadScene(Campo); // Cambia a la escena especificada
    }
}
