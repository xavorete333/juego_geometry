using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class GoalSuction : MonoBehaviour
{
    [Header("Succión")]
    public float suctionSpeed = 10f;
    public float rotateSpeed = 1200f;
    public float shrinkSpeed = 1.5f;

    [Header("Final")]
    public float endDuration = 7f;
    public string sceneToLoad = "Menu";

    [Header("Efectos")]
    public ParticleSystem particles;
    public CameraEffects cameraEffects;

    private Rigidbody2D playerRb;
    private PlayerController player;
    private Transform playerTransform;

    private bool absorbing = false;

    void Update()
    {
        transform.Rotate(0, 0, rotateSpeed * Time.deltaTime);

        if (!absorbing || playerRb == null) return;

        Vector2 targetPos = transform.position;

        Vector2 newPos = Vector2.MoveTowards(
            playerRb.position,
            targetPos,
            suctionSpeed * Time.deltaTime
        );

        playerRb.MovePosition(newPos);

        playerTransform.Rotate(0, 0, 800f * Time.deltaTime);

        playerTransform.localScale = Vector3.Lerp(
            playerTransform.localScale,
            Vector3.zero,
            shrinkSpeed * Time.deltaTime
        );
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player") && !absorbing)
        {
            absorbing = true;

            playerRb = other.GetComponent<Rigidbody2D>();
            player = other.GetComponent<PlayerController>();
            playerTransform = other.transform;

            if (player != null)
            {
                player.canMove = false;
            }

            if (playerRb != null)
            {
                playerRb.gravityScale = 0f;
                playerRb.linearVelocity = Vector2.zero;
            }

            if (particles != null)
            {
                particles.Play();
            }

            if (cameraEffects != null)
            {
                cameraEffects.PortalEffect();
            }

            StartCoroutine(FinishSequence());
        }
    }

    IEnumerator FinishSequence()
    {
        yield return new WaitForSeconds(endDuration);

        if (!string.IsNullOrEmpty(sceneToLoad))
        {
            SceneManager.LoadScene(sceneToLoad);
        }
    }
}