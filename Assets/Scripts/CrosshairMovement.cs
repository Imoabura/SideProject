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

    // Start is called before the first frame update
    void Start()
    {
        crosshair = this.gameObject.transform;
        Cursor.visible = false;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 newPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        newPos.z = 0;
        crosshair.transform.parent.position = newPos; // parent is always in correct position

        if (true) // To-Do: Replace true with isHoldingBreath boolean
        {
            BobEffect();
        }
        else
        {
            transform.position = Vector3.zero;
        }
        
    }

    void BobEffect()
    {
        transform.localPosition = new Vector3(Mathf.Sin(xFrequency * Time.time) * xAmplitude, Mathf.Sin(yFrequency * Time.time) * yAmplitude, 0);
    }
}
