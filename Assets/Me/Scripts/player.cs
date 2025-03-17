using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;


public class player : MonoBehaviour
{
    public float speed = 3f;

    public bool isDead = false;
    public bool isTouch1 = false;
    public bool isTouch2 = false;
    public bool theEnd = false;

    [SerializeField] TextMeshProUGUI cooldownTimer;

    //-----ááÏÚÓÉ------
    public float max = 100f;
    private float current;
    public float burnRate = 200f;
    private float tempSpeed;

    Vector2 respawnPoint = new Vector3(-7f, 0f, 0f);
    
    void Start()
    {
        if (PlayerPrefs.GetFloat("respawnPoint") == 0)
            PlayerPrefs.SetFloat("respawnPoint", -7f);
        respawnPoint = new Vector3(PlayerPrefs.GetFloat("respawnPoint"), 0f, 0f);
        transform.position = respawnPoint;

        current = max;
        tempSpeed = speed;
        respawnPoint = transform.position;
    }

    void Update()
    {
        dashCooldownText();
        move();

    //----------------ááÏÚÓÉ--------------------
        if (Input.GetMouseButton(1)) 
            speedBurst();
        else
        {
            speed = tempSpeed;
            if (current < max)
                current += Time.deltaTime *5;
        }
    //-------------------------------------------

    }

    void move()
    {
        if (Input.GetKey(KeyCode.D))
        {
            transform.Translate(Vector2.right * speed * Time.deltaTime);
        }

        if (Input.GetKey(KeyCode.A))
        {
            transform.Translate(Vector2.left * speed * Time.deltaTime);
        }

        if (Input.GetKey(KeyCode.W))
        {
            transform.Translate(Vector2.up * speed * Time.deltaTime);
        }

        if (Input.GetKey(KeyCode.S))
        {
            transform.Translate(Vector2.down * speed * Time.deltaTime);
        }
    }
    void dashCooldownText()
    {
        cooldownTimer.text = ((int)current)+"%";
    }
    void speedBurst()
    {
        if (current > 0)
        {
            speed = 8f;
            current -= burnRate * Time.deltaTime;
        }
        else speed = tempSpeed;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        print("the player touch somthing");
        if (collision.tag == "Enemy")
        {
            transform.position = respawnPoint;
            StartCoroutine(waitFrame());
        }
        if(collision.tag == "CheckPoint")
        {
            respawnPoint = new Vector3(transform.position.x, 0f, 0f);
            PlayerPrefs.SetFloat("respawnPoint", transform.position.x);
        }
        if (collision.tag == "toDisplay1")
            isTouch1 = true;
        if (collision.tag == "toDisplay2")
            isTouch2 = true;
        if (collision.tag == "The End")
        {
            respawnPoint = new Vector3(288f, 0f, 0f);
            theEnd = true;
            PlayerPrefs.SetFloat("respawnPoint", 288f);
        }
    }
    IEnumerator waitFrame()
    {
        isDead = true;
        yield return 0;
        isDead = false;
        isTouch1 = false;
        isTouch2 = false;
        theEnd = false;
    }
    IEnumerator waitFrame2()
    {
        yield return 0;
    }
}
