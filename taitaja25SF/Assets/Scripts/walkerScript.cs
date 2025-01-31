using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class walkerScript : MonoBehaviour
{
    private GameObject target;
    public float speed;
    private bool hasLineOfSight = false;
    public Transform rayPos;
    private bool allowedToWalk = true;
    int layerMask;
    void Start()
    {
        target = GameObject.Find("player");
        layerMask = ~LayerMask.GetMask("ignore");
    }

    // Update is called once per frame
    void Update()
    {
        if (hasLineOfSight && allowedToWalk)
        {
            transform.position = Vector3.MoveTowards(transform.position, target.transform.position, speed);
        }
        Vector3 direction = target.transform.position - transform.position;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0, 0, angle);
    }
    private void FixedUpdate()
    {
        Vector2 direction = (target.transform.position - transform.position).normalized;
        float distance = Vector2.Distance(transform.position, target.transform.position);

        RaycastHit2D ray = Physics2D.Raycast(rayPos.position, direction, distance, layerMask);

        if (ray.collider != null)
        {
            print(ray.transform.gameObject.name);
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
    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "player")
        {
            GameObject.Find("player").GetComponent<playerMovementScript>().gotHit(2);

            allowedToWalk = false;
            Invoke("allowWalking", 1.5f);
        }
    }
    public void allowWalking()
    {
        allowedToWalk = true;
    }
}
