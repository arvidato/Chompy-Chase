using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleSpawner : MonoBehaviour
{
    public GameObject obstaclePrefab;
    public float spawnRate = 2f;
    public float spawnYMin = -2f;
    public float spawnYMax = 2f;
    public float obstacleSpeed = 5f;

    private float timer;

    void Update()
    {
        timer += Time.deltaTime;
        if (timer >= spawnRate)
        {
            SpawnObstacle();
            timer = 0f;
        }
    }

    void SpawnObstacle()
    {
        float randomY = Random.Range(spawnYMin, spawnYMax);
        Vector3 spawnPos = new Vector3(transform.position.x, randomY, 0f);

        //rotation of the obstacle
        Quaternion randomRotation = Quaternion.Euler(0f, 0f, Random.Range(0f, 360f));

        GameObject obstacle = Instantiate(obstaclePrefab, spawnPos, randomRotation);

        
        Rigidbody2D rb = obstacle.GetComponent<Rigidbody2D>();
        if (rb != null)
        {
            rb.velocity = Vector2.left * obstacleSpeed;
        }

        // Destroy after 10s to save memory
        Destroy(obstacle, 10f);
    }
}
