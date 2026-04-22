using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{

    public float jumpForce = 12f;
    public float speed = 6f;

    public GameObject deathEffect;

    Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {

        // movimiento autom�tico
        rb.linearVelocity = new Vector2(speed, rb.linearVelocity.y);

        // detectar suelo con raycast
        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.down, 1.1f);

        bool grounded = hit.collider != null;

        // salto
        if (Input.GetMouseButtonDown(0) && grounded)
        {
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, jumpForce);
        }

    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Spike"))
        {
            Die();
        }
    }

    void Die()
    {

        Instantiate(deathEffect, transform.position, Quaternion.identity);

        Destroy(gameObject);

        Invoke("Restart", 1f);

    }

    void Restart()
    {

        SceneManager.LoadScene(SceneManager.GetActiveScene().name);

    }

}