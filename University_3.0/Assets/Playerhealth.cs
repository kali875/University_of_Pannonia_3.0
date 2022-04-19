using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using System.Threading;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Playerhealth : MonoBehaviour
{
    public GameObject player;
    public Text Game_over;
    public float waitrate = 0.5f;
    public float wait = 0.0f;

    public Image healthbar;

    public float maxHealth = 12f;
    public float currentHealth;
    
    public Text Note_score;
    private int count=0;

    public float timeRemaining = 10;

    private int  help=0;
    void Start()
    {
        currentHealth = maxHealth;
        UpdateHealthBar();
        //UpdateManaBar();
    }
    public int set_count(int value)
    {
        Debug.Log("set_count");
       count = count+value;
       Note_score.text  =  count.ToString();
       return count;
    }
    public void set_minus_count()
    {
        count--;
        Note_score.text  =  count.ToString();
    }
    // Update is called once per frame
    void Update()
    {
        health_check();
    }
    void UpdateHealthBar()
    {
        healthbar.fillAmount = currentHealth / maxHealth;
    }
    void OnCollisionEnter(Collision col)
    {
        if(col.gameObject.name == "ZH" || col.gameObject.name == "ZH(Clone)" )
        {
             currentHealth -= 1f;
             UpdateHealthBar();
        }
    }
    void health_check()
    {
        
        if( 0 >= currentHealth)
        {
            if(help == 0)
            {
                Destroy(GetComponent<Player_Movement>());
                help = 1;
            }
            Game_over.text = "Game Over :(";
            
            if(timeRemaining > 0)
            {
                timeRemaining -= Time.deltaTime;
            } 
            else
            {
                SceneManager.LoadScene("MainMenu");  
            }            
        }
        

    }
}
