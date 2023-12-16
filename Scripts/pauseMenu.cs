using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class pauseMenu : MonoBehaviour
{
    public static bool GameIsPaused = false;
    public GameObject pauseUI;
     public GameObject cursor;
  
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (GameIsPaused)
            {
                Resume();
            } else 
            {
                Pause();
            }
        } 

    }

    public void Resume()
    {
        pauseUI.SetActive(false);
        Time.timeScale = 1f;
        GameIsPaused = false;
        Cursor.lockState = CursorLockMode.Locked;
        cursor.SetActive(true);

    }
    public void Pause()
    {
        pauseUI.SetActive(true);
        Time.timeScale = 0f;
        GameIsPaused = true;
        Cursor.lockState = CursorLockMode.None;
        cursor.SetActive(false);

    }

    public void LoadMenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("StartMenu");
    }
    public void QuitGame()
    {
        Debug.Log("Qutiting game");
        Application.Quit();
    }
    public void LoadGame()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("GameScene");
       
}
}
