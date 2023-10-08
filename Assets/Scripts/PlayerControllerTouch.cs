/*using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Boundary
{
    public float xMin, xMax, zMin, zMax;
}

public class PlayerControllerTouch : MonoBehaviour
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

        // Handle touch input
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0); // Get the first touch

            if (touch.phase == TouchPhase.Moved)
            {
                // Calculate the movement based on touch delta position
                Vector3 touchDeltaPosition = touch.deltaPosition;
                Vector3 movement = new Vector3(touchDeltaPosition.x, 0.0f, touchDeltaPosition.y);

                // Apply the movement to the rigidbody
                rb.velocity = movement * speed;
            }
        }
    }

    private void FixedUpdate()
    {
        // Clamp the player's position
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