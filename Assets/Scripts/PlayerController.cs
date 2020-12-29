using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public int magSize;    
    public float cooldown;

    private int currMag;
    private float timeStamp = Time.time;
    AudioSource audioSource;

    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        currMag = magSize;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            //audioSource.Stop();
            if (currMag > 1 && timeStamp <= Time.time)
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
                currMag = magSize;
                timeStamp = Time.time + cooldown;
            }
        }
    }

}
