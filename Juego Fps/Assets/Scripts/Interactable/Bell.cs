using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;


public class Bell : Interactable
{
    private bool isCounting = false;
    public float timer = 0f;
    public float duration = 5f; // Duraci�n del contador en segundos
    public TextMeshProUGUI timerText; // Referencia al objeto TextMeshProUGUI

    public int score = 0;
    public int maxScore = 0;
    public TextMeshProUGUI scoreText; // Referencia al objeto TextMeshProUGUI
    public TextMeshProUGUI maxScoreText; // Referencia al objeto TextMeshProUGUI

    public AudioSource audioSource; // Referencia al componente AudioSource
    public AudioClip newMusic; // Nueva m�sica que se reproducir�
    private AudioClip previousMusic; // M�sica anterior

    // Start is called before the first frame update
    void Start()
    {
        previousMusic = audioSource.clip;
        LoadData();
    }   

    // Update is called once per frame
    void Update()
    {
        // Si el contador est� activo, incrementar el tiempo y verificar si ha alcanzado la duraci�n deseada
        if (isCounting)
        {
            timer += Time.deltaTime;
            if (timer >= duration)
            {
                if (score > maxScore)
                {
                    maxScore = score; // Actualizar el puntaje m�ximo
                    SaveData(); //Guardar datos
                }
                timer = 0f;
                isCounting = false;
                score = 0;
                EndEvent();
            }
            // Actualizar el texto 
            UpdateText();
        }
    }

    protected override void Interact()
    {
        StartEvent();
        StartTimer();
        Debug.Log("Interacci�n con " + gameObject.name);
    }

    private void StartTimer()
    {
        // Iniciar el contador
        timer = 0f;
        isCounting = true;

        timerText.text = timer.ToString();
        scoreText.text = score.ToString();
        maxScoreText.text = maxScore.ToString();

        // Actualizar el texto 
        UpdateText();
    }

    private void UpdateText()
    {
        // Actualizar el texto del temporizador en la UI con el formato deseado
        timerText.text = "Tiempo: " + timer.ToString("0.00");
        scoreText.text = "Score: " + score.ToString();
        maxScoreText.text = "MaxScore: " + maxScore.ToString(); 
    }

    public void SaveData()
    {
        //Se guarda el dato int con el score maximo
        PlayerPrefs.SetInt("MaxScore", maxScore);

        Debug.Log("Guardando datos....");
    }
    public void LoadData()
    {
        //Se cargan los datos
        maxScore = PlayerPrefs.GetInt("MaxScore");
    }

    public void StartEvent()
    {
        // Cambiar la m�sica al comenzar el evento
        audioSource.clip = newMusic;
        audioSource.Play();
    }
    public void EndEvent()
    {
        // Reanudar la m�sica anterior despu�s de que termine el evento
        audioSource.clip = previousMusic;
        audioSource.Play();
    }

}


