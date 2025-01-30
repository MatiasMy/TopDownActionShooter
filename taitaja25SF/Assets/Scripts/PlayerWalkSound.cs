using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerWalkSound : MonoBehaviour
{
    public AudioClip footstepSound;
    public float footstepInterval = 0.5f; 
    private float footstepTimer = 0f; 
    private AudioSource audioSource; 
    private bool isWalking = false; 

    private void Start()
    {
        
        audioSource = GetComponent<AudioSource>();
    }

    private void Update()
    {
        isWalking = Mathf.Abs(GetComponent<Rigidbody2D>().velocity.magnitude) > 0.1f;

       
        if (isWalking)
        {
            footstepTimer += Time.deltaTime; 

           
            if (footstepTimer >= footstepInterval)
            {
                PlayFootstepSound();
                footstepTimer = 0f; 
            }
        }
    }


    private void PlayFootstepSound()
    {
        if (audioSource != null && footstepSound != null)
        {
            audioSource.PlayOneShot(footstepSound);
        }
    }
}
