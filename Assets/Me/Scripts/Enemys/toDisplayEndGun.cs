using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class toDisplayEndGun : MonoBehaviour
{
    player p;
    Gunman gunman;

    CapsuleCollider2D capsuleCollider;
    SpriteRenderer spriteRenderer;

    Vector2 spawn;

    float timer;
    void Start()
    {
        gunman = GetComponent<Gunman>();

        spawn = transform.position;

        capsuleCollider = GetComponent<CapsuleCollider2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();

        capsuleCollider.enabled = false;
        spriteRenderer.enabled = false;

        p = GameObject.FindGameObjectWithTag("Player").GetComponent<player>();
    }

    void Update()
    {
        if (p.theEnd == true)
        {
            capsuleCollider.enabled = true;
            spriteRenderer.enabled = true;

            timer += Time.deltaTime;
            if (timer >= 3.8f)
            {
                gunman.enabled = true;

            }

        }
        else
        {
            transform.position = spawn;
            capsuleCollider.enabled = false;
            spriteRenderer.enabled = false;
            gunman.enabled = false;
            timer = 0;
        }
    }
}