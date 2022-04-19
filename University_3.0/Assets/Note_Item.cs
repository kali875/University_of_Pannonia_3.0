using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Note_Item : MonoBehaviour
{
    public GameObject other;
    public GameObject target;
    public float check_teritory;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float currentDistance = Vector3.Distance(transform.position, target.transform.position);
            if (currentDistance < check_teritory)
            {
                target.GetComponent<Playerhealth>().set_count(1); 
                other.GetComponent<player_attack>().set_count(1);
                Destroy(this.gameObject);
            }
        
    }
    void OnCollisionEnter(Collision col)
    {
        if(col.gameObject.name == "player" )
        {
            other.GetComponent<Playerhealth>().set_count(1);
            Destroy(this.gameObject);
        }
    }
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(transform.position, check_teritory);
    }
}
