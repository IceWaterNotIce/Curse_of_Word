using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyController : MonoBehaviour
{
    private NavMeshAgent navMeshAgent;
    public float health;
    private GameObject player;

    [Header("Enemy prefabs")]

    public GameObject cracked_prefab;

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

    public void TakeDamage(float damage)
    {
        health -= damage;
        // add score 
        GameObject.Find("LevelManager").GetComponent<LevelManager>().AddScore(health > damage ? damage : health);
        if (health <= 0)
        {
            Dead();
        }
    }

    public void Dead()
    {
        GameObject cracked_enemy = Instantiate(cracked_prefab, transform.position, transform.rotation);
        Destroy(gameObject);
        Destroy(cracked_enemy, 2);
    }

}
