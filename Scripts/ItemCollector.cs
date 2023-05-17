using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;
using UnityEngine.UI;

public class ItemCollector : MonoBehaviour
{
    int coins=0;
    [SerializeField] AudioSource collectionSound;

    [SerializeField] private TMP_Text coinsText;
    
    private void OnTriggerEnter(Collider other) 
    {
        if(other.gameObject.CompareTag("Coin"))
        {
            Destroy(other.gameObject);
            coins++;
            coinsText.text="Coins "+coins;
            collectionSound.Play();
        }
    }
}
