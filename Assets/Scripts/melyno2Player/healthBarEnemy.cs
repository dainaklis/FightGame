﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class healthBarEnemy : MonoBehaviour
{
    [SerializeField] private Slider slider;

    [SerializeField] private Gradient gradient;

    [SerializeField] private Image fill;



    public void SetMaxHealthEnemy(int health)
    {
        slider.maxValue = health;
        slider.value = health;

        fill.color = gradient.Evaluate(1f);
    }

    public void SetHealthEnemy( int health)
    {
        slider.value = health;

        fill.color = gradient.Evaluate(slider.normalizedValue);
    }
}
