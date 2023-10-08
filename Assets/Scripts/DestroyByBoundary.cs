using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyByBoundary : MonoBehaviour
{
    void OnTriggerExit(Collider other)
    {
        // Check if the other object has a Collider component
        if (other.GetComponent<Collider>() != null)
        {
            Destroy(other.gameObject);
        }
    }
}
