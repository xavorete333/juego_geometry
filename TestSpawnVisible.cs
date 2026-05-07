using UnityEngine;

public class TestSpawnVisible : MonoBehaviour
{
    void Start()
    {
        Vector3 pos = Camera.main.transform.position;
        pos.z = 0;

        GameObject obj = GameObject.CreatePrimitive(PrimitiveType.Cube);
        obj.transform.position = pos;
        obj.transform.localScale = new Vector3(2, 2, 2);

        Debug.Log("CUBO CREADO FRENTE A LA CÁMARA EN " + pos);
    }
}