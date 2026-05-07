using UnityEngine;

public class MusicObstacleSpawner : MonoBehaviour
{
    [System.Serializable]
    public class ObstacleBeat
    {
        public float time;
        public GameObject prefab;

        public Vector2 offset;
    }

    public AudioSource musicSource;

    public Transform player;

    public ObstacleBeat[] obstacles;

    private int index = 0;

    void Update()
    {
        if (musicSource == null || player == null) return;

        if (index >= obstacles.Length) return;

        if (musicSource.time >= obstacles[index].time)
        {
            SpawnObstacle(obstacles[index]);

            index++;
        }
    }

    void SpawnObstacle(ObstacleBeat beat)
    {
        Vector3 spawnPos = new Vector3(
            player.position.x + 15 + beat.offset.x,
            beat.offset.y,
            0
        );

        GameObject obj = Instantiate(
            beat.prefab,
            spawnPos,
            Quaternion.identity
        );

        obj.transform.localScale = new Vector3(0.5f, 0.5f, 0.5f);

        Debug.Log("Obstacle spawned");
    }
}