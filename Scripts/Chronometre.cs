using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Chronometre : MonoBehaviour
{
    public TextMeshProUGUI chrono;

    float seconde;
    float minute;

    bool passageMinute;

    int countMinute;

    public float timeInit;

    // Start is called before the first frame update
    void Start()
    {
        timeInit = Time.time;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FixedUpdate()
    {
        seconde = (int)Time.time - (60*minute) - (int)timeInit;

        if(seconde % 60 == 0 && passageMinute)
        {
            minute++;
            seconde = 0; 
            passageMinute = false;
        }

        if(seconde > 0)
        {
            passageMinute = true;
        }

        if(minute != 0)
        {
            chrono.text = minute + ":" + seconde;
        }
        else
        {
            chrono.text = "0" + ":" + seconde;
        }
    }
}
