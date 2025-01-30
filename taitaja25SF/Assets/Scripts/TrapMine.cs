using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrapMine : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "player")
        {
            GameObject.Find("player").GetComponent<playerMovementScript>().gotHit(3);
            Destroy(gameObject);        
        }
    }
}
