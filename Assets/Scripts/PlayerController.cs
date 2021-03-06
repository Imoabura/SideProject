﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField]
    private int magSize;
    [SerializeField]
    private float cooldown;

    private int currMag;
    private float timeStamp;
    AudioSource audioSource;

    [SerializeField]
    AudioClip shootSFX;
    [SerializeField]
    AudioClip reloadSFX;
    [SerializeField]
    AudioClip longReloadSFX;

    public AmmoDisplay ammo;
    bool isHoldingBreath = false;

    [SerializeField]
    float drainSpeed = .2f;
    [SerializeField]
    float refillSpeed = .13f;

    bool isRecharging = false;
    float fillAmount = 1f;

    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        currMag = magSize;
        timeStamp = Time.time;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            //audioSource.Stop();
            if (currMag >= 1 && timeStamp <= Time.time)
            {
                audioSource.clip = shootSFX;
                audioSource.Play();
                currMag--;
                timeStamp = Time.time + cooldown;
                Shoot();
            }

            else
            {
                //click. s
            }
        }

        isHoldingBreath = Input.GetButton("Jump") && !isRecharging;

        if (isHoldingBreath)
        {
            fillAmount -= calculateDrainSpeed() * Time.deltaTime;
        }
        else
        {
            fillAmount += refillSpeed * Time.deltaTime;
        }

        fillAmount = Mathf.Clamp(fillAmount, 0f, 1f);

        if (fillAmount <= 0)
        {
            isRecharging = true;
        }
        else if (fillAmount >= 1)
        {
            isRecharging = false;
        }

        if (Input.GetKeyDown(KeyCode.R))
        {
            if (timeStamp <= Time.time)
            {
                if (GameController.IsSymptomFatigue())
                {
                    audioSource.clip = longReloadSFX; 
                    timeStamp = Time.time + cooldown + .65f;
                }
                else
                {
                    audioSource.clip = reloadSFX;
                    timeStamp = Time.time + cooldown;
                }
                Reload();
            }
        }
    }

    float calculateDrainSpeed()
    {
        if (GameController.IsSymptomCoughing())
        {
            return drainSpeed * 2f;
        }
        else
        {
            return drainSpeed;
        }
    }
    void Shoot()
    {
        RaycastHit2D hit = Physics2D.Raycast(this.transform.position, Vector2.zero);

        if (hit.collider != null && hit.collider.tag == "Enemy")
        {
            hit.collider.GetComponent<Enemy>().destroyEnemy();
        }

        ammo.DisplayShoot();
    }

    public int getMagSize()
    {
        return magSize;
    }

    public int getCurrMag()
    {
        return currMag;
    }

    public bool getIsHoldingBreath()
    {
        return isHoldingBreath;
    }

    public float getFillAmount()
    {
        return fillAmount;
    }

    public bool getIsRecharging()
    {
        return isRecharging;
    }

    void Reload()
    {
        audioSource.Play();
        currMag = magSize;
        ammo.DisplayReload();
    }

}
