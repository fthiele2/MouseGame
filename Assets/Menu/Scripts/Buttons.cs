using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Buttons : MonoBehaviour
{
    public Buttons Settings;
    public GameObject SettingsScreen;

   public void PlayGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1); 
    }

    public void Description()
    {
        Debug.Log("Text");
        SceneManager.LoadScene("DescMenu");
    }

    /*public void Settings()
    {
        Debug.Log("Settings");
        SceneManager.LoadScene(3); 
    }
    */

    
    public void QuitGame()
    {
        Debug.Log("Quit!"); 
        Application.Quit(); 
    }

    public void SettingsInGame()
    {
        Debug.Log("Settings clicked");
        SettingsScreen.SetActive(true);
        Time.timeScale = 0; 

    }
}
