using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Enemyattack : MonoBehaviour
{
    Playerhealth target;
    [SerializeField] float damage = 40f;

    void Start()
    {
        target = FindObjectOfType<Playerhealth>();
    }
    public void Attackhitevent()
    {
        if (target == null) return;
        
        else
        target.Hitdamage(damage);
        Debug.Log("argghh");
        target.GetComponent<Bloodsplatter>().ShowDamageImpact();
    }
    // Update is called once per frame
    
}
