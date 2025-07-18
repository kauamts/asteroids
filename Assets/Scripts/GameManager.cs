using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public GameObject asteroidPrefab;
    public int initialAsteroids = 4;
    public Text scoreText;
    public GameObject gameOverPanel;

    private int score = 0;

    void Awake()
    {
        Instance = this;
    }

    void Start()
    {
        gameOverPanel.SetActive(false);
        score = 0;
        UpdateScore();
        for (int i = 0; i < initialAsteroids; i++)
        {
            SpawnAsteroid();
        }
    }

    public void AddScore(int value)
    {
        score += value;
        UpdateScore();
    }

    void UpdateScore()
    {
        scoreText.text = "Score: " + score;
    }

    public void GameOver()
    {
        gameOverPanel.SetActive(true);
    }

    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    void SpawnAsteroid()
    {
        Vector2 spawnPos = Random.insideUnitCircle.normalized * 6f;
        Instantiate(asteroidPrefab, spawnPos, Quaternion.identity);
    }
} 