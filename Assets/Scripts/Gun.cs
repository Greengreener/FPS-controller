﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Gun : MonoBehaviour
{
    public float damage = 10f;
    public float range = 100f;
    [Header("Gun clip and ammo")]
    public int clip;
    public int clipMax = 30;
    public int ammo;
    public int ammoMax = 100;

    [Header("UI details")]
    public Text clipText;
    public Text ammoText;
    public string gunName;
    public Text currentGun;

    public Camera fpsCamera;
    void Start()
    {
        clip = clipMax;
        ammo = ammoMax;
        fpsCamera = Camera.main;
        gunName = "AK-47";
        currentGun.text = gunName;
        UIUpdate();
    }
    void Update()
    {
        if (Input.GetButton("Fire1") && clip > 0)
        {
            Shoot();
        }
        if (Input.GetKeyDown(KeyCode.R) && ammo > 0)
        {
            int amountIntoClip;
             
            if (clip != clipMax)
            {
                amountIntoClip = clipMax - clip;
                if (ammo > 0)
                {
                    if (amountIntoClip <= ammo)
                    {
                        Debug.Log("Amount into clip = " + amountIntoClip);
                        clip = clip + amountIntoClip;
                        ammo = ammo - amountIntoClip;
                    }
                    else
                    {
                        clip += ammo;
                        ammo = 0;
                    }
                    
                }  
                if (ammo <= 0)
                {
                    ammo = 0;
                }
            }
            UIUpdate();
        }
    }
    void Shoot()
    {
        clip--;
        UIUpdate();
        RaycastHit hit;
        Target target;
        if (Physics.Raycast(fpsCamera.transform.position, fpsCamera.transform.forward, out hit, range))
        {
            target = hit.transform.GetComponent<Target>();

            Debug.Log(hit.ToString());
            if (target != null)
            {
                target.TakeDamage(damage);
            }
            else
            {
                Debug.Log("Miss");
            }
        }
        else { Debug.Log("BigMiss"); }
    }
    void UIUpdate()
    {
        clipText.text = ("Clip: ") + clip;
        ammoText.text = ("Ammo: ") + ammo;
    }
}
