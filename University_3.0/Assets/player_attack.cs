using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player_attack : MonoBehaviour
{

    public GameObject Note;
    public GameObject attack_start;
    public GameObject Camera; 
    public float fireRate = 0.5F;
    public float nextfire = 0.0f;

    public int count=0;
    public GameObject Note_score;
    // Start is called before the first frame update
    void Start()
    {
        
    }
    public int set_count(int value)
    {
       count = count+value;
       return count;
    } 
    public void set_minus_count()
    {
         count--;
         Note_score.GetComponent<Playerhealth>().set_minus_count();
    }
    // Update is called once per frame
    void Update()
    {       
           if(Input.GetMouseButtonDown(0) && count > 0)
           {  
             if(Time.time > nextfire)
             {
               nextfire = Time.time + fireRate;

                GameObject  Note_copy = Instantiate(Note, attack_start.transform.position,Quaternion.identity);
                Note_copy.AddComponent<Rigidbody>();
                //Note_copy.AddComponent<notes_destroy>();
                Note_copy.GetComponent<Rigidbody>().AddForce(Camera.transform.forward * 30f, ForceMode.Impulse);
                //Note_copy.GetComponent<Rigidbody>().AddForce(transform.up * 3f, ForceMode.Impulse);  
                set_minus_count();
                StartCoroutine(ExampleCoroutine(Note_copy));
             }      

           }
    }
    IEnumerator ExampleCoroutine(GameObject Note)
    {
        yield return new WaitForSeconds(5);
        Destroy(Note);
    }
}
