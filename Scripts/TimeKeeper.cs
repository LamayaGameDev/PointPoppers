using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;
public class TimeKeeper : MonoBehaviour
{
    public GameObject camMain;
    public float timeRemaining = 60;
    public TMP_Text timeText;
    public TMP_Text timeP;
    public GameObject scoreDouble;
    public TMP_Text scoreP;
    public TMP_Text scoreText;
    public GameObject notThis;
    public GameObject player;
    public GameObject ball;
    public Camera cam;
    public GameObject pauseMenu;
    public GameObject cursor;
    public GameObject usernameInputPanel;
    public GameObject gameOverPanel;
    void Start()
    {
        notThis.SetActive(false);
        ball.SetActive(true);
        scoreDouble.SetActive(true);
        player.SetActive(true);
        scoreText.enabled = true;
        timeText.enabled = true;
        timeP.enabled = true;
        scoreP.enabled = true;
        cursor.SetActive(true);
        usernameInputPanel.SetActive(false);
        gameOverPanel.SetActive(false);
        Cursor.lockState = CursorLockMode.Locked;
        timeText.text = timeRemaining.ToString();
        
    }


    void Update()
    {
        if (timeRemaining > 0)
        {
            timeText.text = timeRemaining.ToString("F1");
            timeRemaining -= Time.deltaTime;
            usernameInputPanel.SetActive(false);

        }
        else 
        {
            usernameInputPanel.SetActive(true);
            ball.SetActive(false);
            scoreDouble.SetActive(false);
            player.SetActive(false);
            notThis.SetActive(true);
            scoreText.enabled = false;
            timeText.enabled = false;
            timeP.enabled = false;
            pauseMenu.SetActive(false);
            scoreP.enabled = false;
            cursor.SetActive(false);
            
            Cursor.lockState = CursorLockMode.None;
            (camMain.GetComponent(typeof(CamLook)) as CamLook).enabled = false;


        }
        

        
    }
    
}
