using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Infection : MonoBehaviour
{
    public Transform bubbles;
    public Transform enemy;
    public Transform player;
    public bool infected = true;
    //public GameObject enemy2;
    public GameObject bubbles2;

    void Start()
    {
        bubbles.GetComponent<ParticleSystem>().Stop();
       
    }

    void OnTriggerEnter(Collider other)
    {
        if (infected == true && other.gameObject.transform.parent.name == player.name)
        {
            bubbles.GetComponent<ParticleSystem>().Play();
            bubbles.transform.parent = other.transform;
            infected = false;
            Debug.Log("Hat funktioniert" + other.gameObject);
            Invoke("SetTrue", 2);
            bubbles2.transform.localPosition = new Vector3(0, 0, 0);
            bubbles2.transform.localScale = new Vector3(1, 1, 1);
        }

        if (infected == true && other.gameObject.transform.parent.name == enemy.name)
        {
            bubbles.GetComponent<ParticleSystem>().Play();
            bubbles.transform.parent = other.transform;
            infected = false;
            Debug.Log("Hat funktioniert" + other.gameObject);
            Invoke("SetTrue2", 2);
            bubbles2.transform.localPosition = new Vector3(0, 0, 0);
            bubbles2.transform.localScale = new Vector3(1, 1, 1);
        }

    }

    void SetTrue()
    {
        player.GetComponent<Infection>().infected = true;
    }

    void SetTrue2()
    {
        enemy.GetComponent<Infection>().infected = true;
    }
}
