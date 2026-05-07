using UnityEngine;

public class ZigzagPortal : MonoBehaviour
{
    public Transform exitPortal;
    public Vector2 exitOffset = new Vector2(1f, 0f);

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player") && exitPortal != null)
        {
            Rigidbody2D rb = other.GetComponent<Rigidbody2D>();

            other.transform.position = exitPortal.position + (Vector3)exitOffset;

            if (rb != null)
            {
                rb.linearVelocity = new Vector2(rb.linearVelocity.x, 0f);
            }
        }
    }
}