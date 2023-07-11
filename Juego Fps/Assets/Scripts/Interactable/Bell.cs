using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;


public class Bell : Interactable
{
    private bool isCounting = false;
    public float timer = 0f;
    public float duration = 5f; // Duración del contador en segundos
    public TextMeshProUGUI timerText; // Referencia al objeto TextMeshProUGUI

    public int score = 0;
    public int maxScore = 0;
    public TextMeshProUGUI scoreText; // Referencia al objeto TextMeshProUGUI
    public TextMeshProUGUI maxScoreText; // Referencia al objeto TextMeshProUGUI

    public AudioSource audioSource; // Referencia al componente AudioSource
    public AudioClip newMusic; // Nueva música que se reproducirá
    private AudioClip previousMusic; // Música anterior

    // Start is called before the first frame update
    void Start()
    {
        previousMusic = audioSource.clip;
        LoadData();
    }   

    // Update is called once per frame
    void Update()
    {
        // Verificar si se ha presionado la tecla "E" y comenzar 
        if (Input.GetKeyDown(KeyCode.E))
        {
            StartEvent();
            StartTimer();
           
        }

        // Si el contador está activo, incrementar el tiempo y verificar si ha alcanzado la duración deseada
        if (isCounting)
        {
            timer += Time.deltaTime;
            if (timer >= duration)
            {
                if (score > maxScore)
                {
                    maxScore = score; // Actualizar el puntaje máximo
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
        Debug.Log("Interacción con " + gameObject.name);
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
        // Cambiar la música al comenzar el evento
        audioSource.clip = newMusic;
        audioSource.Play();
    }
    public void EndEvent()
    {
        // Reanudar la música anterior después de que termine el evento
        audioSource.clip = previousMusic;
        audioSource.Play();
    }

}


