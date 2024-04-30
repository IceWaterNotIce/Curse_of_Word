using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    public float radius = 30f;

    public GameObject enemy;
    private GameObject player;
    public GameObject paper;

    public float enemyStartTime = 1f;
    public float enemyRepeatTime = 5f;
    public int maxPaper = 5;

    public float paperStartTime = 1f;
    public float paperRepeatTime = 10f;

    // set the max number of enemies and mushrooms
    public int maxEnemies = 10;

    public int score = 0;

    [Header("UI")]
    [SerializeField] private GameObject SettingPanel;
    [SerializeField] private GameObject gameOverPanel;
    [SerializeField] private Button restartButton;
    [SerializeField] private TextMeshProUGUI txtScore;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (Time.timeScale == 0)
            {
                ResumeGame();
            }
            else
            {
                StopGame();
            }
        }
    }


    private void Start()
    {
        player = GameObject.Find("Player");
        AddScore(0);
        InvokeRepeating("SpawnEnemy", enemyStartTime, enemyRepeatTime);
        InvokeRepeating("SpawnPaper", paperStartTime, paperRepeatTime);
    }
    private void SpawnPaper()
    {
        if (GameObject.FindGameObjectsWithTag("Paper").Length >= maxPaper)
        {
            return;
        }

        Vector3 spawnPoint = RandomNavMeshLocation(radius);

        if (spawnPoint != Vector3.zero)
        {
            Instantiate(paper, spawnPoint, Quaternion.identity);
        }
    }
    private void SpawnEnemy()
    {

        if (GameObject.FindGameObjectsWithTag("Enemy").Length >= maxEnemies)
        {
            return;
        }

        Vector3 spawnPoint = RandomNavMeshLocation(radius);

        if (spawnPoint != Vector3.zero)
        {
            Instantiate(enemy, spawnPoint, Quaternion.identity);
        }
    }

    private Vector3 RandomNavMeshLocation(float radius)
    {
        Vector3 randomPoint = Random.insideUnitSphere * radius;
        randomPoint += player.transform.position;

        NavMeshHit hit;
        Vector3 finalPosition = Vector3.zero;

        if (NavMesh.SamplePosition(randomPoint, out hit, radius, 1))
        {
            finalPosition = hit.position;
        }

        return finalPosition;
    }

    public void GameOver()
    {
        Time.timeScale = 0;
        gameOverPanel.SetActive(true);
    }
    public void RestartGame()
    {
        //reload the scene
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        Time.timeScale = 1;
        gameOverPanel.SetActive(false);
    }

    public void StopGame()
    {
        Time.timeScale = 0;
        // setting panel active
        SettingPanel.SetActive(true);
    }

    public void ResumeGame()
    {
        Time.timeScale = 1;
        SettingPanel.SetActive(false);
    }

    public void AddScore(int value)
    {
        score += value;
        txtScore.text = "Score: " + score;
    }
}
