using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpSpawner : MonoBehaviour
{
    public GameObject[] powerUpPrefabs;
    public float spawnRate = 10f;
    public float spawnYMin = -2f;
    public float spawnYMax = 2f;

    private float timer;

    void Update()
    {
        timer += Time.deltaTime;
        if (timer >= spawnRate)
        {
            SpawnPowerUp();
            timer = 0f;
        }
    }

    void SpawnPowerUp()
    {
        float yPos = Random.Range(spawnYMin, spawnYMax);
        int index = Random.Range(0, powerUpPrefabs.Length);
        Vector3 pos = new Vector3(transform.position.x, yPos, 0f);
        Instantiate(powerUpPrefabs[index], pos, Quaternion.identity);
    }
}

