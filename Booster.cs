using UnityEngine;

public class Booster : MonoBehaviour
{
    public Transform target;
    public float force = 12f;
    public CameraEffects cameraEffects;

    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            if (Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0))
            {
                Rigidbody2D rb = other.GetComponent<Rigidbody2D>();

                if (rb != null && target != null)
                {
                    Vector2 dir = (target.position - other.transform.position).normalized;

                    rb.linearVelocity = Vector2.zero;
                    rb.AddForce(dir * force, ForceMode2D.Impulse);

                    if (cameraEffects != null)
                    {
                        cameraEffects.JumpEffect();
                    }
                }
            }
        }
    }
}