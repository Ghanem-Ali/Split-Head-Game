using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gunman : MonoBehaviour
{
    public GameObject bullet;

    public Transform bulletPos;
    public Transform bulletPos2;

    private GameObject target;

    private float timer = 2;

    public float shootRange;

    public float shootCooldown;
    void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player");
    }

    void Update()
    {
        float distance = Vector2.Distance(transform.position, target.transform.position);

        if (distance < shootRange)
        {
            timer += Time.deltaTime;

            if (timer > shootCooldown)
            {
                timer = 0;
                shoot();
            }
        }
    }
    
    void shoot()
    {
        if (target.transform.position.x < transform.position.x)
        {
            Instantiate(bullet, bulletPos2.position, Quaternion.identity);
        }
        else
        {
            Instantiate(bullet, bulletPos.position, Quaternion.identity);
        } 
    }
}
