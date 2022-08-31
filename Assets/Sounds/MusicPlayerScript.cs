using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicPlayerScript : MonoBehaviour
{
    public AudioSource Music;
    private float musicVolume = 1f; 

    // Start is called before the first frame update
    void Start()
    {
        Music.Play(); 
    }

    // Update is called once per frame
    void Update()
    {
        Music.volume = musicVolume; 
    }

    public void changeVolume(float volume)
    {
        musicVolume = volume; 
    }
}
