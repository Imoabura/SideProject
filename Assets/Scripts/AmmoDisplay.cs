using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmmoDisplay : MonoBehaviour
{
    //public GameObject crosshairObject;
    public GameObject bulletUIPrefab;
    public PlayerController pc;
    int startY = 0;
    float currentY = 0f;

    private Vector3 preV;


    // Start is called before the first frame update
    void Start()
    {
        DisplayReload();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void DisplayShoot()
    {
        int cc = transform.childCount;

        if(pc.getCurrMag() < cc && cc > 0)
        {
            Destroy(transform.GetChild(cc - 1).gameObject);
        }
    }
    
    public void DisplayReload()
    {
        currentY = startY;

        foreach(Transform child in transform)
        {
            Destroy(child.gameObject);
        }

        for(int i = 0; i < pc.getMagSize(); i++)
        {
            GameObject bully = Instantiate(bulletUIPrefab, transform, false);
            preV = new Vector3(0, currentY, 0);
            bully.transform.position = bully.transform.position + preV;
            currentY += 1f;
            Debug.Log("Bullet created");
        }
    }

    //GetChildren, then delete last child
}
