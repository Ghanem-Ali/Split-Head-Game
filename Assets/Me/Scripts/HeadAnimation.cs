using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class HeadAnimation : MonoBehaviour
{
    private Animator animator;
    float Xdir = 1f;
    SpriteRenderer spriteRenderer;
    void Start()
    {
        animator = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        animator.SetBool("isRunning", isRunning());
        animator.SetFloat("Xdir", Xdir);

    //-----------------⁄‘«‰  ‰ﬁ·» «·‘Œ’Ì…------------------------
        if (Input.GetKey(KeyCode.A))
        {
            Xdir = -1f;
            spriteRenderer.flipX = true;
        }

        if (Input.GetKey(KeyCode.D)) 
        { 
            Xdir = 1f;
            spriteRenderer.flipX = false;
        } 
    //-----------------------------------------------------------

    }
    bool isRunning()
    {
        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.D)) { return true; }

        else { return false; }
    }
}
