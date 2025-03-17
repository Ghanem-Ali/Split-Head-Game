using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyRespawn : MonoBehaviour
{
    CapsuleCollider2D capsuleCollider;
    SpriteRenderer spriteRenderer;
    player p;
    Vector3 respawnPoint;

    void Start()
    {
        capsuleCollider = GetComponent<CapsuleCollider2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        respawnPoint = gameObject.transform.position;
        p = GameObject.FindGameObjectWithTag("Player").GetComponent<player>();
    }

    void Update()
    {gameObject.SetActive(true);
        if (p.isDead == true)
        {
            transform.position = respawnPoint;
        }
        else { }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Enemy") 
        {
            transform.position = new Vector3(0, 0, 100);
        }
    }
}
