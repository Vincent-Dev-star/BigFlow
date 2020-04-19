using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Nuage : MonoBehaviour
{
    public int timeBeforeCreate;

    public int timeBeforeNext;

    public float timeBeforeHideCloud;

    //public int timeBefore

    public Animator animationCloud;

    SpriteRenderer cloud;

    public bool touchSomething;

    public GameObject parapluie;
    public GameObject Flower;

    public PlayerController playerController;

    public float timeInit;

    // Start is called before the first frame update
    void Start()
    {
        cloud = GetComponent<SpriteRenderer>();
        cloud.enabled = false;
        timeInit = Time.time;
    }

    // Update is called once per frame
    void Update()
    {
        CreateCloud();
    }

    void CreateCloud()
    {
        if(Time.time > timeBeforeCreate + timeInit)
        {
            timeBeforeCreate += timeBeforeNext;
            cloud.enabled = true;
            animationCloud.SetBool("Cloud", true);
        }

        if (Time.time > timeBeforeHideCloud + timeInit)
        {
            timeBeforeHideCloud +=  timeBeforeNext;
            cloud.enabled = false;
            animationCloud.SetBool("Cloud", false);
        }
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if((collision.tag == "Flower") && ((Vector2.Distance(parapluie.transform.position, Flower.transform.position) > 0.145f)))
        {
            touchSomething = true;
        }
        
    }
}
