﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    public Slider slider;

    public void SetMaxHeath(int health) //set max health
    {
        slider.maxValue = health;
        slider.value = health;
    }


    public void SetHealth(int health) //health
    {
        slider.value = health;
    }
}
