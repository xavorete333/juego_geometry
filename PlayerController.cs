using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    [Header("Movimiento")]
    public float speed = 5f;
    public void SetSpeed(float newSpeed)
    {
        speed = newSpeed;
    }

    [Header("Salto")]
    public float jumpForce = 10f;

    [Header("Nave")]
    public float flyForce = 4f;

    [Header("Sprites")]
    public Sprite cubeSprite;
    public Sprite shipSprite;

    public bool canMove = true;

    private Rigidbody2D rb;
    private SpriteRenderer sr;

    private bool isGrounded;
    private bool isShipMode = false;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();

        if (cubeSprite != null)
        {
            sr.sprite = cubeSprite;
        }
    }

    void Update()
    {
        if (!canMove) return;

        // Movimiento automático
        rb.linearVelocity = new Vector2(speed, rb.linearVelocity.y);

        // =========================
        // MODO CUBO
        // =========================
        if (!isShipMode)
        {
            if ((Input.GetKey(KeyCode.Space) || Input.GetMouseButton(0)) && isGrounded)
            {
                rb.linearVelocity = new Vector2(rb.linearVelocity.x, jumpForce);

                isGrounded = false;
            }
        }

        // =========================
        // MODO NAVE
        // =========================
        else
        {
            // Subir
            if (Input.GetKey(KeyCode.Space) || Input.GetMouseButton(0))
            {
                rb.linearVelocity = new Vector2(rb.linearVelocity.x, flyForce);
            }
            // Bajar
            else
            {
                rb.linearVelocity = new Vector2(rb.linearVelocity.x, -flyForce);
            }
        }
    }

    // =========================
    // COLISIONES
    // =========================

    void OnCollisionEnter2D(Collision2D col)
    {
        // Piso
        if (col.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
        }

        // Obstáculos
        if (col.gameObject.CompareTag("Obstacle"))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }

    void OnCollisionExit2D(Collision2D col)
    {
        if (col.gameObject.CompareTag("Ground"))
        {
            isGrounded = false;
        }
    }

    // =========================
    // ACTIVAR NAVE
    // =========================

    public void ActivateShipMode()
    {
        isShipMode = true;

        // Evita brinco raro al entrar
        rb.linearVelocity = new Vector2(rb.linearVelocity.x, 0f);

        // Ajuste gravedad nave
        rb.gravityScale = 2.2f;

        // Cambiar sprite a nave
        if (shipSprite != null)
        {
            sr.sprite = shipSprite;
        }
    }

    public void ActivateCubeMode()
    {
        isShipMode = false;

        rb.gravityScale = 3f;

        if (cubeSprite != null)
        {
            sr.sprite = cubeSprite;
        }
    }

    // =========================
    // ORBS
    // =========================

    public void JumpFromOrb(float force)
    {
        rb.linearVelocity = new Vector2(rb.linearVelocity.x, force);
    }
}