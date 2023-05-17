using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;
using UnityEngine.UI;

public class ItemCollection : MonoBehaviour
{
    private int stars=0;

    [SerializeField] private TMP_Text starsText;
    [SerializeField] private AudioSource collectSoundEffect;

    private void OnTriggerEnter2D(Collider2D collision) 
    {
        if(collision.gameObject.CompareTag("Collectables") || collision.gameObject.CompareTag("CarrotCollectable"))
        {
            Destroy(collision.gameObject);
            collectSoundEffect.Play();
            stars++;
            starsText.text= "Points : " + stars;
        }
        
    }
}
