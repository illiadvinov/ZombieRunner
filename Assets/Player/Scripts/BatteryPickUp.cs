using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BatteryPickUp : MonoBehaviour
{
    [SerializeField] float maxIntensityValue = 12f;
    [SerializeField] float restoreAngle = 20f;
    [SerializeField] float restoreIntensity = 4f;

    FlashlightSystem flashlight;
    void Start()
    {
        flashlight = FindObjectOfType<FlashlightSystem>();
    }

    private void OnTriggerEnter(Collider other) 
    {
        if(other.tag == "Player") 
        {
            flashlight.RestoreLight(restoreAngle, restoreIntensity, maxIntensityValue);
            Destroy(gameObject);
        }
    }

}
