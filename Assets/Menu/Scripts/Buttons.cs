using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Buttons : MonoBehaviour
{
    public Buttons Settings;
    public GameObject SettingsScreen;
    public GameObject DescriptionScreen;
    public GameObject ReturnButton; 

    public int RestartScene;
    public int ReturnScene; 


   public void PlayGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1); 
    }
    
    public void QuitGame()
    {
        Debug.Log("Quit!"); 
        Application.Quit(); 
    }

    //ReturnButton
    public void ReturnArrow()
    {
        Debug.Log("Return klicked");
        DescriptionScreen.SetActive(false);
        SettingsScreen.SetActive(false); 
    }


   //Menu

    public void Description()
    {
        Debug.Log("Description clicked");
        DescriptionScreen.SetActive(true);
        ReturnButton.SetActive(true); 
    }
    
    
    //IngameSettings

    public void SettingsInGame()
    {
        Debug.Log("Settings clicked");
        SettingsScreen.SetActive(true);
        Time.timeScale = 0;
        ReturnButton.SetActive(true);
    }

    public void SettingsTurnOff()
    {
        Debug.Log("SettingsDisabled");
        SettingsScreen.SetActive(false);
        Time.timeScale = 1; 
    }

    //EndScreenButtons
    public void InGameRestart()
    {
        SceneManager.LoadScene(RestartScene); 
    }

    public void InGameReturn()
    {
        SceneManager.LoadScene(ReturnScene); 
    } 
}
