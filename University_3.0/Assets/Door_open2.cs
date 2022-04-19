using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door_open2 : MonoBehaviour
{
    public float speed = 1.0f;
    public Transform groundcheck;
    public Transform elevator1;
    public Transform elevator2;
    public float groundDistance = 0.4f;
    public LayerMask groundMask;

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
            //elevator move
            Vector3 newPos1 = new Vector3(78.131f, elevator1.transform.position.y, elevator1.transform.position.z);
            Vector3 newPos2 = new Vector3(80.772f, elevator2.transform.position.y, elevator2.transform.position.z);
            elevator1.transform.position = Vector3.Lerp(elevator1.transform.position, newPos1, Time.deltaTime * speed);
            elevator2.transform.position = Vector3.Lerp(elevator2.transform.position, newPos2, Time.deltaTime * speed);

        }
        else
        {
            Vector3 newPos1 = new Vector3(79.0079f, elevator1.transform.position.y, elevator1.transform.position.z);
            Vector3 newPos2 = new Vector3(79.9674f, elevator2.transform.position.y, elevator2.transform.position.z);
            elevator1.transform.position = Vector3.Lerp(elevator1.transform.position, newPos1, Time.deltaTime * speed);
            elevator2.transform.position = Vector3.Lerp(elevator2.transform.position, newPos2, Time.deltaTime * speed);
        }
    }
}
