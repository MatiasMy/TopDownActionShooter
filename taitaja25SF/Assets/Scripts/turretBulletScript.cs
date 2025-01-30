using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class turretBulletScript : MonoBehaviour
{
    private GameObject target;
    private Rigidbody2D rb;
    public float force;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        target = GameObject.Find("player");
        Vector3 direction = target.transform.position - transform.position;
        rb.velocity = new Vector2(direction.x, direction.y).normalized * force;

        float rot = Mathf.Atan2(-direction.y, -direction.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0, 0 , rot + 90);
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "player")
        {
            Debug.Log("osui");
            GameObject.Find("player").GetComponent<playerMovementScript>().gotHit();
        }
    }
}
