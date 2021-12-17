using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Shooting : MonoBehaviour
{
    [SerializeField] Camera FPCamera;
    [SerializeField] float range = 100f;
    [SerializeField] float damage = 50f;
    [SerializeField] float timeBetweenShots = 2f;
    [SerializeField] ParticleSystem muzzleFlash;
    [SerializeField] GameObject hitEffect;
    [SerializeField] Ammo ammoSlot;
    [SerializeField] AmmoType ammoType;
    [SerializeField] TextMeshProUGUI ammoText;

    bool canShoot = true;

    private void OnEnable() 
    {
        canShoot = true;
    }
    
    //public Vector3 lastShotPosition = new Vector3(0, 0, 0);


    void Update()
    {
        DisplayAmmo();
        if(Input.GetMouseButtonDown(0) && canShoot == true)
        {
            StartCoroutine(Shoot());
            //lastShotPosition= transform.position;
        }
    }

    private void DisplayAmmo()
    {
        int currentAmmo = ammoSlot.GetCurrentAmmo(ammoType);
        ammoText.text = currentAmmo.ToString();
    }

    IEnumerator Shoot()
    {
        canShoot = false;
        if(ammoSlot.GetCurrentAmmo(ammoType) > 0)
        { 
            PlayMuzzleFlash();
            ProcessRaycast();
            ammoSlot.ReduceAmmo(ammoType);
        }
        yield return new WaitForSeconds(timeBetweenShots);
        canShoot = true;
        
    }

    private void PlayMuzzleFlash()
    {
       muzzleFlash.Play();
    }

    private void ProcessRaycast()
    {
        RaycastHit hit;
        if (Physics.Raycast(FPCamera.transform.position, FPCamera.transform.forward, out hit, range))
        {
            CreateHitImpact(hit);
            EnemyHealth target = hit.transform.GetComponent<EnemyHealth>();

            if (target == null) return;
            target.TakeDamage(damage);
        }
        else
        {
            return;
        }
    }

    private void CreateHitImpact(RaycastHit hit)
    {
        GameObject impact = Instantiate(hitEffect, hit.point, Quaternion.LookRotation(hit.normal));
        Destroy(impact, .1f);
    }
}
