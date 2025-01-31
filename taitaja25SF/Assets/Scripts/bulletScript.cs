using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bulletScript : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "enemy")
        {
            Destroy(other.gameObject);
            Destroy(gameObject);        
        }
        if (other.gameObject.tag == "bWall")
        {
            Destroy(other.gameObject);
            Destroy(gameObject);        
        }
        if (other.gameObject.tag == "mine")
        {
            Destroy(other.gameObject);
            Destroy(gameObject);        
        }
        if (other.gameObject.layer == 6)
        {
            Destroy(gameObject);        
        }
        if (other.gameObject.tag == "bullet")
        {
            Destroy(other.gameObject);
            Destroy(gameObject);        
        }
    }
}
