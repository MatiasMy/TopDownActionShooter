using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class turretEnemyScript : MonoBehaviour
{
    public GameObject bullet;
    public Transform shootPos;
    private float shotTimer;

    void Start()
    {
        
    }
    void Update()
    {
        shotTimer += Time.deltaTime;
        if (shotTimer > 2)
        {
            shotTimer = 0;
            shoot();
        }
    }
    public void shoot()
    {
        Instantiate(bullet, shootPos.position, Quaternion.identity);
    }
}
