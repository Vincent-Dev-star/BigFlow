using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class GameOver : MonoBehaviour
{
    public Flower flower;
    public Animator animationGameover;

    public PlanteBlue planteBlue;

    public bool lostGame;

    public GameObject winCanvas;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(planteBlue.winParty && lostGame)
        {
            planteBlue.winParty = false;
        }

        if(flower.barHearth.transform.localPosition.x < -0.16f && !planteBlue.winParty)
        {
            lostGame = true;
            FinishGame();
        }

        if(lostGame)
        {
            winCanvas.SetActive(false);
        }


    }

    void FinishGame()
    {
        animationGameover.SetBool("fini", true  );
    }
}
