using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class easteregg : MonoBehaviour
{
    // Start is called before the first frame update
    public Transform easterobject;
    public LayerMask player;
    private Vector3 scaleChange;
    private GameObject obj;
    private GameObject text;
    public string name;
    private TextMesh t;
    private bool coll=false;
    void Start()
    {
        text = new GameObject();
        t = text.AddComponent<TextMesh>();
    }
    void Update()
    {    
        if(Physics.CheckSphere(easterobject.position, 2,player))
        {
            obj = GameObject.Find("Easter_egg");
            if(obj == null)
            {
               coll = true;
               text.name = "Easter_egg";
               text.transform.position = new Vector3(easterobject.position.x,easterobject.position.y-((easterobject.localScale.y)/2),easterobject.position.z);
               
               scaleChange = new Vector3(0.005f,0.005f,0.005f);
               t.transform.localScale = scaleChange;
               t.text = name;
               t.fontSize = 100;
               t.anchor = TextAnchor.UpperCenter; 
            }
            else
            {
               text.GetComponent<Renderer>().enabled = true;   
            }
        }
        else
        {
            GameObject help = GameObject.Find("Easter_egg");
            if(help != null)
            {
                text.GetComponent<Renderer>().enabled = false;        
            }
        }
    }
}
