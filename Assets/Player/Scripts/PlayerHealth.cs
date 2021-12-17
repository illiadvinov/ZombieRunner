using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] float totalHealth = 100f;
    
    DeathHandler deathHandler;

    // Start is called before the first frame update
    void Start()
    {
        deathHandler = FindObjectOfType<DeathHandler>();
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void TakeDamage(float damage)
    {
       totalHealth -= damage;
       if(totalHealth <= 0)
       {
           Debug.Log("Player is Dead");
           deathHandler.HandleDeath();

       } 
    }
}
