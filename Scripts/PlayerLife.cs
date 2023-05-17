using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerLife : MonoBehaviour
{
    private Rigidbody2D rb;
    private Animator anim;
    private int lives = 3;
    [SerializeField] private TMP_Text livesText;
    [SerializeField] private AudioSource deathSoundEffect;
    private void Start()
    {
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Trap") || collision.gameObject.CompareTag("Traps"))
        {
            if(lives>1)
            {
                deathSoundEffect.Play();
                anim.SetBool("hurt",true);
                lives--;
                livesText.text = "Lives : " + lives;
                Invoke("Reset", .5f);
            }
            else
                Die();
        }
    }
    private void Reset()
    {
        anim.SetBool("hurt",false);
    }



    private void Die()
    {
        deathSoundEffect.Play();
        rb.bodyType = RigidbodyType2D.Static;
        anim.SetTrigger("death");
    }
    private void GameOver()
    {
        SceneManager.LoadScene(6);
    }
}
