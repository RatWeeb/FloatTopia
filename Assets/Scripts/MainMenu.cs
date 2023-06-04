using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public AudioSource selectSound;
    public GameObject explainBg;

    public void PlayGame()
    {
        selectSound.Play();
        SceneManager.LoadScene(1);
    }

    public void Explain()
    {
        explainBg.SetActive(true);
    }
    public void Back()
    {
        explainBg.SetActive(false);
    }
}
