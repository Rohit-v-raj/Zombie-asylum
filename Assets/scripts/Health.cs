using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] float hit = 100f;
    bool isDead = false;
    public AudioSource deat;

    public bool IsDead()
    {
        return isDead;
    }
    public void Takedamage(float damage)
    {
        BroadcastMessage("Ondamageprov");
        hit -= damage;
        if(hit<=0)
        {
            Die();
        }
    }
    private void Die()
    {
        if (isDead) return;
        isDead = true;
        deat.Play();
        GetComponent<Animator>().SetTrigger("die");

    }
}
