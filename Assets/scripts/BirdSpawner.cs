using UnityEngine;

public class BirdSpawner : MonoBehaviour
{
    public GameObject birdPrefab;
    public float spawnInterval = 4f;
    private float timer = 0f;

    private void Update()
    {
        timer += Time.deltaTime;

        if (timer >= spawnInterval)
        {
            SpawnBird();
            timer = 0f;
        }
    }

    void SpawnBird()
    {
        // z좌표는 0~190 랜덤, y=10, x=-10 고정 (BirdDropper에서 이동 시작)
        float randomZ = Random.Range(0f, 190f);
        Vector3 spawnPosition = new Vector3(-10f, 10f, randomZ);
        Instantiate(birdPrefab, spawnPosition, Quaternion.identity);
    }
}
