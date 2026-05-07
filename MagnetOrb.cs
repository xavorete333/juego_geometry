using UnityEngine;
using System.Collections;

public class MagnetOrb : MonoBehaviour
{
    public Transform target;
    public float pullSpeed = 18f;
    public float stopDistance = 0.25f;

    private bool playerInside = false;
    private PlayerController player;
    private Rigidbody2D rb;
    private Coroutine pullRoutine;

    void Update()
    {
        if (playerInside && rb != null)
        {
            if (Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0))
            {
                if (target != null)
                {
                    if (pullRoutine != null)
                        StopCoroutine(pullRoutine);

                    pullRoutine = StartCoroutine(PullToTarget());
                }
            }
        }
    }

    IEnumerator PullToTarget()
    {
        if (player != null)
        {
            player.canMove = false;
        }

        rb.gravityScale = 0f;
        rb.linearVelocity = Vector2.zero;

        while (target != null && Vector2.Distance(rb.position, target.position) > stopDistance)
        {
            Vector2 newPos = Vector2.MoveTowards(
                rb.position,
                target.position,
                pullSpeed * Time.deltaTime
            );

            rb.MovePosition(newPos);

            yield return null;
        }

        rb.linearVelocity = Vector2.zero;

        if (player != null)
        {
            player.canMove = true;
            player.ActivateShipMode();
        }

        rb.gravityScale = 2.2f;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            playerInside = true;
            player = other.GetComponent<PlayerController>();
            rb = other.GetComponent<Rigidbody2D>();
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            playerInside = false;
        }
    }
}