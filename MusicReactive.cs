using UnityEngine;

public class MusicReactive : MonoBehaviour
{
    public AudioSource audioSource;

    private float[] samples = new float[256];

    public float GetAmplitude()
    {
        audioSource.GetOutputData(samples, 0);

        float sum = 0;

        for (int i = 0; i < samples.Length; i++)
        {
            sum += Mathf.Abs(samples[i]);
        }

        return sum / samples.Length;
    }
}