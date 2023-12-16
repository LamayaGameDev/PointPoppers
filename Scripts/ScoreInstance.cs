using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using LootLocker.Requests;
using TMPro;
using UnityEngine.UI;
using PlayFab;
using PlayFab.ClientModels;
public class ScoreInstance : MonoBehaviour
{




    public PlayfabManager playfab;

    public int fscore = 0;
    [SerializeField] ParticleSystem ballParticle = null;
    public string ballTag = "Ball"; // tag of the ball game object
    public float minX = -10f;
    public float maxX = 10f;
    public float minY = -10f;
    public float maxY = 10f;
    public float minZ = -10f;
    public float maxZ = 10f;
    [Header("Seocnd set")]
    public float minXx = -10f;
    public float maxXx = 10f;
    public float minYy = -10f;
    public float maxYy = 10f;
    public float minZz = -10f;
    public float maxZz = 10f;
    
    
    public GameObject myPrefab;
    public GameObject multiBall;
    [SerializeField]
    private AudioClip _clip;
    public int scoreAmount = 1;
    // Update is called once per frame
  

    void Start()
    {
        
        
        // float x = Random.Range(minX, maxX);
        // float y = Random.Range(minY, maxY);
        // float z = Random.Range(minZ, maxZ);
        //  Instantiate(myPrefab, new Vector3(x, y, z), Quaternion.identity);
        StartCoroutine(WaitBeforeShow());
        StartCoroutine(WaitBeforeEnd());
        StartCoroutine(dropAtRandom());
    }
 

    public void OnTriggerEnter(Collider other)
    {

        if (other.gameObject.tag == ballTag)
        {
            AudioSource.PlayClipAtPoint(_clip, transform.position);
            Destroy(other.gameObject);
        }
        // check if the colliding game object has the same tag as the ball
        if (other.gameObject.tag == ballTag)
        {

            fscore += scoreAmount;
            ScoreKepper.instance.AddPoint();
            ballParticle.Play();
            Debug.Log("Poop");


        }
    }


    public void instan()
    {
        //wait a couple seconds
        float x = Random.Range(minX, maxX);
        float y = Random.Range(minY, maxY);
        float z = Random.Range(minZ, maxZ);
        Instantiate(myPrefab, new Vector3(x, y, z), Quaternion.identity);
    }
    public void makeBall()
    { 
        //wait a couple seconds
        float w = Random.Range(minXx, maxXx);
        float a = Random.Range(minYy, maxYy);
        float s = Random.Range(minZz, maxZz);
        Instantiate(multiBall, new Vector3(w, a, s), Quaternion.identity);
    }


    public IEnumerator WaitBeforeShow()
    {
        while (true)
        {
            // wait a couple seconds
            yield return new WaitForSeconds(3);

            instan();
        }
    }
    public IEnumerator dropAtRandom()
    {
        while (true)
        {
            // wait a random number of seconds between 4 to 11
            float waitTime = Random.Range(10f, 20f);
            yield return new WaitForSeconds(waitTime);

            // spawn a ball 5 times
           
            
                makeBall();
            
        }
    }
    public IEnumerator WaitBeforeEnd()
    {
       
        
            // wait a couple seconds
            yield return new WaitForSeconds(60);
            playfab.SendLeaderboard(fscore);
           
        
    }


}