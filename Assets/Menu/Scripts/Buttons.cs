using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Buttons : MonoBehaviour
{
    public Buttons Settings;
    public GameObject SettingsScreen;
    public int RestartScene;
    public int ReturnScene; 

   public void PlayGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1); 
    }

    public void Description()
    {
        Debug.Log("Text");
        SceneManager.LoadScene("DescMenu");
    }
    
    public void QuitGame()
    {
        Debug.Log("Quit!"); 
        Application.Quit(); 
    }

    //IngameSettings

    public void SettingsInGame()
    {
        Debug.Log("Settings clicked");
        SettingsScreen.SetActive(true);
        Time.timeScale = 0; 
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
