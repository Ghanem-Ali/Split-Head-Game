using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class toDisplay1 : MonoBehaviour
{
    player p;

    CapsuleCollider2D capsuleCollider;
    SpriteRenderer spriteRenderer;

    Vector2 spawn;
    void Start()
    {
        spawn = transform.position;

        capsuleCollider = GetComponent<CapsuleCollider2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();

        capsuleCollider.enabled = false;
        spriteRenderer.enabled = false;

        p = GameObject.FindGameObjectWithTag("Player").GetComponent<player>();
    }

    void Update()
    {
        if (p.isTouch1 == true || p.theEnd == true)
        {
            capsuleCollider.enabled = true;
            spriteRenderer.enabled = true;
        }
        else
        {
            transform.position = spawn;
            capsuleCollider.enabled = false;
            spriteRenderer.enabled = false;
        }
    }
}
