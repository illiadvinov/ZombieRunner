using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;

public class WeaponZoom : MonoBehaviour
{
    [SerializeField] Camera fpsCamera;

    [Header("Default Camera zoom settings")]
     [SerializeField] float defaultCamera = 60f;
    [SerializeField] float zoomCamera = 40f;
    [SerializeField] float zoomSmooth = 1f;
    [SerializeField] float mouseXDefault = 2f;
    [SerializeField] float mouseYDefault = 2f;
    [SerializeField] float mouseXZoomed = .5f;
    [SerializeField] float mouseYZoomed = .5f;

    [Header("Walking settings while zooming")]
    [SerializeField] float forwardSpeedDefault = 5f;
    [SerializeField] float forwardSpeedZoomed = 2f;
    [SerializeField] float backwardSpeedDefault = 4f;
    [SerializeField] float backwardSpeedZoomed = 2f;
    [SerializeField] float strafeSpeedDefault = 4f;
    [SerializeField] float strafeSpeedZoomed = 2f;
    
    RigidbodyFirstPersonController firstPersonController;
    
    bool zoomedInToggle = false;
    //public bool ZoomedInToggle{get {return zoomedInToggle;} }

    //WeaponSwitcher weaponSwitcher;

    private void OnDisable() 
    {
        //ZoomOut();
    }

    private void Awake() {
        firstPersonController = FindObjectOfType<RigidbodyFirstPersonController>();
        //weaponSwitcher = FindObjectOfType<WeaponSwitcher>();
    }

    void Update()
    {
        Zoom();

    }

    private void Zoom()
    {
        if (Input.GetMouseButton(1))
        {
        
            //zoomedInToggle = true;
            fpsCamera.fieldOfView = Mathf.MoveTowards(fpsCamera.fieldOfView, zoomCamera, zoomSmooth * Time.deltaTime);

            firstPersonController.mouseLook.XSensitivity = mouseXZoomed;
            firstPersonController.mouseLook.YSensitivity = mouseYZoomed;

            firstPersonController.movementSettings.ForwardSpeed = forwardSpeedZoomed;
            firstPersonController.movementSettings.BackwardSpeed = backwardSpeedZoomed;
            firstPersonController.movementSettings.StrafeSpeed = strafeSpeedZoomed;
           

        }

        else if(fpsCamera.fieldOfView != defaultCamera)
        {
            //zoomedInToggle = false;
            fpsCamera.fieldOfView = Mathf.MoveTowards(fpsCamera.fieldOfView, defaultCamera, zoomSmooth * Time.deltaTime);

             firstPersonController.mouseLook.XSensitivity = mouseXDefault;
            firstPersonController.mouseLook.YSensitivity = mouseYDefault;

            firstPersonController.movementSettings.ForwardSpeed = forwardSpeedDefault;
            firstPersonController.movementSettings.BackwardSpeed = backwardSpeedDefault;
            firstPersonController.movementSettings.StrafeSpeed = strafeSpeedDefault;


        }
    }

    /*private void ZoomIn()
    {
        zoomedInToggle = true;
        fpsCamera.fieldOfView = Mathf.MoveTowards(zoomCamera, defaultCamera, zoomSmooth * Time.deltaTime);

        firstPersonController.mouseLook.XSensitivity = mouseXZoomed;
        firstPersonController.mouseLook.YSensitivity = mouseYZoomed;
    
    }

    private void ZoomOut()
    {
        zoomedInToggle = false;
        fpsCamera.fieldOfView = Mathf.MoveTowards(defaultCamera, zoomCamera, zoomSmooth * Time.deltaTime);
        
        firstPersonController.mouseLook.XSensitivity = mouseXDefault;
        firstPersonController.mouseLook.YSensitivity = mouseYDefault;
    }*/
}


