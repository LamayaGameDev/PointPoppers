using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Rigidbody))]

public class Jump : MonoBehaviour
{

    public float jumpSpeed = 100.0f;
    private bool isOnGround = false;

    Rigidbody rb;
    // Use this for initialization
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        isOnGround = true;
    }

    float movementSpeed;
    // Update is called once per frame
    void Update()
    {
        float amountToMove = movementSpeed * Time.deltaTime;
        Vector3 movement = (Input.GetAxis("Horizontal") * -Vector3.left * amountToMove) + (Input.GetAxis("Vertical") * Vector3.forward * amountToMove);
        rb.AddForce(movement, ForceMode.Force);

        if (isOnGround && Input.GetKeyDown("space") )
        {
            rb.AddForce(Vector3.up * jumpSpeed);
            isOnGround = false;
        }
        else
        {
            rb.AddForce(Vector3.up * 0);
        }


    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "floor")
        {
            isOnGround = true;
        }
    }

}