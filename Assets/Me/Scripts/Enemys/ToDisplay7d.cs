using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToDisplay7d : MonoBehaviour
{
    BoxCollider2D collider;
    player p;
    void Start()
    {
        p = GameObject.FindGameObjectWithTag("Player").GetComponent<player>();
        collider = GetComponent<BoxCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (p.theEnd == false)
        {
            collider.enabled = false;
        }
        if (p.theEnd == true)
        {
            collider.enabled = true;
        }
    }
}
