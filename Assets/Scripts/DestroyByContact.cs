using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyByContact : MonoBehaviour
{
    public GameObject explosion;
    public GameObject playerExplosion;
    public int scoreValue;
    private GameController gameController; // Assuming you have a GameController script

    void Start()
    {
        // Fix the typo in the following line (gameControllerObject should not be uppercase)
        GameObject gameControllerObject = GameObject.FindWithTag("GameController");

        if (gameControllerObject != null)
        {
            // Fix the typo in the GetComponent line (gameController should not be lowercase)
            gameController = gameControllerObject.GetComponent<GameController>();
        }
        else
        {
            Debug.Log("Cannot Find 'GameController' GameObject with the 'GameController' tag");
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Boundary"))
        {
            return;
        }

        if (other.CompareTag("Player"))
        {
            Instantiate(playerExplosion, other.transform.position, other.transform.rotation);
            gameController.GameOver();
        }
        else if (other.GetComponent<Rigidbody>() != null)
        {
            Instantiate(explosion, other.transform.position, other.transform.rotation);
        }

        // You should call AddScore on the GameController script, not directly on GameController
        gameController.AddScore(scoreValue);

        Destroy(other.gameObject);
        Destroy(gameObject); // If you want to destroy the script's GameObject
    }
}
