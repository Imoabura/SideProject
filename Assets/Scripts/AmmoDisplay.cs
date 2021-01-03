using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AmmoDisplay : MonoBehaviour
{
    //public GameObject crosshairObject;
    public GameObject bulletUIPrefab;
    public PlayerController pc;
    int startY = 0;
    float currentY = 0f;

    private Vector3 preV;

    public Image breathBar;

    // Start is called before the first frame update
    void Start()
    {
        DisplayReload();
    }

    // Update is called once per frame
    void Update()
    {
        breathBar.fillAmount = pc.getFillAmount();
        ColorUpdate();
    }

    void ColorUpdate()
    {
        if(!pc.getIsRecharging())
        {
            if(breathBar.fillAmount < 0.5f)
            {
                breathBar.color = Color.Lerp(Color.red, Color.yellow, breathBar.fillAmount * 2);
            }
            else
            {
                breathBar.color = Color.Lerp(Color.yellow, Color.green, ColorLerper(0.5f, 1, 0, 1, breathBar.fillAmount));
            }
            //breathBar.color = Color.Lerp(Color.red, Color.green, breathBar.fillAmount);
        }
    }

    float ColorLerper(float oldMin, float oldMax, float newMin, float newMax, float value)
    {
        if(value <= oldMin)
        {
            return oldMin;
        }
        else if (value >= oldMax)
        {
            return oldMax;
        }

        return ((value - oldMin) / (oldMax - oldMin)) * (newMax - newMin) + newMin;
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
