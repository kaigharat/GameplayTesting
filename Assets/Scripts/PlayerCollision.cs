using UnityEngine;

public class PlayerCollision : MonoBehaviour
{
    Vector3 startPosition;

    void Start()
    {
        startPosition = transform.position;
    }

    void OnTriggerEnter(Collider other)
    {
        Debug.Log("Triggered with: " + other.name);

        if (other.CompareTag("Enemy") && !GameManager.Instance.gameOver)
        {
            Destroy(other.gameObject);

            GameManager.Instance.PlayerHit();

            transform.position = startPosition;
        }
    }
}
