/*
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Boundary
{
    public float xMin, xMax, zMin, zMax;
}

public class PlayerController : MonoBehaviour
{
    private Rigidbody rb;
    public float speed;
    public float tilt; // Add a tilt variable for ship rotation.
    public Boundary boundary;

    public GameObject shot; // Reference to the shot prefab.
    public Transform shotSpawn;
    public float fireRate;

    private float nextFire = 0.0f; // Initialize nextFire.

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        // Check for firing input and time since the last shot.
        if (Input.GetButton("Fire1") && Time.time > nextFire)
        {
            nextFire = Time.time + fireRate;
            Instantiate(shot, shotSpawn.position, shotSpawn.rotation);
            GetComponent<AudioSource>().Play();
        }
    }

    private void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);
        rb.velocity = movement * speed;

        // Use rb.position instead of rigidbody.position
        rb.position = new Vector3(
            Mathf.Clamp(rb.position.x, boundary.xMin, boundary.xMax),
            0.0f,
            Mathf.Clamp(rb.position.z, boundary.zMin, boundary.zMax)
        );

        // Ship tilting
        rb.rotation = Quaternion.Euler(0.0f, 0.0f, rb.velocity.x * -tilt);
    }
}
*/



using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Boundary
{
    public float xMin, xMax, zMin, zMax;
}

public class PlayerController : MonoBehaviour
{
    private Vector2 touchStartPos; 
    private bool isDragging = false;
    private Rigidbody rb;

    public float speed; 
    public float tilt; 
    public Boundary boundary; 

    // Add other variables 
    public float fireRate;
    public Transform shotSpawn;
    public GameObject shot;

    private float nextFire = 0.0f;

    void Start()
    {
        rb = GetComponent<Rigidbody>(); 
    }

    void Update()
    {
        Vector3 moveDirection = Vector3.zero; // for moveDirection.

        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);

            switch (touch.phase)
            {
                case TouchPhase.Began:
                    touchStartPos = touch.position;
                    isDragging = true;
                    break;

                case TouchPhase.Moved:
                    if (isDragging)
                    {
                        Vector2 touchDelta = touch.position - touchStartPos; // Calculate touchDelta
                        Vector3 newMoveDirection = new Vector3(touchDelta.x / Screen.width, 0.0f, touchDelta.y / Screen.height);

                        //player velocity 
                        rb.velocity = Vector3.Lerp(rb.velocity, newMoveDirection * speed, 0.5f);

                        // Clamp the player position
                        rb.position = new Vector3(
                            Mathf.Clamp(rb.position.x, boundary.xMin, boundary.xMax),
                            0.0f,
                            Mathf.Clamp(rb.position.z, boundary.zMin, boundary.zMax)
                        );

                        // Apply tilt
                        rb.rotation = Quaternion.Euler(0.0f, 0.0f, rb.velocity.x * -tilt);

                        if (Time.time > nextFire)
                        {
                            nextFire = Time.time + fireRate;
                            Instantiate(shot, shotSpawn.position, shotSpawn.rotation);
                            GetComponent<AudioSource>().Play();
                        }
                    }
                    break;

                case TouchPhase.Ended:
                    isDragging = false;
                    rb.velocity = Vector3.zero;
                    break;
            }
        }
        else
        {
            // Reset velocity 
            rb.velocity = Vector3.zero;
        }
    }
}
