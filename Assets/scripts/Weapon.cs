using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class Weapon : MonoBehaviour
{
    [SerializeField] Camera fpcamera;
    [SerializeField] float range = 100f;
    [SerializeField] float damage = 30;
    [SerializeField] ParticleSystem muzzleflash;
    [SerializeField] GameObject hiteffect;
    [SerializeField] Ammo ammoSlot;
    [SerializeField] Ammotype ammotype;
    [SerializeField] float timeBetweenShots = 0.5f;
    [SerializeField] TextMeshProUGUI ammoText;
    public AudioSource audioSource;

    bool canShoot = true;
    private void OnEnable()
    {
        canShoot = true;
    }

    void Update()
    {
        DisplayAmmo();
        if (Input.GetMouseButtonDown(0) && canShoot == true)
        {
            StartCoroutine(Shoot());
        }

    }


    private void DisplayAmmo()
    {   float currentAmmo;
        currentAmmo = ammoSlot.GetCurrentAmmo(ammotype);
        ammoText.text = currentAmmo.ToString();
    }

    IEnumerator Shoot()
    {
        canShoot = false;
        if (ammoSlot.GetCurrentAmmo(ammotype) > 0)
        {
            audioSource.Play();
            Playmuzzleflash();
            Raycast();
            ammoSlot.ReduceCurrentAmmo(ammotype);
        }
        yield return new WaitForSeconds(timeBetweenShots);
        canShoot = true;

    }
    private void Playmuzzleflash()
    {
        muzzleflash.Play(); 
    }

    private void Raycast()
    {
        RaycastHit hit;
        if (Physics.Raycast(fpcamera.transform.position, fpcamera.transform.forward, out hit, range))
        {
            Createhitimpact(hit);
            Debug.Log("Target shot" + hit.transform.name);
            Health target = hit.transform.GetComponent<Health>();
            if (target == null)
                return;
            target.Takedamage(damage);
        }
        else
        {
            return;
        }
    }
    private void Createhitimpact(RaycastHit hit)
    {
        GameObject impact = Instantiate(hiteffect, hit.point, Quaternion.LookRotation(hit.normal));
        Destroy(impact, 0.1f);
    }
}
