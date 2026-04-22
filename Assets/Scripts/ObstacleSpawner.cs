using UnityEngine;

public class ObstacleSpawner : MonoBehaviour
{

    public GameObject spikePrefab;
    public float spawnDistance = 20f;
    public float lastSpawnX;

    void Start()
    {
        lastSpawnX = transform.position.x;
    }

    void Update()
    {

        if (transform.position.x > lastSpawnX - spawnDistance)
        {
            SpawnSpike();
        }

    }

    void SpawnSpike()
    {

        float spawnX = lastSpawnX + Random.Range(6, 10);

        Vector3 position = new Vector3(spawnX, -2, 0);

        Instantiate(spikePrefab, position, Quaternion.identity);

        lastSpawnX = spawnX;

    }

}