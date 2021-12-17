using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlashlightSystem : MonoBehaviour
{

    [SerializeField] float flashDecay = .1f;
    [SerializeField] float angleDecay = 1f;
    [SerializeField] float minimunAngle = 40f;

    Light myLight;

    void Start()
    {
        myLight = GetComponent<Light>();
    }

    void Update()
    {
        DecreaseLightAngle();
        DecreaseLightIntensity();
    }

    public void RestoreLight(float restoreAngle, float restoreItensity, float maxIntensityValue)
    {
        myLight.spotAngle = restoreAngle;
        if(restoreItensity <= maxIntensityValue) myLight.intensity += restoreItensity;
    }
   

    private void DecreaseLightIntensity()
    {
        
        myLight.intensity -= flashDecay * Time.deltaTime;
    }

    private void DecreaseLightAngle()
    {
        if(myLight.spotAngle <= minimunAngle) return;
        myLight.spotAngle -= angleDecay * Time.deltaTime;
    }
}
