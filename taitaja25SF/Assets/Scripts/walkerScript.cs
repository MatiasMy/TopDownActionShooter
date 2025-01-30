using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class walkerScript : MonoBehaviour
{
    private GameObject target;
    public float speed;
    private bool hasLineOfSight = false;
    public Transform rayPos;
    private bool allowdToWalk = true;
    void Start()
    {
        target = GameObject.Find("player");
    }

    // Update is called once per frame
    void Update()
    {
        if (hasLineOfSight && allowdToWalk)
        {
            transform.position = Vector3.MoveTowards(transform.position, target.transform.position, speed);
        }
        Quaternion rotation = Quaternion.LookRotation(target.transform.position - transform.position, transform.TransformDirection(Vector3.up));
        transform.rotation = new Quaternion(0, 0, rotation.z, rotation.w);
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
    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "player")
        {
            GameObject.Find("player").GetComponent<playerMovementScript>().gotHit(2);
            allowdToWalk = false;
            Invoke("allowWalking", 3);
        }
    }
    public void allowWalking()
    {
        allowdToWalk = true;
    }
}
