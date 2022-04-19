using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;
using UnityEngine.UI;

public class healthbarscript : MonoBehaviour
{
    // Start is called before the first frame update

    public Slider slider;
    public Gradient gradient;
    public Image fill;

    public void SetMaxHealth( int health ) 
    {
        slider.maxValue = health;
        slider.value = health;

        fill.color = gradient.Evaluate(1f);
    }
    public void SetHealth( int health ) 
    {
        slider.value = health;
        fill.color = gradient.Evaluate(slider.normalizedValue);
    }
}
