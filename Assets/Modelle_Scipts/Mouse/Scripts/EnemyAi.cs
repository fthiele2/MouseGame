using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAi : MonoBehaviour
{
    public UnityEngine.AI.NavMeshAgent enemy; 
    public Transform Player;


    void Start()
    {

    }

    void Update()
    {

        if (gameObject.tag == "Infected")
        {
            enemy.SetDestination(Player.position);
        }
    }

}
