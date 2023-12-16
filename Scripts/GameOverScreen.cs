using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class GameOverScreen : MonoBehaviour
{
    public TMP_Text pointsText;
    public TMP_Text scoreText;
    public int scoreFinal;
    public ScoreKepper scoreKeeper;
    public GameObject leaderboardWindow;
    
    public void Start()
    {
        leaderboardWindow.SetActive(false);
        scoreFinal = scoreKeeper.scoref;
        
    }
    
   
     public void Update()
     {
        scoreFinal = scoreKeeper.scoref;
        
        pointsText.text = scoreFinal.ToString() + " POINTS";
    } 
}
