using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CambiarEscena : MonoBehaviour
{
    public Animator transition;
    public float transitionTime = 1f;
    public string Campo; // Nombre de la escena a la que quieres cambiar

    public void CambiarAEscena()
    {
        StartCoroutine(LoadLevel(Campo)); // Cambia a la escena especificada
    }
    IEnumerator LoadLevel(string level){
        transition.SetTrigger("Start");

        yield return new WaitForSeconds(transitionTime);
        
        SceneManager.LoadScene(level);
    }
}
