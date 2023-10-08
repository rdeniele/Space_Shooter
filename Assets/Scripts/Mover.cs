using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mover : MonoBehaviour
{
    // Define a variable 
    public float speed;
    private Rigidbody rb; 

   
    void Start()
    {
        // Get the Rigidbody
        rb = GetComponent<Rigidbody>();

        // Set the velocity 
        rb.velocity = transform.forward * speed;
    }

}
