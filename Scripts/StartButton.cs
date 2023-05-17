using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartButton : MonoBehaviour
{
    [SerializeField] private AudioSource clickSoundEffect;
    public void StartGame()
    {
        clickSoundEffect.Play();
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex %4 + 1);
    }
}
