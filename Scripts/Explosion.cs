using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explosion : MonoBehaviour
{
    public float timebeforeDestroy;

    // Start is called before the first frame update
    void Start()
    {
        timebeforeDestroy += Time.time;
    }

    // Update is called once per frame
    void Update()
    {
        if(Time.time > timebeforeDestroy)
        {
            Destroy(gameObject);
        }
    }


}
