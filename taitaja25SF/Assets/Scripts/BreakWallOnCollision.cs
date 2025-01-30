using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BreakWallOnCollision : MonoBehaviour
{
    // This method is triggered when the prefab collides with another object
    private void OnCollisionEnter2D(Collision2D collision)
    {
        // Check if the object the prefab collides with has the "BreakableWall" tag
        if (collision.gameObject.CompareTag("BreakableWall"))
            Debug.LogWarning("Triggered");
        {
            // Destroy the BreakableWall object
            Destroy(collision.gameObject);

            // Destroy the prefab (this script's attached object)
            Destroy(gameObject);
        }
    }
}
