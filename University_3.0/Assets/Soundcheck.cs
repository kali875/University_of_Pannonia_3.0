using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;


public class Soundcheck : MonoBehaviour
{
    public Transform groundcheck;
    public float groundDistance = 0.4f;
    public LayerMask groundMask;
    public VideoPlayer video;

    public bool isGrounded;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        isGrounded = Physics.CheckSphere(groundcheck.position, groundDistance, groundMask);

        if (isGrounded == true)
        {
            video.Play();
        }
        else 
        {
            video.Pause();
        }
    }
}
