using UnityEngine;

public class BeatEffect : MonoBehaviour
{
    public MusicReactive musicReactive;

    private SpriteRenderer sr;

    public float glowIntensity = 5f;

    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        if (musicReactive == null || sr == null)
            return;

        float amp = musicReactive.GetAmplitude();

        float glow = 1 + amp * glowIntensity;

        Color baseColor = Color.cyan;

        sr.color = baseColor * glow;
    }
}