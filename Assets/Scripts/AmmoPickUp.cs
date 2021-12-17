using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmmoPickUp : MonoBehaviour
{
    [SerializeField] int ammoAmount = 5;
    [SerializeField] AmmoType ammoType;

    Ammo ammo;
    private void Start() {
        ammo = FindObjectOfType<Ammo>();
    }

     private void OnTriggerEnter(Collider other) {
         if(other.gameObject.tag == "Player")
        {
            ammo.IncreaseAmmo(ammoType, ammoAmount);
            gameObject.SetActive(false);
           
        }
        
    }
}
