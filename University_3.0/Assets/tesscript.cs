using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class testscript : MonoBehaviour
{
    // Start is called before the first frame update
    public Transform easterobject;
    public LayerMask player;
    private Vector3 scaleChange;
    private GameObject obj;
    private GameObject text;
    TextMesh t;
    void Start()
    {
        text = new GameObject();
        t = text.AddComponent<TextMesh>();
    }
    void FixedUpdate()
    {    
        int maxColliders = 1;
        Collider[] hitColliders = new Collider[maxColliders];      
        int numColliders = Physics.OverlapSphereNonAlloc(easterobject.position, 1, hitColliders,player);
        for (int i = 0; i < numColliders; i++)
        {    
            obj = GameObject.Find("Easter_egg");
             if(obj == null)
             {
               text.name = "Easter_egg";
               text.transform.position = new Vector3(easterobject.position.x,easterobject.position.y-((easterobject.localScale.y)/2),easterobject.position.z);
               
               scaleChange = new Vector3(0.005f,0.005f,0.005f);
               t.transform.localScale = scaleChange;
               t.transform.Rotate(0,180,0);
               t.text = "Készitette: Csapat név";
               t.fontSize = 100;
               t.anchor = TextAnchor.UpperCenter; 
             }
        }
    }
}