using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Animator animationCharacter;


    public float speedMovement;
    public float forceJump;
    public float forceGravity;
    public float limitJump;

    public GameObject arrosoire;
    public GameObject parapluie;
    public GameObject graine;


    //float distance;

    public Camera cameraPlayer;

    float y = 0;

    float scaleX = 1;

    public bool catchArrosoireBool;
    public bool catchParapluieBool;
    public bool catchGraineBool;



    public GameObject btnEArrosoire;
    public GameObject btnEParapluie;
    public GameObject btnEGraine;


    public bool conflicObject;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        followCamera();

        if(conflicObject)
        {
            catchArrosoire();
        }
        else
        {
            catchArrosoire();
            catchParapluie();
            if(graine!=null)
            {
                catchGraine();
            }
            else
            {
                catchGraineBool = false;
            }
        }

        limitOnThing();
    }

    private void limitOnThing()
    {
        if(catchArrosoireBool && catchParapluieBool)
        {
            conflicObject = true;
        }
        else
        {
            conflicObject = false;
        }
    }

    private void FixedUpdate()
    {
        movementPlayer();
    }

    void movementPlayer()
    {
        //InputPlayer
        float x = Input.GetAxisRaw("Horizontal");

        if(x != 0)
        {
            animationCharacter.SetBool("Walk", true);
        }
        else
        {
            animationCharacter.SetBool("Walk", false);
        }
        //float y = Input.GetAxisRaw("Vertical");

        //RotatePlayer
        if (x < 0)
        {
            scaleX = -1;
        }
        else if (x > 0)
        {
            scaleX = 1;
        }

        transform.localScale = new Vector3(scaleX, transform.localScale.y , transform.localScale.z);

        //MovementPlayer

        if (Input.GetKey(KeyCode.Space) && transform.position.y <= 0)
        {
            y = 1 * forceJump;
        }
        else if(transform.position.y >= limitJump)
        {
            y = 0;
        }

        if(y == 0 && transform.position.y > 0)
        {
            transform.position -= new Vector3(0, 1, 0) * Time.deltaTime * forceGravity;
            
        }

        if(transform.position.y < 0)
        {
            transform.position = new Vector3(transform.position.x, 0,0);
        }

        Vector3 movement = new Vector3(x, y, 0);
        

        if(transform.position.x < 3.01f )
        {
            transform.position += movement * Time.deltaTime * speedMovement;
        }
        else
        {
            transform.position = new Vector3(3.009f, transform.position.y,0);
        }

        if (transform.position.x > -1.22f)
        {
            transform.position += movement * Time.deltaTime * speedMovement;
        }
        else
        {
            transform.position = new Vector3(-1.219f, transform.position.y, 0);
        }

    }

    void followCamera()
    {
        if(transform.position.x > cameraPlayer.transform.position.x + 0.3f && transform.position.x < 2.65f)
        {
            cameraPlayer.transform.position = new Vector3(transform.position.x - 0.3f, cameraPlayer.transform.position.y, cameraPlayer.transform.position.z);
        }
        else if(transform.position.x < cameraPlayer.transform.position.x - 0.3f)
        {
            cameraPlayer.transform.position = new Vector3(transform.position.x + 0.3f, cameraPlayer.transform.position.y, cameraPlayer.transform.position.z);
        }
    }

    void catchArrosoire()
    {
        //Debug.Log("distance: " + Vector2.Distance(transform.position, arrosoire.transform.position));

        if (Vector2.Distance(transform.position, arrosoire.transform.position) < 0.094f)
        {
            if(!catchArrosoireBool)
            {
                btnEArrosoire.SetActive(true);
            }else
            {
                btnEArrosoire.SetActive(false);
            }

            if(Input.GetKeyDown(KeyCode.E))
            {
                catchArrosoireBool = !catchArrosoireBool;
            }
        }
        else
        {
            btnEArrosoire.SetActive(false);
        }

        if(catchArrosoireBool)
        {
            
            if(transform.localScale.x == 1)
            {
                arrosoire.transform.position = new Vector3(transform.position.x + 0.09f, transform.position.y, 0);
                arrosoire.transform.localScale = new Vector3(1, 1, 1);
                btnEArrosoire.transform.localScale = new Vector3(1, 1, 1);
            }
            else if(transform.localScale.x == -1)
            {
                arrosoire.transform.localScale = new Vector3(-1, 1, 1);
                arrosoire.transform.position = new Vector3(transform.position.x - 0.08f, transform.position.y, 0);
                btnEArrosoire.transform.localScale = new Vector3(-1,1,1);
            }
        }
        else
        {
            arrosoire.transform.position = new Vector3(arrosoire.transform.position.x, -0.028f, 0);
        }
    }

    void catchParapluie()
    {
        //Debug.Log("distance: " + Vector2.Distance(transform.position, arrosoire.transform.position));

        if (Vector2.Distance(transform.position, parapluie.transform.position) < 0.094f)
        {
            if (!catchParapluieBool)
            {
                btnEParapluie.SetActive(true);
            }
            else
            {
                btnEParapluie.SetActive(false);
            }

            if (Input.GetKeyDown(KeyCode.E))
            {
                catchParapluieBool = !catchParapluieBool;
            }
        }
        else
        {
            btnEParapluie.SetActive(false);
        }

        if (catchParapluieBool)
        {

            if (transform.localScale.x == 1)
            {
                parapluie.transform.position = new Vector3(transform.position.x + 0.09f, transform.position.y, 0);
                parapluie.transform.localScale = new Vector3(1, 1, 1);
                btnEParapluie.transform.localScale = new Vector3(1, 1, 1);
            }
            else if (transform.localScale.x == -1)
            {
                parapluie.transform.localScale = new Vector3(-1, 1, 1);
                parapluie.transform.position = new Vector3(transform.position.x - 0.08f, transform.position.y, 0);
                btnEParapluie.transform.localScale = new Vector3(-1, 1, 1);
            }
        }
    }

    void catchGraine()
    {
        //Debug.Log("distance: " + Vector2.Distance(transform.position, arrosoire.transform.position));

        if (Vector2.Distance(transform.position, graine.transform.position) < 0.094f)
        {
            if (!catchGraineBool)
            {
                btnEGraine.SetActive(true);
            }
            else
            {
                btnEGraine.SetActive(false);
            }

            if (Input.GetKeyDown(KeyCode.E))
            {
                catchGraineBool = !catchGraineBool;
            }
        }
        else
        {
            btnEGraine.SetActive(false);
        }

        if (catchGraineBool)
        {

            if (transform.localScale.x == 1)
            {
                graine.transform.position = new Vector3(transform.position.x + 0.09f, transform.position.y, 0);
                graine.transform.localScale = new Vector3(1, 1, 1);
                btnEGraine.transform.localScale = new Vector3(1, 1, 1);
            }
            else if (transform.localScale.x == -1)
            {
                graine.transform.localScale = new Vector3(-1, 1, 1);
                graine.transform.position = new Vector3(transform.position.x - 0.08f, transform.position.y, 0);
                btnEGraine.transform.localScale = new Vector3(-1, 1, 1);
            }
        }
        else
        {
            graine.transform.position = new Vector3(graine.transform.position.x, -0.028f, 0);
        }
    }
}
