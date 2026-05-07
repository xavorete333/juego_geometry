using UnityEngine;

public class TeleportPortal : MonoBehaviour
{
    public Transform destino;
    public Vector2 offsetSalida = new Vector2(1f, 0f);

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            other.transform.position = destino.position + (Vector3)offsetSalida;
        }
    }
}