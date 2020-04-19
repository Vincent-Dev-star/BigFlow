using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class arrosoireController : MonoBehaviour
{
    public ParticleSystem particleSystemWater;
    public ParticleSystem particleSystemWaterRobinet;


    public PlayerController playerController;

    bool water = false;

    public GameObject robinet;

    public GameObject barWater;

    public float speedMoveBarWaterUp;
    public float speedMoveBarWaterDown;

    public GameObject player;

    public GameObject waterBar;

    public bool soigneFlower;
    public bool pouceFlower;


    public GameObject flower;
    public GameObject flowerBlue;

    bool robinetOuvert;

    AudioSource audioWater;
    bool audioPlay;
    // Start is called before the first frame update
    void Start()
    {
        audioPlay = false;
        robinetOuvert = false;
        audioWater = GetComponent<AudioSource>();
            
    }

    private void Awake()
    {
        particleSystemWater.Pause();
        particleSystemWaterRobinet.Pause();
    }

    // Update is called once per frame
    void Update()
    {
        activeWater();

        if(playerController.catchArrosoireBool)
        {
            remplirArrosoire();

            if (player.transform.localScale.x == -1)
            {
                waterBar.transform.localScale = new Vector3(-1, 1, 1);
            }
            else
            {
                waterBar.transform.localScale = new Vector3(1, 1, 1);
            }
        }




    }

    private void remplirArrosoire()
    {
        if((Vector2.Distance(transform.position, robinet.transform.position) < 0.075f) && barWater.transform.localPosition.x < 0)
        {
            barWater.transform.position += new Vector3(1, 0, 0) * Time.deltaTime * speedMoveBarWaterUp;

            if (!robinetOuvert)
            {
                particleSystemWaterRobinet.Play();
                robinetOuvert = true;
            }
        }
        else
        {
            if (robinetOuvert)
            {
                particleSystemWaterRobinet.Stop();
                robinetOuvert = false;
            }
        }
    }

    void activeWater()
    {
        if (Input.GetMouseButtonDown(0) && !water && !(barWater.transform.localPosition.x <= -0.155f) && playerController.catchArrosoireBool)
        {
            water = true;
            particleSystemWater.Play();


        }
        else if ((Input.GetMouseButtonUp(0) && water) || (barWater.transform.localPosition.x <= -0.15f) || !playerController.catchArrosoireBool)
        {
            water = false;
            particleSystemWater.Stop();
            soigneFlower = false;
            pouceFlower = false;
        }

  

        if (water && barWater.transform.localPosition.x > -0.152f)
        {
            barWater.transform.position -= new Vector3(1, 0, 0) * Time.deltaTime * speedMoveBarWaterDown;
            if(audioPlay)
            {
                audioWater.Play();
                audioPlay = false;
            }
            soignerPlante();
        }
        else
        {
            if (!audioPlay)
            {
                audioWater.Stop();
                audioPlay = true;
            }
        }

    }

    void soignerPlante()
    {
        if (Vector2.Distance(transform.position, flower.transform.position) <= 0.24f && Vector2.Distance(transform.position, flower.transform.position) >= 0.14f)
        {
            soigneFlower = true;
        }
        else if(Vector2.Distance(transform.position, flowerBlue.transform.position) <= 0.24f && Vector2.Distance(transform.position, flowerBlue.transform.position) >= 0.1f)
        {
            pouceFlower = true;
        }
    }


}
