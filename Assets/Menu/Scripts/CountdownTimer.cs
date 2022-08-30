using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.Events; 


public class CountdownTimer : MonoBehaviour
{
    public UnityEvent GameStop;
    public UnityEvent GameContinue; 

    private float currentTime = 5f;
    bool currentTimeActive = true;
    private Text countdownText;
    public Transform player;

    public GameObject GameOverScreen;
    public GameObject GameWinScreen;
    public GameObject Background;
    public GameObject SettingsScreen;

    private bool isRunning;


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
            StopGame();

            currentTime -= Time.deltaTime;
            countdownText.text = currentTime.ToString("f0");
        }

        if (currentTime <= 0 && currentTimeActive == true)
        {
            GameOver();
            Background.SetActive(true);
            
       

        
                Time.timeScale = 0;
                Debug.Log("Game has stopped");
                currentTimeActive = false;
        
        }
    }

    void GameOver()
    {
        if (currentTime <= 0 && player.gameObject.tag == "Infected")
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

    void StopGame()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            isRunning = !isRunning;

            if (isRunning)
            {
                Time.timeScale = 0;
                Debug.Log("Stop");
                GameStop.Invoke();
            }
            else
            {
                Time.timeScale = 1;
                Debug.Log("Continue");
                GameContinue.Invoke();
            }
        }
    }
}
