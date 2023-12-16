using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ScoreKepper : MonoBehaviour
{
    public TMP_Text scoreText;
    
    public static ScoreKepper instance;
    public int scoref = 0;
    
    int highscore = 0;
    
    private void Awake()
    {
        instance = this;
    }
   

    public void Start()
    {
        highscore = PlayerPrefs.GetInt("highscore", 0);
        scoreText.text = scoref.ToString() + " POINTS";
    }

   
    
    
    public void AddPoint()
    {
        scoref += 1;
        scoreText.text = scoref.ToString() + " POINTS";
       

        if (highscore < scoref)
                    PlayerPrefs.SetInt("highscore", scoref);
       
        

    }
}
