using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Buttons : MonoBehaviour
{
   public void PlayGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1); 
    }

    public void Description()
    {
        Debug.Log("Text");
        SceneManager.LoadScene("DescMenu");
    }

    public void Settings()
    {
        Debug.Log("Settings");
        SceneManager.LoadScene(3); 
    }

    
    public void QuitGame()
    {
        Debug.Log("Quit!"); 
        Application.Quit(); 
    }
}
