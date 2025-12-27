using UnityEngine;
using static GameManager;

public class FallingObject : MonoBehaviour
{
    Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();

        float speed = GetFallSpeed();
        rb.linearVelocity = Vector3.down * speed;
    }

    float GetFallSpeed()
    {
        switch (GameManager.Instance.currentDifficulty)
        {
            case DifficultyLevel.Easy:
                return 4f;
            case DifficultyLevel.Medium:
                return 6f;
            case DifficultyLevel.Hard:
                return 8f;
            default:
                return 4f;
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Ground"))
        {
            Destroy(gameObject);
        }
    }
}
