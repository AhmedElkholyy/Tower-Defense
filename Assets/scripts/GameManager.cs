using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public GameObject enemyPrefab;
    public Transform[] spawnPoints;
    public float spawnRate = 2f;
    public Text scoreText;
    private int score = 0;
    

    void Start()
    {
        InvokeRepeating("SpawnEnemy", 1f, spawnRate);
        UpdateScoreText();
    }

    void SpawnEnemy()
    {
        int spawnIndex = Random.Range(0, spawnPoints.Length);
        GameObject newEnemy = Instantiate(enemyPrefab, spawnPoints[spawnIndex].position, Quaternion.identity);
        newEnemy.GetComponent<Enemy>().SetTarget(GameObject.FindGameObjectWithTag("Player").transform);
    }

    public void EnemyKilled()
    {
        score++;
        UpdateScoreText();
        FindObjectOfType<CurrencySystem>().EarnCash(50);
        CheckScoreForSceneChange();
    }

    void UpdateScoreText()
    {
        scoreText.text = "Score: " + score;
    }

   void CheckScoreForSceneChange()
    {
        string currentSceneName = SceneManager.GetActiveScene().name;

        if (score >= 50 && currentSceneName != "EndScene")
        {
            SceneManager.LoadScene("EndScene");
        }
        else if (score >= 30 && currentSceneName == "Level2")
        {
            SceneManager.LoadScene("Level3");
        }
        else if (score >= 20 && currentSceneName == "SampleScene")
        {
            SceneManager.LoadScene("Level2");
        }
    }
}
