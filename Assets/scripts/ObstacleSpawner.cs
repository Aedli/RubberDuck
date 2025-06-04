using UnityEngine;

public class ObstacleSpawner : MonoBehaviour
{
    public GameObject[] obstaclePrefabs;//생성될 장애물 프리팹
    public Transform playerTransform;//플레이어 Transform
    public float spawnInterval = 2f;//생성 간격
    public float spawnRangeX = 5;// x좌표 랜덤 범위
    public float spawnOffsetZ = 20f;//플레이어 기준 앞쪽 생성 거리

    private float timer;

    void Update()
    {
        timer += Time.deltaTime;

        if(timer >= spawnInterval)
        {
            SpawnObstacle();
            timer = 0f;
        }
    }

    void SpawnObstacle()
    {
        float randomX = Random.Range(-spawnRangeX, spawnRangeX);
        Vector3 spawnPos = new Vector3(randomX, 0.1f, playerTransform.position.z + spawnOffsetZ);
        
        int randomIndex = Random.Range(0, obstaclePrefabs.Length);
        GameObject selectedPrefab = obstaclePrefabs[randomIndex];

        Instantiate(selectedPrefab, spawnPos, Quaternion.identity);
    }
}

