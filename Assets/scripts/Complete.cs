using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Complete : MonoBehaviour
{
    [SerializeField] Canvas canvas;
    [SerializeField] AudioSource audioSource;
    [SerializeField] AudioSource audio1;

    public void Start()
    {
        canvas.enabled = false;
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            audio1.Stop();
            canvas.enabled = true;
            audioSource.Play();
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
            Destroy(gameObject);
           
        }
    }
}
