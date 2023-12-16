using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class GameStart : MonoBehaviour
{
    public int countdownTime;
    public TMP_Text countdownText;
    public string startText;
    public GameObject gameTime;
    public GameObject score;
    public GameObject cursor;
    public GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        cursor.SetActive(false);
        gameTime.SetActive(false);
        score.SetActive(false);
        player.SetActive(false);
        StartCoroutine(WaitBeforeStart());

    }

    // Update is called once per frame
    void Update()
    {

    }

    public IEnumerator WaitBeforeStart()
    {
        while (countdownTime > 0)
        {
            cursor.SetActive(false);
            gameTime.SetActive(false);
            score.SetActive(false);
            player.SetActive(false);
            countdownText.text = countdownTime.ToString();

            yield return new WaitForSeconds(1f);

            countdownTime--;
        }

        countdownText.text = startText;

        yield return new WaitForSeconds(1f);
        countdownText.gameObject.SetActive(false);
        cursor.SetActive(true);
        gameTime.SetActive(true);
        score.SetActive(true);
        player.SetActive(true);
    }

}
