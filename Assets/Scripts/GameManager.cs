using UnityEngine;
using TMPro;

public enum DifficultyLevel
{
    Easy,
    Medium,
    Hard
}

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    [Header("Game State")]
    public int lives = 3;
    public float score = 0f;
    public bool gameOver = false;
    public DifficultyLevel currentDifficulty = DifficultyLevel.Easy;

    [Header("UI References")]
    public TMP_Text scoreText;
    public TMP_Text livesText;
    public TMP_Text difficultyText;
    public TMP_Text gameOverText;

    void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
            Destroy(gameObject);
    }

    void Start()
    {
        scoreText.text = "Score: 0";
        livesText.text = "Lives: " + lives;
        difficultyText.text = "Difficulty: Easy";
        gameOverText.gameObject.SetActive(false);
    }

    void Update()
    {
        if (gameOver)
            return;

        // Update score
        score += Time.deltaTime;
        scoreText.text = "Score: " + Mathf.FloorToInt(score);

        // Update difficulty based on score
        UpdateDifficulty();
    }

    void UpdateDifficulty()
    {
        DifficultyLevel newDifficulty;

        if (score < 20)
            newDifficulty = DifficultyLevel.Easy;
        else if (score < 50)
            newDifficulty = DifficultyLevel.Medium;
        else
            newDifficulty = DifficultyLevel.Hard;

        if (newDifficulty != currentDifficulty)
        {
            currentDifficulty = newDifficulty;
            difficultyText.text = "Difficulty: " + currentDifficulty.ToString();
        }
    }

    public void PlayerHit()
    {
        if (gameOver)
            return;

        lives--;
        livesText.text = "Lives: " + lives;

        if (lives <= 0)
        {
            EndGame();
        }
    }

    void EndGame()
    {
        gameOver = true;

        gameOverText.gameObject.SetActive(true);
        gameOverText.text =
            "GAME OVER\nFinal Score: " + Mathf.FloorToInt(score);

        Debug.Log("Game Over");
    }
}
