using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flower : MonoBehaviour
{
    public GameObject barHearth;

    public float speedLost;
    public float speedWin;
    public float speedLostCloud;

    public Nuage nuage;

    bool attackFlower;

    public arrosoireController arrosoireController;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (attackFlower && barHearth.transform.localPosition.x >= -0.162f) 
        {
            lostHeight();
        }

        if(arrosoireController.soigneFlower && barHearth.transform.localPosition.x < 0f)
        {
            winHeight();
        }

        attackByCloud();
    }

    private void winHeight()
    {
        Vector3 movement = new Vector3(1, 0, 0);
        barHearth.transform.position += movement * Time.deltaTime * speedWin;
    }

    void lostHeight()
    {
        Vector3 movement = new Vector3(1, 0, 0);
        barHearth.transform.position -= movement * Time.deltaTime * speedLost;
    }

    void attackByCloud()
    {
        if (nuage.touchSomething)
        {
            Vector3 movement = new Vector3(1, 0, 0);
            barHearth.transform.position -= movement * Time.deltaTime * speedLostCloud;

            if(barHearth.transform.localPosition.x <= -0.157f)
            {
                nuage.touchSomething = false;
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "bay")
        {
            attackFlower = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.tag == "bay")
        {
            attackFlower = false;
        }
    }

}
