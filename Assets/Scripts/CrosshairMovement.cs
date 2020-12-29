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
    }

    // Update is called once per frame
    void Update()
    {
        float verticalMove = Input.GetAxisRaw("Mouse Y");
        float horizontalMove = Input.GetAxisRaw("Mouse X");

        crosshair.position += new Vector3(horizontalMove, verticalMove).normalized * moveSpeed * Time.deltaTime;
    }
}
