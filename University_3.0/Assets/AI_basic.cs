using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using System.Collections;

public class AI_basic : MonoBehaviour {

   
    //AI alapvető tulajdonságai
    // Egy vectorral tudjuk számolni milyen mesze van játékos és bizonyos distancenél kulonbozo képpen reagál rá
    public GameObject target;
    public GameObject ZH;
    public float attackDistance;
    public float teritory;
    public float moveSpeed;
    private NavMeshAgent agent;
    
    //ZH mint lövedék
    public GameObject attack_start; 
    public Vector3 zh_scaleChange;
    public float fireRate = 0.5F;
    public float nextfire = 0.0f;
    
    //támadás,látószög
    public LayerMask raycastlayer;
    public RaycastHit hit;


    // támadás,érzékelés és kitérés
    public LayerMask note;
    public float defend_distance;
    RaycastHit defend_hit;


    //élet és destroy
    public float heal;
    //hang efektek, ha az ütközésen bellül van akkor elindul a zene különben leáll.
    public AudioSource sound;
    void Start ()
    {
        agent = GetComponent<NavMeshAgent>();
        sound = GetComponent<AudioSource>();
	}
	
	
	void Update ()
    {
        float currentDistance = Vector3.Distance(transform.position, target.transform.position);
        
        if (currentDistance < attackDistance)
        {
            sound.Play();
            transform.LookAt(target.transform);   
            attack(); 
            if( currentDistance < defend_distance )
            {
                 agent.Move(target.transform.forward * moveSpeed * Time.deltaTime);
            } 
        }
        if(teritory > currentDistance)
        {   
            //sound.PlayOneShot();
            sound.Play();
            agent.SetDestination(target.transform.position);
          
        }      
        else
        {
            sound.Pause();
        }

    }
    void attack()
    {       
        if(Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward),out hit, 10f))
        {
            /*Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * hit.distance, Color.yellow);
            Debug.Log("utk" + hit.collider.name);*/
            
              if(hit.collider.name == "player")
              {
                if(Time.time > nextfire)
                {
                  nextfire = Time.time + fireRate;       
          
                  GameObject  zh_copy = Instantiate(ZH, attack_start.transform.position,Quaternion.identity);
                  zh_copy.AddComponent<Rigidbody>();
                  zh_copy.GetComponent<Rigidbody>().AddForce(transform.forward * 30f, ForceMode.Impulse);
                  zh_copy.GetComponent<Rigidbody>().AddForce(transform.up * 3f, ForceMode.Impulse);  
                  StartCoroutine(ExampleCoroutine(zh_copy));
                }
              }
        }
        else
        {

        }
    }
    IEnumerator ExampleCoroutine(GameObject zh)
    {
        yield return new WaitForSeconds(5);
        Destroy(zh);
    }
   
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, attackDistance);
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, teritory);
        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(transform.position, defend_distance);
    }
    void OnCollisionEnter(Collision col)
    {
        if(col.gameObject.name == "Note" ||  col.gameObject.name == "Note(Clone)" )
        {
           heal -= 1;
            if(heal == 0)
            {
                Destroy(this.gameObject);
            } 
        }

    }
}
