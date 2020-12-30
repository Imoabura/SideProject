using System.Collections;
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
                audioSource.clip = reloadSFX;
                audioSource.Play();
                Reload();
            }
        }
    }

    void Shoot()
    {
        RaycastHit2D hit = Physics2D.Raycast(this.transform.position, Vector2.zero);

        if (hit.collider != null && hit.collider.tag == "Enemy")
        {
            Debug.Log("Enemy Hit!");
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

    void Reload()
    {
        currMag = magSize;
        timeStamp = Time.time + cooldown;
        ammo.DisplayReload();
    }

}
