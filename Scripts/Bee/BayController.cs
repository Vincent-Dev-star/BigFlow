using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BayController : MonoBehaviour
{
    GameObject player;

    public float speedMovement;

    public float heightFlower;

    GameObject flower;

    float x;
    float y;

    AudioSource audioBee;
    bool audioPlay;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        flower = GameObject.Find("Flower");
        audioBee = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Vector2.Distance(player.transform.position, transform.position) <= audioBee.minDistance)
        {
            if (audioPlay)
            {
                audioBee.Play();
                audioPlay = false;

            }
        }
        else
        {
            if (!audioPlay)
            {
                audioBee.Stop();
                audioPlay = true;

            }
        }
    }

    private void FixedUpdate()
    {
        movement();
    }

    private void movement()
    {

        if(transform.position.y > heightFlower + 0.02f)
        {
            y = UnityEngine.Random.Range(-0.1f, -0.3f);
        }
        else if(transform.position.y < heightFlower - 0.02f)
        {
            y = UnityEngine.Random.Range(0.1f, 0.3f);
        }

        if (flower.transform.position.x - transform.position.x <= 0)
        {
            x = 0;

            if ( transform.position.y > flower.transform.position.y + 0.05f)
            {
                y = -2;
            }
            else
            {
                y = 0;
            }
        }
        else
        {
            x = 1;
        }

        Vector3 movement = new Vector3(x,y,0);

        transform.position += movement * Time.deltaTime * speedMovement;
    }
}
