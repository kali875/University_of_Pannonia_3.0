using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class move : MonoBehaviour
{
    public float speed = 1.0f;
    public Transform groundcheck;
    public Transform elevator;
    public float groundDistance = 0.4f;
    public LayerMask groundMask;

    public bool isGrounded;
    
    List<GameObject> selected = new List<GameObject>();
    
    GameObject[] enemy;
    GameObject[] enemy1;
    GameObject[] enemy2;
    GameObject[] enemy3;
    GameObject[] enemy4;
    GameObject[] enemy5;
    GameObject[] enemy6;

    void Start()
    {
        enemy = GameObject.FindGameObjectsWithTag("Enemy");
        enemy1 = GameObject.FindGameObjectsWithTag("Enemy1");
        enemy2 = GameObject.FindGameObjectsWithTag("Enemy2");
        enemy3 = GameObject.FindGameObjectsWithTag("Enemy3");
        enemy4 = GameObject.FindGameObjectsWithTag("Enemy4");
        enemy5 = GameObject.FindGameObjectsWithTag("Enemy5");
        enemy6 = GameObject.FindGameObjectsWithTag("Enemy6");
    }

    // Update is called once per frame
    void Update()
    {
         if(allenemyf() == true)
         {
            isGrounded = Physics.CheckSphere(groundcheck.position, groundDistance, groundMask);

                if (isGrounded == true)
                {
                    //elevator move
                    Vector3 newPos = new Vector3(transform.position.x, 42.5f, transform.position.z);
                    transform.position = Vector3.Lerp(transform.position, newPos, Time.deltaTime * speed);

                }
            if( allenemy1() == true)
            {
                //isGrounded = Physics.CheckSphere(groundcheck.position, groundDistance, groundMask);

                    if (isGrounded == true)
                    {
                        //elevator move
                        Vector3 newPos = new Vector3(transform.position.x, 46.5f, transform.position.z);
                        transform.position = Vector3.Lerp(transform.position, newPos, Time.deltaTime * speed);

                    }
            }
         }


    }
    bool allenemyf()
    {
        enemy = GameObject.FindGameObjectsWithTag("Enemy");
        foreach (GameObject r in enemy)
        {
            
            if(GameObject.Find(r.name) != null)
            {
                //Debug.Log(r.name);
                return false;
            }
        }
        return true;
    }
    bool allenemy1()
    {
        enemy = GameObject.FindGameObjectsWithTag("Enemy1");
        foreach (GameObject r in enemy)
        {
            
            if(GameObject.Find(r.name) != null)
            {
                //Debug.Log(r.name);
                return false;
            }
        }
        return true;
    }
    bool allenemy2()
    {
        enemy = GameObject.FindGameObjectsWithTag("Enemy2");
        foreach (GameObject r in enemy)
        {
            
            if(GameObject.Find(r.name) != null)
            {
                //Debug.Log(r.name);
                return false;
            }
        }
        return true;
    }
    bool allenemy3()
    {
        enemy = GameObject.FindGameObjectsWithTag("Enemy3");
        foreach (GameObject r in enemy)
        {
            
            if(GameObject.Find(r.name) != null)
            {
                //Debug.Log(r.name);
                return false;
            }
        }
        return true;
    }
    bool allenemy4()
    {
        enemy = GameObject.FindGameObjectsWithTag("Enemy4");
        foreach (GameObject r in enemy)
        {
            
            if(GameObject.Find(r.name) != null)
            {
                //Debug.Log(r.name);
                return false;
            }
        }
        return true;
    }
    bool allenemy5()
    {
        enemy = GameObject.FindGameObjectsWithTag("Enemy5");
        foreach (GameObject r in enemy)
        {
            
            if(GameObject.Find(r.name) != null)
            {
                //Debug.Log(r.name);
                return false;
            }
        }
        return true;
    }
    bool allenemy6()
    {
        enemy = GameObject.FindGameObjectsWithTag("Enemy6");
        foreach (GameObject r in enemy)
        {
            
            if(GameObject.Find(r.name) != null)
            {
                //Debug.Log(r.name);
                return false;
            }
        }
        return true;
    }
    
}
