using UnityEngine;

public class SmartFallingObstacle : MonoBehaviour
{
    public Transform player;
    public float detectionDistance = 4f;
    public float fallSpeed = 5f;

    private bool falling = false;

    void Start()
    {
        if (player == null)
        {
            GameObject p = GameObject.FindGameObjectWithTag("Player");

            if (p != null)
            {
                player = p.transform;
            }
        }
    }

    void Update()
    {
        if (player == null) return;

        if (!falling && Mathf.Abs(transform.position.x - player.position.x) <= detectionDistance)
        {
            falling = true;
        }

        if (falling)
        {
            transform.position += Vector3.down * fallSpeed * Time.deltaTime;
        }
    }
}