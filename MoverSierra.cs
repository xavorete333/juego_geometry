using UnityEngine;

public class MoverSierra : MonoBehaviour
{
    public float velocidad = 2f;
    public float distancia = 3f;
    public bool vertical = false;

    private Vector3 posicionInicial;
    private bool ida = true;

    void Start()
    {
        posicionInicial = transform.position;
    }

    void Update()
    {
        if (!vertical)
        {
            // Horizontal
            if (ida)
            {
                transform.Translate(Vector2.right * velocidad * Time.deltaTime);
                if (transform.position.x >= posicionInicial.x + distancia) ida = false;
            }
            else
            {
                transform.Translate(Vector2.left * velocidad * Time.deltaTime);
                if (transform.position.x <= posicionInicial.x - distancia) ida = true;
            }
        }
        else
        {
            // Vertical
            if (ida)
            {
                transform.Translate(Vector2.up * velocidad * Time.deltaTime);
                if (transform.position.y >= posicionInicial.y + distancia) ida = false;
            }
            else
            {
                transform.Translate(Vector2.down * velocidad * Time.deltaTime);
                if (transform.position.y <= posicionInicial.y - distancia) ida = true;
            }
        }
    }
}