using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponSway : MonoBehaviour
{
    [Header("Position")]
    [SerializeField] float amount = 0.02f;
    [SerializeField] float maxAmount = 0.06f;
    [SerializeField] float smoothAmount = 6f;

    [Header("Rotation")]
    [SerializeField] float rotationAmount = 4f;
    [SerializeField] float maxRotationAmount = 5f;
    [SerializeField] float smoothRotation = 12f;  

    [Space]
    [SerializeField] bool rotationX = true;
    [SerializeField] bool rotationY = true;
    [SerializeField] bool rotationZ = true;

     Vector3 initialPosition;
     Quaternion initialRotation;

     float InputX;
     float InputY;
    // Start is called before the first frame update
    void Start()
    {
        initialPosition = transform.localPosition;
        initialRotation = transform.localRotation;
    }

    // Update is called once per frame
    void Update()
    {
        CalculateSway();

        MoveSway();
        TiltSway();
    }

    private void CalculateSway()
    {
        InputX = -Input.GetAxis("Mouse X");
        InputY = -Input.GetAxis("Mouse Y");
    }

    private void MoveSway()
    {
        float moveX = Mathf.Clamp(InputX * amount, -maxAmount, maxAmount);
        float moveY = Mathf.Clamp(InputY * amount, -maxAmount, maxAmount);

        Vector3 finalPosition = new Vector3(moveX, moveX, 0);

        transform.localPosition = Vector3.Lerp(transform.localPosition, finalPosition + initialPosition, Time.deltaTime * smoothAmount);
    }

    private void TiltSway()
    {
        float tiltY = Mathf.Clamp(InputX * rotationAmount, -maxRotationAmount, maxRotationAmount);
        float tiltX = Mathf.Clamp(InputY * rotationAmount, -maxRotationAmount, maxRotationAmount);

        Quaternion finalRotation = Quaternion.Euler(new Vector3(
            rotationX ? -tiltX : 0f, 
             rotationY ? tiltY : 0f, 
             rotationZ ? tiltY : 0f
             ));

        transform.localRotation = Quaternion.Slerp(transform.localRotation, finalRotation * initialRotation, Time.deltaTime * smoothRotation);
    }

    

}
