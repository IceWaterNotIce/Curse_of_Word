using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyController : MonoBehaviour
{
    private NavMeshAgent navMeshAgent;

    private GameObject player;

    private void Start() 
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
        player = GameObject.Find("Player");    
    }

    private void Update() 
    {
        navMeshAgent.SetDestination(player.transform.position);
    }

    private void OnTriggerEnter(Collider other) 
    {
        if (other.gameObject.CompareTag("Player"))
        {
            player.GetComponent<PlayerController>().AddHealth(-10);
        }
    }

}
