using UnityEngine;

public class CameraFollow : MonoBehaviour
{

    public Transform player;
    public float offsetX = 5f;

    void Update()
    {

        Vector3 pos = transform.position;

        pos.x = player.position.x + offsetX;

        transform.position = pos;

    }

}