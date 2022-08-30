using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseController : MonoBehaviour
{
    private bool isRunning; 


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            isRunning = !isRunning;

            if (isRunning)
            {
                Time.timeScale = 0; 
            } 
            else
            {
                Time.timeScale = 1; 
            }
        }
    }
}
