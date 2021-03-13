using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Deathhandler : MonoBehaviour
{
    [SerializeField] Canvas canvas;
    public void Start()
    {
        canvas.enabled = false;
    }
    public void Handledeath()
    {

        canvas.enabled = true;
        Time.timeScale = 0;
        FindObjectOfType<Weaponswitcher>().enabled = false;

        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }
}
