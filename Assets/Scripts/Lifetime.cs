using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
public class Lifetime : MonoBehaviour
{
    [SerializeField]
    float seconds = 10;
    [SerializeField]
    float fadeTrigger = 0.5f; // when to begin fading effect as a ratio of total lifetime

    float elapsedTime = 0;
    SpriteRenderer spriteRenderer;
    Color currentColor;

    // Start is called before the first frame update
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        elapsedTime += Time.deltaTime;

        if (elapsedTime >= seconds * fadeTrigger)   // If fade effect has begun..
        {
            updateVisibility(); // change the sprite's alpha value
        }

        if (elapsedTime >= seconds) // end of life reached
        {
            Destroy(this.transform.parent.gameObject);
        }
    }

    void updateVisibility()
    {
        Color newColor = spriteRenderer.color;
        newColor.a = 1 - (elapsedTime - seconds * fadeTrigger) / (seconds * fadeTrigger); // currently linearly begins to disappear after trigger ratio is passed
        spriteRenderer.color = newColor;
    }
}
