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
    public float hp;
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

        hp = hp - damage;
        GameObject.Find("hpBar").GetComponent<hpBarScript>().ScaleWidth(hp);
    }
}
