using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;

public class Weaponzoom : MonoBehaviour
{
    [SerializeField] Camera fpsCamera;
    [SerializeField] float zoomedOutFOV = 60f;
    [SerializeField] float zoomedInFOV = 20f;
    [SerializeField] float zoomoutsen =2f;
    [SerializeField] float zoominsen= 0.5f;
    RigidbodyFirstPersonController fps;

    bool zoomedInToggle = false;
    private void OnDisable()
    {
        Zoomout();
    }
    private void Update()
    {
        if (Input.GetMouseButtonDown(1))
        {
            if (zoomedInToggle == false)
            {
                Zoomin();
            }
            else
            {
                Zoomout();
            }
        }
    }

    private void Zoomout()
    {
        zoomedInToggle = false;
        fpsCamera.fieldOfView = zoomedOutFOV;
        fps.mouseLook.YSensitivity = zoomoutsen;
    }

    private void Zoomin()
    {
        zoomedInToggle = true;
        fpsCamera.fieldOfView = zoomedInFOV;
        fps.mouseLook.XSensitivity = zoominsen;
    }
}
