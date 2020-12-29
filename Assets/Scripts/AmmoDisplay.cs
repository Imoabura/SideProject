using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmmoDisplay : MonoBehaviour
{
    //public GameObject crosshairObject;
    public GameObject bulletUIPrefab;
    public PlayerController pc;
    int startY = 0;
    int currentY = 0;


    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void DisplayReload()
    {
        currentY = 0;

        for(int i = 0; i < pc.getMagSize(); i++)
        {

        }
    }

    //GetChildren, then delete last child
}
