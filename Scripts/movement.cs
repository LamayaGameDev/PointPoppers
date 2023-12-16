using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movement : MonoBehaviour
{
    
    private Rigidbody rb;
    public float speed = 5f, sensitivity = 2f, jumpforce = 2f;

    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        rb = gameObject.GetComponent<Rigidbody>();
    }

    private void Update()
    {

        
    }

    private void FixedUpdate()
    {
        //Movement
        Vector2 axis = new Vector2(Input.GetAxis("Vertical"), Input.GetAxis("Horizontal")) * speed;
        Vector3 forward = new Vector3(-Camera.main.transform.right.z, 0, Camera.main.transform.right.x);
        Vector3 wishDirection = (forward * axis.x + Camera.main.transform.right * axis.y + Vector3.up * rb.velocity.y);
        rb.velocity = wishDirection;
    }

}
