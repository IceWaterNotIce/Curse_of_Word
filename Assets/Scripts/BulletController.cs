using System.Collections;
using System.Collections.Generic;
using UnityEditor.SearchService;
using UnityEngine;

public class Bullet : MonoBehaviour
{

    GameObject nearestEnemy = null;
    GameObject[] enemies = null;
    // Start is called before the first frame update
    void Start()
    {
        enemies = GameObject.FindGameObjectsWithTag("Enemy");
        float minDistance = Mathf.Infinity;
        foreach (GameObject enemy in enemies)
        {
            float distance = Vector3.Distance(transform.position, enemy.transform.position);
            if (distance < minDistance)
            {
                minDistance = distance;
                nearestEnemy = enemy;
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (nearestEnemy != null)
        {
            Vector3 direction = nearestEnemy.transform.position - transform.position;
            transform.Translate(direction.normalized * Time.deltaTime * 10);

            // destroy the bullet if it touches the enemy
            {
                if (Vector3.Distance(transform.position, nearestEnemy.transform.position) < 0.5f)
                {
                    //addscore
                    GameObject.Find("LevelManager").GetComponent<LevelManager>().AddScore(1);
                    Destroy(gameObject);
                    Destroy(nearestEnemy);
                }
            }
        }
        else
        {
            Destroy(gameObject);
        }
    }

    
}
