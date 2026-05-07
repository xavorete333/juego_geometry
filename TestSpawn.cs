using UnityEngine;

public class TestSpawn : MonoBehaviour
{
    public GameObject prefab;

    void Start()
    {
        if (prefab == null)
        {
            Debug.LogError("NO ASIGNASTE PREFAB");
            return;
        }

        Instantiate(prefab, new Vector3(0, 0, 0), Quaternion.identity);
        Debug.Log("PREFAB CREADO EN 0,0,0");
    }
}