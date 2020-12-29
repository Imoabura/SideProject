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

    [SerializeField]
    AudioClip shootSFX;
    [SerializeField]
    AudioClip reloadSFX;

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
        if (Input.GetButtonDown("Jump"))
        {
            if (timeStamp <= Time.time)
            {
                Reload();
            }
        }
    }

    void Shoot()
    {
        RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);

        if (hit.collider != null && hit.collider.tag == "Enemy")
        {
            Debug.Log("Enemy Hit!");
            hit.collider.GetComponent<Enemy>().destroyEnemy();
        }
    }

    void Reload()
    {
        audioSource.clip = reloadSFX;
        audioSource.Play();
        currMag = magSize;
        timeStamp = Time.time + cooldown;
        Debug.Log("Reloaded");
        ammo.DisplayReload();
    }

}
