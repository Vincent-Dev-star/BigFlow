using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponController : MonoBehaviour
{
    public float speedRotation;
    public float angleLimitAttackUp;
    public float angleLimitAttackDown;

    public float indexTime;

    public GameObject player;

    bool boolAttackUp;
    bool boolAttackDown;

    public Collider2D collider2D;

    public PlayerController playerController;

    public SpriteRenderer baton;

    // Start is called before the first frame update
    void Start()
    {
        boolAttackUp = false;
        boolAttackDown = false;
    }

    private void FixedUpdate()
    {
        if(!playerController.catchArrosoireBool && !playerController.catchParapluieBool && !playerController.catchGraineBool)
        {
            Attack();
        }

    }

    void Attack()
    {
        Vector3 rotation = new Vector3(0, 0, 0);

        if (Input.GetMouseButton(0) && boolAttackUp == false)
        {
            transform.position = new Vector3(transform.position.x, player.transform.position.y + 0.01f, transform.position.z);

            if(Time.time > indexTime)
            {
                boolAttackUp = true;
                indexTime = Time.time + 1;
            }
        }
        /*
        else if(Input.GetMouseButton(1) && boolAttackDown == false)
        {
            transform.position = new Vector3(transform.position.x, player.transform.position.y - 0.1f, transform.position.z);

            if (Time.time > indexTime)
            {
                boolAttackDown = true;
                indexTime = Time.time + 1;
            }
        }*/

        if (boolAttackUp)
        {
            //baton.enabled = true;
            collider2D.enabled = true;
            rotation = new Vector3(0,0,-1);
            transform.localEulerAngles += rotation * Time.deltaTime * speedRotation;


            if(transform.localEulerAngles.z < angleLimitAttackUp )
            {
                rotation = new Vector3(0,0,0);
                transform.localEulerAngles = new Vector3(0, 0, 0);


                boolAttackUp = false;
            }
        }
        else if(boolAttackDown)
        {
            //baton.enabled = true;
            collider2D.enabled = true;
            rotation = new Vector3(0, 0, -1);
            transform.localEulerAngles += rotation * Time.deltaTime * speedRotation;


            if (transform.localEulerAngles.z < angleLimitAttackDown)
            {
                rotation = new Vector3(0, 0, 0);
                transform.localEulerAngles = new Vector3(0, 0, 0);

                boolAttackDown = false;
            }
        }
        else
        {
            //baton.enabled = false;
            collider2D.enabled = false;
            transform.localEulerAngles = new Vector3(0,0,0);
            transform.position = new Vector3(transform.position.x, player.transform.position.y - 0.078f, transform.position.z);
        }

    }
}
