using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnCorbeau : MonoBehaviour
{
    public float timeSpawn;

    float timeInit;

    public GameObject corbeau;
    // Start is called before the first frame update
    void Start()
    {
        timeInit = Time.time;
    }

    // Update is called once per frame
    void Update()
    {
        if(Time.time > timeSpawn)
        {
            timeSpawn = Random.Range(7,15) + Time.time;

            Instantiate(corbeau, transform.position, Quaternion.identity);
        }
    }


}
