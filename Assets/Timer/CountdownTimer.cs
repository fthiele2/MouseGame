using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement; 


public class CountdownTimer : MonoBehaviour
{
    public string SceneToLoad;
    private float currentTime = 60f;
    private Text countdownText;

    public Transform player; 


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
            SceneManager.LoadScene(SceneToLoad);
        }

    }

    void GameOver()
    {
        if (currentTime <= 0 && player.gameObject.tag == "Infected")
        {
            Debug.Log("Game Over");
        }
        else
        {
            Debug.Log("Win");
        }
    }
}
