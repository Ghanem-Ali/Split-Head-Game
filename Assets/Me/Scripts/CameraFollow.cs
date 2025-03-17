using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target;
    player p;
    Camera camera;
    void Start()
    {
        camera = Camera.main;
        p = GameObject.FindGameObjectWithTag("Player").GetComponent<player>();
    }
    void Update()
    {
        if (p.theEnd == true && camera.orthographicSize <= 8.8f)
        {
            camera.orthographicSize += Time.deltaTime;
            transform.position = new Vector3(299.17f, 0f, transform.position.z);
            target.transform.position = new Vector3(299.17f, 0f, 0f);
        }
        else if (target.position.x < 9f && p.theEnd == false)
        {
            camera.orthographicSize = 5;
            transform.position = new Vector3(0f, 0f, transform.position.z);
        }
        else if (target.position.x > 17.9f && p.theEnd == false)
        {
            transform.position = new Vector3(target.position.x, 0f, transform.position.z);
            camera.orthographicSize = 5;
        }

        else if (target.position.x >= 9f && p.theEnd == false)
        {
            transform.position = new Vector3(17.9f, 0f, transform.position.z);
            camera.orthographicSize = 5;
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        
    }
}
