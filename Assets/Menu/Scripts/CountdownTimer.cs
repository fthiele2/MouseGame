using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement; 


public class CountdownTimer : MonoBehaviour
{
    private float currentTime = 5f;
    bool currentTimeActive = true;
    private bool gameRunning; 
    private Text countdownText;
    public Transform player;

    public GameObject GameOverScreen;
    public GameObject GameWinScreen;
    public GameObject Background; 


    // Use this for initialization
    void Start()
    {
        countdownText = GetComponent<Text>();
        currentTimeActive = currentTime >= 0; 
    }

    // Update is called once per frame
    void Update()
    {
        if (currentTimeActive == true)
        {
            currentTime -= Time.deltaTime;
            countdownText.text = currentTime.ToString("f0");
        }

        if (currentTime <= 0)
        {
            GameOver();
            Background.SetActive(true);
            currentTimeActive = false;
        }
    }

    void GameOver()
    {
        if(currentTime <= 0 && player.gameObject.tag == "Infected")
        {
            Debug.Log("GameOver");
            GameOverScreen.SetActive(true);
        }

        else
        {
            Debug.Log("Win");
            GameWinScreen.SetActive(true);
        }
    }
}
