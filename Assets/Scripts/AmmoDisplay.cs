using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmmoDisplay : MonoBehaviour
{
    //public GameObject crosshairObject;
    public Sprite bulletImage;
    PlayerController pc;
    int startY = 0;
    int currentY = 0;

    // Start is called before the first frame update
    void Start()
    {
        //pc = crosshairObject.GetComponent<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void DisplayReload()
    {
        Debug.Log("Display Reloaded");
    }
}
