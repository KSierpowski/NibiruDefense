using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControls : MonoBehaviour
{
    [Header ("General Setup Settings")]
    [Tooltip ("How fast ship move to up and down")][SerializeField] float speed = 10f;
    [Tooltip ("How far ship move to left and right")][SerializeField] float xRange = 5f;
    [Tooltip("How far ship move to up and down")][SerializeField] float yRange = 5f;

    [Header("Lasers gun array")]
    [Tooltip("Add all player lasers here")][SerializeField] GameObject[] lasers; 

    [Header("Screen position based tuning")]
    [SerializeField] float positionPichFactor = -2f;
    [SerializeField] float positionYawFactor = 2f;

    [Header("Player input based tuning")]
    [SerializeField] float controlPichFactor = -12f;
    [SerializeField] float controlRollFactor = -20;

    float xThrow, yThrow;
   

    void Update()
    {
        ProcessTranslation();
        ProcessRotation();
        ProcessFiring();

    }
    void ProcessFiring()
    {
        if (Input.GetButton("Fire1"))
        {
            SetLasersActive(true);
        }
        else
        {
            SetLasersActive(false);    
        }

    }
    private void SetLasersActive(bool isActive)
    {
        foreach (GameObject laser in lasers)                        
        { 
            var  emmisionModule = laser.GetComponent<ParticleSystem>().emission;  //lasers doesn't stop when we stopping pushing button (we on/off emission)
           emmisionModule.enabled = isActive;

        }
    }

    void ProcessRotation()
    {
        float pichDueToPosition = transform.localPosition.y * positionPichFactor;
        float pichDueToControlThrow = yThrow * controlPichFactor; //rotation up/down


        float pich = pichDueToPosition + pichDueToControlThrow; 
        float yaw = transform.localPosition.x * positionYawFactor;  //ship turn left/right
        float roll = xThrow * controlRollFactor; //rotation lef/right
        transform.localRotation = Quaternion.Euler(pich, yaw, roll);
    }

    private void ProcessTranslation()
    {
       xThrow = Input.GetAxis("Horizontal");
       yThrow = Input.GetAxis("Vertical");



        float xOffset = xThrow * Time.deltaTime * speed;
        float rawXPos = transform.localPosition.x + xOffset;
        float clampedXPos = Mathf.Clamp(rawXPos, -xRange, xRange);


        float yOffset = yThrow * Time.deltaTime * speed;
        float rawYPos = transform.localPosition.y + yOffset;
        float clampedYPos = Mathf.Clamp(rawYPos, -yRange, yRange);

        transform.localPosition = new Vector3(clampedXPos, clampedYPos, transform.localPosition.z); //local cause we dont change possition in relation for entire world, just for the local (playerrig)
    }


}
