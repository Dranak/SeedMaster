using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Spirit : MonoBehaviour
{
    public float Life { get; set; }
    public float LifeMax = 100;
    public bool IsDead { get; set; }
    public Image LifeBar;
    void Start()
    {
        Life = LifeMax;
        IsDead = false;
    }

     void Update()
    {
        
        if(Life<=0)
        {
            IsDead = true;
        }
    }

    public void TakeDamage(float damage)
    {
        Life -= damage;

        float _pcLife = (float)Life / (float)LifeMax;
        float preChangePc = LifeBar.fillAmount;
        LifeBar.fillAmount = _pcLife;
    }
}