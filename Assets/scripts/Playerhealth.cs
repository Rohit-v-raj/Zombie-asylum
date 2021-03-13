using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Playerhealth : MonoBehaviour
{
    [SerializeField] float hit = 100f;
    public void Hitdamage(float damage)
    {
        hit -= damage;
        if (hit <= 0)
        {
            GetComponent<Deathhandler>().Handledeath();
            Debug.Log("you are dead");
        }
    }
}