using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemyai : MonoBehaviour
{
    [SerializeField] Transform target;
    [SerializeField] float dist = 5f;
    [SerializeField] float sp = 3f;
    Health health;
    public AudioSource prov;
    
    NavMeshAgent navagent;
    float Distancetotarget = 0.1f * Mathf.Infinity;
    bool isprovoke = false;
    // Start is called before the first frame update
    void Start()
    {
        target = FindObjectOfType<Playerhealth>().transform;
        navagent = GetComponent<NavMeshAgent>();
        health = GetComponent<Health>();
    }

    // Update is called once per frame
    void Update()
    {
        if (health.IsDead())
        {
            enabled = false;
            navagent.enabled = false;
        }

        Distancetotarget = Vector3.Distance(target.position, transform.position);


         if (isprovoke)
          { Engagetarget(); }
        if (Distancetotarget <= dist)
        {

            isprovoke = true;
            prov.Play();
            Engagetarget();
            
        }
        else
        { isprovoke = false;
            GetComponent<Animator>().SetTrigger("idle");
            }
    }
    private void Engagetarget()
    {
        Lookrotation();
     if(Distancetotarget >= navagent.stoppingDistance)
        {
            Move();
        }
     else if(Distancetotarget<=navagent.stoppingDistance)
            {
            Attack();
        }
    }
    public void Ondamageprov()
    {
        isprovoke = true;
    }
    private void Move()
    {
        GetComponent<Animator>().SetBool("attack", false);
        GetComponent<Animator>().SetTrigger("move");
        navagent.SetDestination(target.position);
    }
    private void Attack()
    {
        GetComponent<Animator>().SetBool("attack", true);
    }

    private void Lookrotation()
    {
        Vector3 direction = target.position - transform.position;
        Quaternion rotation = Quaternion.LookRotation(new Vector3(direction.x, 0, direction.z));
        transform.rotation = Quaternion.Slerp(transform.rotation, rotation, Time.deltaTime * sp);
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, dist);
    }
}
