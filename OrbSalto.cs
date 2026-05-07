using UnityEngine;

public class OrbSalto : MonoBehaviour
{
    public float jumpForce = 12f;

    private bool playerInside = false;
    private Rigidbody2D playerRb;

    void Update()
    {
        if (playerInside)
        {
            if (Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0))
            {
                if (playerRb != null)
                {
                    playerRb.linearVelocity = new Vector2(playerRb.linearVelocity.x, jumpForce);
                }
            }
        }
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