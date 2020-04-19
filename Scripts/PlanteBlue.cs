using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlanteBlue : MonoBehaviour
{
    bool grainePlanter;

    public SpriteRenderer planteBlue;
    public SpriteMask maskPlanteBlue;

    public GameOver gameOver;

    public float speedUp;

    public bool winParty;

    public Animator animationWinGame;

    public GameObject lostCanvas;

    public arrosoireController arrosoireController;

    // Start is called before the first frame update
    void Start()
    {
        grainePlanter = false;
        planteBlue.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        showGraine();

        if(winParty && !gameOver.lostGame)
        {
            WinParty();
        }
    }

    void showGraine()
    {
        if (grainePlanter)
        {
            planteBlue.enabled = true;
            progressShowPlant();
        }
    }

    void progressShowPlant()
    {
        Vector3 movment = new Vector3(0,1,0);

        if(arrosoireController.pouceFlower)
        {
            maskPlanteBlue.transform.position += movment * Time.deltaTime * speedUp * 0.1f;
        }

        if (maskPlanteBlue.transform.localPosition.y > 0.335f)
        {
            winParty = true;
        }

        if(winParty)
        {
            lostCanvas.SetActive(false);
        }
    }

    void WinParty()
    {
        animationWinGame.SetBool("fini", true);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Graine")
        {
            Destroy(collision.gameObject);
            grainePlanter = true;
        }
    }
}