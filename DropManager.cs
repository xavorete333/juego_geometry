using UnityEngine;

public class DropManager : MonoBehaviour
{
    [Header("Música")]
    public AudioSource music;

    [Header("Tiempo del Drop")]
    public float dropTime = 57f;

    [Header("Jugador")]
    public PlayerController player;

    [Header("Velocidad en el Drop")]
    public float darkSpeed = 10f;

    [Header("Fondo Oscuro")]
    public GameObject darkBackground;

    [Header("Objetos del Drop")]
    public GameObject[] activateObjects;

    private bool activated = false;

    void Update()
    {
        if (activated) return;

        if (music != null && music.time >= dropTime)
        {
            ActivateDrop();
        }
    }

    void ActivateDrop()
    {
        activated = true;

        // Aumentar velocidad del jugador
        if (player != null)
        {
            player.SetSpeed(darkSpeed);
        }

        // Fondo oscuro
        if (darkBackground != null)
        {
            darkBackground.SetActive(true);
        }

        // Activar obstáculos y efectos
        foreach (GameObject obj in activateObjects)
        {
            if (obj != null)
            {
                obj.SetActive(true);
            }
        }

        // Zoom de cámara para que se vea más intenso
        if (Camera.main != null)
        {
            Camera.main.orthographicSize = 4f;
        }

        Debug.Log("DROP ACTIVADO");
    }
}