using UnityEngine;

public class Girar : MonoBehaviour
{
    public float velocidad = 200f;

    void Update()
    {
        transform.Rotate(0, 0, velocidad * Time.deltaTime);
    }
}