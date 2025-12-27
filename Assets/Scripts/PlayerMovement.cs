using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [Header("Movement Bounds")]
    public float minX = -7f;
    public float maxX = 7f;

    [Header("Movement Settings")]
    public float moveSpeed = 6f;   // Change this from Inspector

    void Update()
    {
        // Stop movement when game is over
        if (GameManager.Instance.gameOver)
            return;

        float input = Input.GetAxis("Horizontal");

        Vector3 move = Vector3.right * input * moveSpeed * Time.deltaTime;
        transform.Translate(move);

        // Clamp player position inside play area
        Vector3 pos = transform.position;
        pos.x = Mathf.Clamp(pos.x, minX, maxX);
        transform.position = pos;
    }
}
