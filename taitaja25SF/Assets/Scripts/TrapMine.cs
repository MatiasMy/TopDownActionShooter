using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrapMine : MonoBehaviour
{
    public int damageAmount = 10; // Amount of damage to apply to the player
    public float damageDelay = 1f; // Delay between taking damage (in case the player stays in contact with the trap)
    private bool canDamage = true; // To control damage frequency

    // Assuming the player has a 'PlayerHealth' script
    private void OnTriggerEnter2D(Collider2D other)
    {
        
        // Check if the object colliding with the trap is the player
        if (other.gameObject.tag == "player")
        {
            // Get the PlayerHealth component from the player

            Debug.LogWarning("Triggered!");
            GameObject.Find("player").GetComponent<playerMovementScript>().gotHit(3);
            Destroy(gameObject);
            

            // Start cooldown to prevent immediate repeated damage
            canDamage = false;
                StartCoroutine(DamageCooldown());
            
        }
    }

    // Cooldown to allow damage only once within a time frame
    private IEnumerator DamageCooldown()
    {
        // Wait for the specified damage delay
        yield return new WaitForSeconds(damageDelay);

        // Allow damage again
        canDamage = true;
    }
}
