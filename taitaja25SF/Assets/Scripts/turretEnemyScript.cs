using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class turretEnemyScript : MonoBehaviour
{
    public GameObject bullet;
    public Transform shootPos;
    public Transform rayPos;
    private float shotTimer;
    private GameObject target;
    private bool hasLineOfSight = false;
    private float range;
    private float distance;
    private bool allowedToWalk;
    public float speed;

    void Start()
    {
        target = GameObject.Find("player");
        range = 10f;
    }
    void Update()
    {
        distance = Vector2.Distance(transform.position, target.transform.position);
        Debug.Log(distance);
        shotTimer += Time.deltaTime;
        if (shotTimer > 1)
        {
            shotTimer = 0;
            shoot();
        }

        if (distance > range)
        {
            allowedToWalk = true;
        }
        else
        {
            allowedToWalk = false;
        }

        if (hasLineOfSight && allowedToWalk)
        {
            transform.position = Vector3.MoveTowards(transform.position, target.transform.position, speed);
        }

        Vector3 direction = target.transform.position - transform.position;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0, 0, angle);
    }
    public void shoot()
    {
        if (hasLineOfSight && !allowedToWalk)
        {
            Instantiate(bullet, shootPos.position, Quaternion.identity);
        }
    }
    private void FixedUpdate()
    {
        Vector2 direction = (target.transform.position - transform.position).normalized;
        float distance = Vector2.Distance(transform.position, target.transform.position);

        RaycastHit2D ray = Physics2D.Raycast(rayPos.position, direction);

        if (ray.collider != null)
        {
            if (ray.transform.gameObject.tag == "player")
            {
                hasLineOfSight = true;
            }
            else
            {
                hasLineOfSight = false;
            }

            Debug.DrawRay(transform.position, direction * distance, hasLineOfSight ? Color.green : Color.red);
        }
    }
}
