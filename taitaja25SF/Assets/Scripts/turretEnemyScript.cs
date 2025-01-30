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

    void Start()
    {
        target = GameObject.Find("player");
    }
    void Update()
    {
        shotTimer += Time.deltaTime;
        if (shotTimer > 1)
        {
            shotTimer = 0;
            shoot();
        }

        Quaternion rotation = Quaternion.LookRotation(target.transform.position - transform.position, transform.TransformDirection(Vector3.up));
        transform.rotation = new Quaternion(0, 0, rotation.z, rotation.w);
    }
    public void shoot()
    {
        if (hasLineOfSight)
        {
            Instantiate(bullet, shootPos.position, Quaternion.identity);
        }
    }
    private void FixedUpdate()
    {
        Vector2 direction = (target.transform.position - transform.position).normalized;
        float distance = Vector2.Distance(transform.position, target.transform.position);

        RaycastHit2D ray = Physics2D.Raycast(rayPos.position, direction);
        Debug.Log(ray);

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
