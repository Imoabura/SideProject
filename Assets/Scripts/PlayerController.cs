using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public int magSize;
    public float cooldown;

    private int currMag;
    private float timeStamp;
    AudioSource audioSource;

    public AmmoDisplay ammo;

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
                audioSource.Play();
                currMag--;
                timeStamp = Time.time + cooldown;
            }

            else
            {
                //click. s
            }
        }
        if (Input.GetButtonDown("Jump"))
        {
            if (timeStamp <= Time.time)
            {
                Reload();
            }
        }
    }

    void Reload()
    {
        currMag = magSize;
        timeStamp = Time.time + cooldown;
        Debug.Log("Reloaded");
        ammo.DisplayReload();
    }

}
