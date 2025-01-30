using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class turretBullet2Script : MonoBehaviour
{
    private GameObject target;
    private Rigidbody2D rb;
    public float force;
    private bool hitWall = false;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        target = GameObject.Find("player");
        Vector3 direction = target.transform.position - transform.position;
        rb.velocity = new Vector2(direction.x, direction.y).normalized * force;

        float rot = Mathf.Atan2(-direction.y, -direction.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0, 0, rot + 90);
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "player")
        {
            GameObject.Find("player").GetComponent<playerMovementScript>().gotHit(1);
        }
        if (col.gameObject.layer == 6)
        {
            if (!hitWall)
            {
                Vector3 direction = target.transform.position - transform.position;
                rb.velocity = new Vector2(direction.x, direction.y).normalized * force;

                float rot = Mathf.Atan2(-direction.y, -direction.x) * Mathf.Rad2Deg;
                transform.rotation = Quaternion.Euler(0, 0, rot + 90);
                hitWall = true;
            }
            else
            {
                Destroy(gameObject);
            }
        }
    }
}
