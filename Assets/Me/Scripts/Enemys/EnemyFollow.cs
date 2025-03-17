using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;

public class EnemyFollow : MonoBehaviour
{
    [SerializeField] Transform target;

    NavMeshAgent agent;

    private Animator animator;

    float distance;
    public float range;

    SpriteRenderer spriteRenderer;

    void Start()
    {
        animator = GetComponent<Animator>();

        spriteRenderer = GetComponent<SpriteRenderer>();

        agent = GetComponent<NavMeshAgent>();
        agent.updateRotation = false;
        agent.updateUpAxis = false;
        
    }
    void Update()
    {
        distance = Vector3.Distance(transform.position, target.position);
        
        if (distance < range)
        {
            animator.SetBool("isRunning", true);
            
            agent.SetDestination(target.position);          //ÇÍØ ÇáæÌåå
        }
        else
        {
            animator.SetBool("isRunning", false);
            agent.SetDestination(transform.position);
        }
        
        if (target.position.x < transform.position.x)
        {
            animator.SetFloat("Xdir", -1f);
            spriteRenderer.flipX = true;
        }
        if (target.position.x > transform.position.x)
        {
            animator.SetFloat("Xdir", 1f);
            spriteRenderer.flipX = false;
        }
    }
}
