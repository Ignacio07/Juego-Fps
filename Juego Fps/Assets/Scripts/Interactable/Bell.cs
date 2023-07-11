using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;


public class Bell : Interactable
{
    private bool isCounting = false;
    private float timer = 0f;
    public float duration = 5f; // Duración del contador en segundos
    public TextMeshProUGUI timerText; // Referencia al objeto TextMeshProUGUI

    private int score = 0;
    public int maxScore = 0;
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI maxScoreText;

    // Start is called before the first frame update
    void Start()
    {
     
        

        
    }   

    // Update is called once per frame
    void Update()
    {
        // Verificar si se ha presionado la tecla "E" y comenzar el contador
        if (Input.GetKeyDown(KeyCode.E))
        {
            StartTimer();
           
        }

        // Si el contador está activo, incrementar el tiempo y verificar si ha alcanzado la duración deseada
        if (isCounting)
        {
            timer += Time.deltaTime;

            // Actualizar el texto del temporizador en la UI
            UpdateText();

            if (timer >= duration)
            {
                AddScore();
                timer = 0f;
                isCounting = false;
            }
            
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

        // Actualizar el texto del temporizador en la UI
        UpdateText();
    }

    private void UpdateText()
    {
        // Actualizar el texto del temporizador en la UI con el formato deseado
        timerText.text = "Tiempo: " + timer.ToString("0.00");
        scoreText.text = "Score: " + score.ToString();
        maxScoreText.text = "MaxScore: " + maxScore.ToString(); 
    }
    private void AddScore()
    {
        score++; // Aumentar el puntaje en 1

        // Verificar si se ha superado el puntaje máximo
        if (score > maxScore)
        {
            maxScore = score; // Actualizar el puntaje máximo
        }

        Debug.Log("Puntaje: " + score);
        Debug.Log("Puntaje máximo: " + maxScore);
    }

}


