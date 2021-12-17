using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponSwitcher : MonoBehaviour
{
    [SerializeField] int currentWeapon = 0;
    //public int flag = 0;

    // WeaponZoom weaponZoom;

    void Start()
    {
        SetWeaponActive();
       // weaponZoom = FindObjectOfType<WeaponZoom>();
    }
    void Update()
    {
        int previousWeapon = currentWeapon;

        
            ProccesKeyInput();
            ProccessScrollWheel();

              if(previousWeapon != currentWeapon)
            {
                SetWeaponActive();
                //flag = 1;
                
            }

          
            
        

        
    }

    private void ProccessScrollWheel()
    {
        if(Input.GetAxis("Mouse ScrollWheel") < 0f)
        {
            currentWeapon = Mathf.Min(currentWeapon + 1, transform.childCount - 1);
        } 
       
        if(Input.GetAxis("Mouse ScrollWheel") > 0f)
        {
            currentWeapon = Mathf.Max(currentWeapon - 1, 0);

        } 
        
    }

    private void ProccesKeyInput()
    {
        if(Input.GetKeyDown(KeyCode.Alpha1)) currentWeapon = 0;
        if(Input.GetKeyDown(KeyCode.Alpha2)) currentWeapon = 1;
        if(Input.GetKeyDown(KeyCode.Alpha3)) currentWeapon = 2;
    }

    private void SetWeaponActive()
    {
        int weaponIndex = 0;

        foreach(Transform weapon in transform)
        {
            if(weaponIndex == currentWeapon) 
            {
                weapon.gameObject.SetActive(true);
            }
            else 
            {
                weapon.gameObject.SetActive(false);
            }
            weaponIndex++;
        }
    }
}

    
