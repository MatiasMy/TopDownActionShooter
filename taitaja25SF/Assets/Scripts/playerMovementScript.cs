using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class playerMovementScript : MonoBehaviour
{
    public float speed = 5f;
    private Rigidbody2D rb;
    private Vector2 moveInput;
    private static float hp;
    private bool alreadyHit = false;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        hp = 10;
    }

    void Update()
    {
        moveInput.x = Input.GetAxis("Horizontal");
        moveInput.y = Input.GetAxis("Vertical");
        moveInput.Normalize();
        rb.velocity = moveInput * speed;

        if (hp < 1)
        {
            SceneManager.LoadScene("GameOverScene");
        }
    }
    public void gotHit(int damage)
    {
        if (alreadyHit)
        {
            return;
        }
        hp = hp - damage;
        GameObject.Find("hpBar").GetComponent<hpBarScript>().ScaleWidth(hp);
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "door")
        {
            SceneManager.LoadScene("lvl2");
        }
        if (other.gameObject.tag == "door2")
        {
            SceneManager.LoadScene("lvl3");
        }
        if (other.gameObject.tag == "door3")
        {
            SceneManager.LoadScene("startGame");
        }
        if (other.gameObject.tag == "mine")
        {
            gotHit(3);
            Destroy(other.gameObject);
            alreadyHit = true;
            Invoke("canGetHit", 1);
        }
    }
    public void canGetHit()
    {
        alreadyHit = false;
    }
}
