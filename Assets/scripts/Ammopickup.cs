using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ammopickup : MonoBehaviour
{
    [SerializeField] int ammoamount = 10;
    [SerializeField] Ammotype Ammotype;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            Debug.Log("Player did what players do");
            FindObjectOfType<Ammo>().IncreaseCurrentAmmo(Ammotype, ammoamount);

            Destroy(gameObject);
        }
    }
}
