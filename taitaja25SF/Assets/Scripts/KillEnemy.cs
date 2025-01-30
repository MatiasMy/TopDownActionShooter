using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillEnemy : MonoBehaviour
{
    public AudioClip deathSound; // The sound to play when the enemy is destroyed
    private AudioSource audioSource; // Reference to the AudioSource component

    private void Start()
    {
        // Get the AudioSource component attached to the same GameObject
        audioSource = GetComponent<AudioSource>();
    }

    // This method is triggered when the prefab collides with another object
    private void OnCollisionEnter2D(Collision2D collision)
    {
        // Check if the object the prefab collides with has the "BreakableWall" tag
        if (collision.gameObject.CompareTag("BreakableWall"))
        {
            Debug.LogWarning("Triggered");

            // Play the death sound before destroying the objects
            if (audioSource != null && deathSound != null)
            {
                audioSource.PlayOneShot(deathSound); // Play the sound once
            }

            // Destroy the BreakableWall object
            Destroy(collision.gameObject);

            // Destroy the prefab (this script's attached object)
            Destroy(gameObject);
        }
    }
}
