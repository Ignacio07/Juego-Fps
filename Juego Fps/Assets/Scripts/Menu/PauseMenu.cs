using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public bool GameIsPaused = false;
    public GameObject pauseMenuUI;
    public GameObject playerHUD;
    public Animator transition;
    public float transitionTime = 1f;
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked; // Bloquear el cursor en el centro
        Cursor.visible = false; // Hacer el cursor invisible
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if(GameIsPaused)
            {
                Resume();
            }else
            {
                Pause();
            }
        }
    }
    public void Resume()
    {
        Cursor.lockState = CursorLockMode.Locked; // Bloquear el cursor en el centro
        Cursor.visible = false; // Hacer el cursor invisible
        pauseMenuUI.SetActive(false);
        playerHUD.SetActive(true);
        Time.timeScale = 1f;
        GameIsPaused = false;
    }
    public void Pause()
    {
        Cursor.lockState = CursorLockMode.None; // Desbloquear el cursor
        Cursor.visible = true; // Hacer el cursor visible
        pauseMenuUI.SetActive(true);
        playerHUD.SetActive(false);
        Time.timeScale = 0f;
        GameIsPaused = true;
    }
    public void ReturnMainMenu()
    {
        SceneManager.LoadScene("Menu");
        Time.timeScale = 1f;
    }
    public void QuitGame()
    {
        Debug.Log("Salir!!");
        Application.Quit();
    }
}
