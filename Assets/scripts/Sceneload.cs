using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Sceneload : MonoBehaviour
{

    public void Reloadgame()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(0);
    }
    public void Exitgame()
    {
        Application.Quit();
    }
}

