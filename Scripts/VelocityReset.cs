using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VelocityReset : MonoBehaviour
{
    
    

   
    





    public void OnTriggerEnter(Collider other)
    
    {
        if (other.gameObject.tag == "Backboard")
        {
            this.GetComponent<BoxCollider>().isTrigger = false;
        }
        else
        {
            
            GetComponent<Rigidbody>().velocity = Vector3.zero;
        }
       
        
    }
   

}
