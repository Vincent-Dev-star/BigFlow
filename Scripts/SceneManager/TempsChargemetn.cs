using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class TempsChargemetn : MonoBehaviour
{
    public float speedMovement;
    public GameObject imageRouge;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 movement = new Vector3(1, 0, 0);
        imageRouge.transform.position += movement * Time.deltaTime * speedMovement;
        /*
       
        Debug.Log(imageRouge.transform.position.x);

        if (imageRouge.transform.position.x > -455)
        {
            SceneManager.LoadScene("Lvl1", LoadSceneMode.Single);
        }
        */
    }

    public void NextScene()
    {
        SceneManager.LoadScene("Lvl1", LoadSceneMode.Single);
    }
}
