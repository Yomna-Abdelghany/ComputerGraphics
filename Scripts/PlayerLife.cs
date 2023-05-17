using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerLife : MonoBehaviour
{
    PlayerHealth health;
    bool dead=false;
    [SerializeField] AudioSource deathSound;
    [SerializeField] AudioSource enemydeathSound;
    [SerializeField] AudioSource enemycollisionSound;


    private void Start() {
        health=GetComponent<PlayerHealth>();
    }
    

    private void Update()
    {
        if(transform.position.y < -2f && !dead)
        {
            Die();
            deathSound.Play();
        }
    }
    private void OnCollisionEnter(Collision collision) 
    {
        if (collision.gameObject.CompareTag("EnemyBody"))
        {
            health.ChangeHealth(-collision.gameObject.GetComponent<PlayerHealth>().power);
            enemycollisionSound.Play();
            if(health.currentHealth<=0)
            {
            GetComponent<MeshRenderer>().enabled = false;
            GetComponent<Rigidbody>().isKinematic = true;
            GetComponent<PlayerMovemenet>().enabled = false;
            enemydeathSound.Play();
            Die();
            }
        }
    }
    
    void Die()
    {
        
        dead=true;
        //Invoke(nameof(ReloadLevel), 1.3f);
        SceneManager.LoadScene(5);
        
    }
    void ReloadLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
