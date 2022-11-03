using System.Runtime.Serialization;
using System;
using System.Text;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class healthbar : MonoBehaviour
{

    Slider slider;

    void SetHealth(int health)
    {
        slider.value = health;
    }

    void SetMaxHealth(int health)
    {
        slider.maxValue = health;
        slider.value = health;
    }

    
}
