using UnityEngine;

public class ObstacleSpawner : MonoBehaviour
{
    public GameObject[] obstaclePrefabs;//������ ��ֹ� ������
    public Transform playerTransform;//�÷��̾� Transform
    public float spawnInterval = 2f;//���� ����
    public float spawnRangeX = 5;// x��ǥ ���� ����
    public float spawnOffsetZ = 20f;//�÷��̾� ���� ���� ���� �Ÿ�

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

