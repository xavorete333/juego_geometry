using UnityEngine;

public class ChainBooster : MonoBehaviour
{
    public Transform target;
    public float launchSpeed = 200f;

    private bool playerInside;
    private Rigidbody2D playerRb;

    void Update()
    {
        if (playerInside && playerRb != null)
        {
            if (Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0))
            {
                LaunchPlayer();
            }
        }
    }

    void LaunchPlayer()
    {
        if (target == null) return;

        Vector2 direction = ((Vector2)target.position - playerRb.position).normalized;

        playerRb.gravityScale = 0.2f; // para que no caiga tanto en el trayecto
        playerRb.linearVelocity = direction * launchSpeed;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            playerInside = true;
            playerRb = other.GetComponent<Rigidbody2D>();
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            playerInside = false;
            playerRb = null;
        }
    }
}