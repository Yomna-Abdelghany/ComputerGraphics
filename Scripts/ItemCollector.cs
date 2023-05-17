using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ItemCollector : MonoBehaviour
{
    private int points = 0;
    [SerializeField] private TMP_Text pointsText;
    [SerializeField] private AudioSource collectsSoundEffect;
    private void OnTriggerEnter2D (Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Star"))
        {
            Destroy(collision.gameObject);
            collectsSoundEffect.Play();
            points++;
            pointsText.text = "Points : " + points;
        }
    }
}
