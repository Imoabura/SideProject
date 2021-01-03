using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    Animator animator;

    // Start is called before the first frame update
    void Awake()
    {
        animator = GetComponent<Animator>();       
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void destroyEnemy()
    {
        Destroy(this.transform.parent.gameObject);
    }

    public void increaseSpeed()
    {
        animator.speed = 3f;
    }
}
