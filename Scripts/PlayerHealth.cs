using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{

    [SerializeField] public int maxHealth = 100;
    public int currentHealth;
    public int power = 20;
    [SerializeField] private TMP_Text healthText;


    void Start()
    {
        currentHealth=maxHealth;
    }

    public void ChangeHealth(int value)
    {
        currentHealth+=value;
        healthText.text="Health "+currentHealth;
    }
    
    

}
