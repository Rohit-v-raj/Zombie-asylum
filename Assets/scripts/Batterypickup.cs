﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Batterypickup : MonoBehaviour
{
    [SerializeField] float restoreAngle = 90f;
    [SerializeField] float addIntensity = 1f;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            other.GetComponentInChildren<Flashlight>().RestoreLightAngle(restoreAngle);
            other.GetComponentInChildren<Flashlight>().AddLightIntensity(addIntensity);
            Destroy(gameObject);
        }
    }
}
