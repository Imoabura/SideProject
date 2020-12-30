using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrosshairMovement : MonoBehaviour
{
    [SerializeField]
    Transform crosshair;
    [SerializeField]
    float xAmplitude = 1f;
    [SerializeField]
    float yAmplitude = 1f;
    [SerializeField]
    float xFrequency = 1f;
    [SerializeField]
    float yFrequency = 2f;
    [SerializeField]
    float breathMultiplier = .1f;
    
    float currentValue = 0f;

    PlayerController playerController;

    // Start is called before the first frame update
    void Start()
    {
        crosshair = this.gameObject.transform;
        Cursor.visible = false;
        playerController = GameObject.FindGameObjectWithTag("Player").GetComponentInChildren<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 newPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        newPos.z = 0;
        crosshair.transform.parent.position = newPos; // parent is always in correct position

        BobEffect();
    }

    void BobEffect()
    {
        float xPos = Mathf.Sin(xFrequency * Time.time) * xAmplitude;
        float yPos = Mathf.Sin(yFrequency * Time.time) * yAmplitude;
        
        if (playerController.getIsHoldingBreath())
        {
            currentValue += .5f * Time.deltaTime;
        }
        else
        {
            currentValue -= .5f * Time.deltaTime;
        }

        currentValue = Mathf.Clamp(currentValue, 0f, 1f);
        
        xPos *= Mathf.Lerp(1f, breathMultiplier, currentValue);
        yPos *= Mathf.Lerp(1f, breathMultiplier, currentValue);

        transform.localPosition = new Vector3(xPos, yPos, 0);
    }
}
