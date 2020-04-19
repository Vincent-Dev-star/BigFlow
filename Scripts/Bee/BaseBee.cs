using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseBee : MonoBehaviour
{
    public float indexTime;

    public GameObject bee;

    float countEnnemy;

    float timeInit;

    // Start is called before the first frame update
    void Start()
    {
        countEnnemy = 1;

        timeInit = Time.time;
    }

    // Update is called once per frame
    void Update()
    {
        if(Time.time > indexTime + timeInit)
        {
            indexTime += Random.Range(10,20);
            CreateBee();
            countEnnemy ++;
        }
    }

    void CreateBee()
    {
        for(int i = 0; i < countEnnemy; i++)
        {
            Instantiate(bee, new Vector3(transform.position.x , transform.position.y, 0), Quaternion.identity);
        }
    }
}
