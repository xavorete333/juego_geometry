using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class WinManager : MonoBehaviour
{
    [Header("Referencias")]
    public GameObject winEffect;
    public PlayerController player;
    public Camera mainCamera;
    public ScreenFlash flash;

    [Header("Configuración")]
    public float delay = 3f;

    private bool hasWon = false;

    public void Win()
    {
        if (hasWon) return;
        hasWon = true;

        Debug.Log("GANASTE 🔥");

        // 🛑 Detener jugador
        if (player != null)
        {
            player.canMove = false;
        }

        // 📳 Vibración SOLO en celular (ARREGLADO)
#if UNITY_ANDROID || UNITY_IOS
        Handheld.Vibrate();
#endif

        // ✨ PARTÍCULAS
        if (winEffect != null && mainCamera != null)
        {
            Vector3 pos = mainCamera.transform.position;
            pos.z = 0f;

            GameObject effect = Instantiate(winEffect, pos, Quaternion.identity);
            effect.SetActive(true);

            ParticleSystem ps = effect.GetComponent<ParticleSystem>();
            if (ps != null)
            {
                ps.Play();
            }
        }

        // ⚡ FLASH
        if (flash != null)
        {
            flash.Flash();
        }

        // 🎥 SHAKE DE CÁMARA
        if (mainCamera != null)
        {
            mainCamera.gameObject.AddComponent<CameraShake>();
        }

        // ⏸ PAUSA DEL JUEGO
        Time.timeScale = 0f;

        // ⏳ IR A ESCENA FINAL
        StartCoroutine(GoToFinalScene());
    }

    IEnumerator GoToFinalScene()
    {
        yield return new WaitForSecondsRealtime(delay);

        Time.timeScale = 1f;
        SceneManager.LoadScene("FinalScene");
    }
}