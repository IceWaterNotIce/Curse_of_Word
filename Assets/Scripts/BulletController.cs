using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{

    GameObject nearestEnemy = null;
    GameObject[] enemies = null;
    public float damage = 10;
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
                    Destroy(gameObject);
                    nearestEnemy.GetComponent<EnemyController>().TakeDamage(damage);
                }
            }
        }
        else
        {
            Destroy(gameObject);
        }
    }

    
}
