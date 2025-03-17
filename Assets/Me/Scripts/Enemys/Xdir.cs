using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using Unity.VisualScripting;
using UnityEngine;

public class Xdir : MonoBehaviour
{
    [SerializeField] Transform target;
    SpriteRenderer spriteRenderer;
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }
    void Update()
    {
        
        if (target.position.x < transform.position.x) 
        {
            spriteRenderer.flipX = true;
        }
        if (target.position.x > transform.position.x)
        {
            spriteRenderer.flipX = false;
        }
    }
}
