using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class MyNavMesh : MonoBehaviour
{
    [SerializeField] Transform target;

    NavMeshAgent agent;

    float distance;
    public float range;

    SpriteRenderer spriteRenderer;

    void Start()
    {

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
            agent.SetDestination(target.position);          //ÇÍØ ÇáæÌåå
        }
        else
        {
            agent.SetDestination(transform.position);
        }

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
