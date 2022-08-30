using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement; 


public class CountdownTimer : MonoBehaviour
{
    private float currentTime = 5f;
    private Text countdownText;
    public Transform player;

    public GameObject GameOverScreen;
    public GameObject GameWinScreen;
    public GameObject Background; 


    // Use this for initialization
    void Start()
    {
        countdownText = GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        currentTime -= Time.deltaTime;
        countdownText.text = currentTime.ToString("f0");
        if (currentTime <= 0)
        {
            GameOver();
            Background.SetActive(true);
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
            GameOverScreen.SetActive(true);
        }
    }
}
