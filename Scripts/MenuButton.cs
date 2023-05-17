using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class MenuButton : MonoBehaviour
{
    [SerializeField] private AudioSource clickSoundEffect;
    public void StartGame()
    {
        clickSoundEffect.Play();
        SceneManager.LoadScene(0);
    }
    public void MenuGame()
    {
        clickSoundEffect.Play();
        SceneManager.LoadScene(1);
    }
    public void StartLevel1()
    {
        clickSoundEffect.Play();
        SceneManager.LoadScene(2);
    }
    public void StartLevel2()
    {
        clickSoundEffect.Play();
        SceneManager.LoadScene(3);
    }
    public void StartLevel3()
    {
        clickSoundEffect.Play();
        SceneManager.LoadScene(4);
    }
}
