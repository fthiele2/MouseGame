using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Infection : MonoBehaviour
{
    public Transform bubbles;
    public Transform enemy;
    public Transform enemy2;
    public Transform enemy3;
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
            player.gameObject.tag = "Infected";
            this.tag = "NotInfected";
            Debug.Log("" + other.tag);
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
            enemy.gameObject.GetComponent<Infection>().SetTag();
            this.tag = "NotInfected";
            Debug.Log("" + other.tag);
        }

        if (infected == true && other.gameObject.transform.parent.name == enemy2.name)
        {
            bubbles.GetComponent<ParticleSystem>().Play();
            bubbles.transform.parent = other.transform;
            infected = false;
            Debug.Log("Hat funktioniert" + other.gameObject);
            Invoke("SetTrue3", 2);
            bubbles2.transform.localPosition = new Vector3(0, 0, 0);
            bubbles2.transform.localScale = new Vector3(1, 1, 1);
            enemy2.gameObject.GetComponent<Infection>().SetTag();
            this.tag = "NotInfected";
            Debug.Log("" + other.tag);
        }

        if (infected == true && other.gameObject.transform.parent.name == enemy3.name)
        {
            bubbles.GetComponent<ParticleSystem>().Play();
            bubbles.transform.parent = other.transform;
            infected = false;
            Debug.Log("Hat funktioniert" + other.gameObject);
            Invoke("SetTrue4", 2);
            bubbles2.transform.localPosition = new Vector3(0, 0, 0);
            bubbles2.transform.localScale = new Vector3(1, 1, 1);
            enemy3.gameObject.GetComponent<Infection>().SetTag();
            this.tag = "NotInfected";
            Debug.Log("" + other.tag);
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

    void SetTrue3()
    {
        enemy2.GetComponent<Infection>().infected = true;
    }

    void SetTrue4()
    {
        enemy3.GetComponent<Infection>().infected = true;
    }

    void SetTag()
    {
        gameObject.tag = "Infected"; 

    }
}
