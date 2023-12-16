using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class SliderForceBar : MonoBehaviour
{
    public Slider slider;
    // The force with which the basketball will be shot
    public float shotForce = 1000f;
    // The force with which the basketball will be shot UPwards
    public float UPshotForce = 1000f;
    // the speed the UPwards shot force increasesw
    public float UPshotIncrease = 5000f;
    // The transforms of the dribbling and overhead holding positions



    // The speed at which the player moves
    public float MoveSpeed = 10f;
    // total shot force
    public float TotalshotForce = 10f;
    // the speed the shot force increasesw
    public float shotIncrease = 5000;
    // the minimum shot force
    public float minShot = 0f;
    // the max shot force
    public float maxShot = 5000f;
    // the minimum up shot force
    public float UPminShot = 0f;
    // the max up shot force
    public float UPmaxShot = 5000f;
    // Variables for ball state
    private bool IsBallInHands = true;
    private bool IsBallFlying = false;
    private float T = 0;
    // list of basketball game objects currently in the player's hands
    private List<GameObject> basketballs = new List<GameObject>();
    void Start()
    {
        slider = GetComponent<Slider>();
    }
    // Update is called once per frame
    public void Update()
    {
        

        // Check if the ball is in the player's hands
    





    }
    public void sliderUpdate(float shotForces)
    {
        
        if (IsBallInHands)
        {
            // Hold the ball over head
            if (Input.GetKey(KeyCode.Mouse0))
            {

                shotForce += shotIncrease * Time.deltaTime;

                UPshotForce += UPshotIncrease * Time.deltaTime;


                UPshotForce = Mathf.Clamp(shotForce, UPminShot, UPmaxShot);

                shotForce = Mathf.Clamp(shotForce, minShot, maxShot);

                // Aim the shot by rotating the player towards the mouse cursor

            }

           

            // Shoot the ball when the mouse button is released
            if (Input.GetKeyUp(KeyCode.Mouse0))
            {


                if (Input.GetKeyUp(KeyCode.Mouse0))
                {



                    shotForce = minShot;

                    UPshotForce = UPminShot;
                }
            }

         



        }
        shotForce = slider.value;
    }



}




