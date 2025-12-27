using UnityEngine;
using static GameManager;

public class Spawner : MonoBehaviour
{
    public GameObject fallingObject;
    public float spawnRange = 6f;

    float timer;

    void Update()
    {
        if (GameManager.Instance.gameOver) return;
        if (fallingObject == null) return;

        timer += Time.deltaTime;

        float spawnRate = GetSpawnRate();

        if (timer >= spawnRate)
        {
            SpawnObject();
            timer = 0f;
        }
    }

    float GetSpawnRate()
    {
        switch (GameManager.Instance.currentDifficulty)
        {
            case DifficultyLevel.Easy:
                return 1.5f;
            case DifficultyLevel.Medium:
                return 1.0f;
            case DifficultyLevel.Hard:
                return 0.5f;
            default:
                return 1.5f;
        }
    }

    void SpawnObject()
    {
        Vector3 spawnPos = new Vector3(
            Random.Range(-spawnRange, spawnRange),
            transform.position.y,
            0f
        );

        Instantiate(fallingObject, spawnPos, Quaternion.identity);
    }
}
