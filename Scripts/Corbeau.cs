using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Corbeau : MonoBehaviour
{
    public PlayerController playerController;

    public float speedMovement;

    bool catchPara;

    GameObject parapluie;

    Rigidbody2D paraRigid;

    Vector3 movement;

    AudioSource audioCorb;


    // Start is called before the first frame update
    void Start()
    {
        playerController = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
        movement = new Vector3(1, 0, 0);

        parapluie = GameObject.FindGameObjectWithTag("Para");

        paraRigid = parapluie.GetComponent<Rigidbody2D>();

        audioCorb = GetComponent<AudioSource>();

        audioCorb.Pause();
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void FixedUpdate()
    {
        movement2();

        catchSomething();
    }

    private void catchSomething()
    {
        if(catchPara)
        {
            if (!audioCorb.isPlaying)
            {
                audioCorb.PlayDelayed(0.01f);
            }

            parapluie.transform.position = transform.position;

            paraRigid.gravityScale = 0;
            
            if(transform.position.y >= 0.41f)
            {
                movement = new Vector3(1, 0, 0);
            }
            else
            {
                movement = new Vector3(1, 1, 0);
            }

            if(transform.position.x > 2.4f)
            {
                paraRigid.gravityScale = 1;
                catchPara = false;
            }
       

        }
    }

    void movement2()
    {
        transform.position += movement * Time.deltaTime * speedMovement;

        if(transform.position.x > 4)
        {
            Destroy(this.gameObject);
        }
    }



    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Para" && !playerController.catchParapluieBool)
        {
            catchPara = true;
        }
    }
}
