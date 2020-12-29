using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrosshairMovement : MonoBehaviour
{
    [SerializeField]
    float moveSpeed;
    Transform crosshair;

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
        crosshair.position = newPos;
    }
}
