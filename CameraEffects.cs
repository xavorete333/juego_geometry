using UnityEngine;
using System.Collections;

public class CameraEffects : MonoBehaviour
{
    public float zoomAmount = 3.8f;
    public float zoomTime = 0.12f;
    public float shakeAmount = 0.15f;
    public float shakeTime = 0.2f;

    private Camera cam;
    private float originalSize;
    private Vector3 originalPos;

    void Start()
    {
        cam = GetComponent<Camera>();
        originalSize = cam.orthographicSize;
        originalPos = transform.position;
    }

    public void JumpEffect()
    {
        StopAllCoroutines();
        StartCoroutine(ZoomEffect());
        StartCoroutine(ShakeEffect());
    }

    public void PortalEffect()
    {
        StopAllCoroutines();
        StartCoroutine(ZoomEffect());
        StartCoroutine(ShakeEffect());
    }

    IEnumerator ZoomEffect()
    {
        cam.orthographicSize = zoomAmount;
        yield return new WaitForSeconds(zoomTime);
        cam.orthographicSize = originalSize;
    }

    IEnumerator ShakeEffect()
    {
        float timer = 0f;

        while (timer < shakeTime)
        {
            timer += Time.deltaTime;

            transform.position = originalPos + new Vector3(
                Random.Range(-shakeAmount, shakeAmount),
                Random.Range(-shakeAmount, shakeAmount),
                0
            );

            yield return null;
        }

        transform.position = originalPos;
    }
}