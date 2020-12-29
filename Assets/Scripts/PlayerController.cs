using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public int magSize;
    
    public float cooldown;
    private float timeStamp = Time.time;
    AudioSource audioSource;

    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            audioSource.Stop();
            if (magSize > 1 && timeStamp <= Time.time)
            {
                audioSource.Play();
                magSize--;
                timeStamp = Time.time + cooldown;
            }

            else
            {
                //click. 
            }
        }
    }

}
