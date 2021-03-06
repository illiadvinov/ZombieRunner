using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathHandler : MonoBehaviour
{
   [SerializeField] Canvas gameOverCanvas;
    new GameObject gameObject;

   private void Start() 
   {
       gameOverCanvas.enabled = false;
       gameObject = GameObject.FindGameObjectWithTag("Weapon");
   }

   public void HandleDeath()
   {
       gameOverCanvas.enabled = true;
       FindObjectOfType<WeaponSwitcher>().enabled = false;
       Time.timeScale = 0;
       Cursor.lockState= CursorLockMode.None;
       Cursor.visible = true;
   }
}
