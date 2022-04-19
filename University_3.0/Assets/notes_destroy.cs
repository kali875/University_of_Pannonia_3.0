using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class notes_destroy : MonoBehaviour
{
    void OnCollisionEnter(Collision col)
    {
        if(col.gameObject.name == "Enemy")
        {
           Destroy(col.gameObject);
        }
    }
}
