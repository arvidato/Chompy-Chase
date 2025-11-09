using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinSpawner : MonoBehaviour
{
    public GameObject coinPrefab; // assign coin prefab
    public float spawnRate = 1.2f; // seconds between spawns
    public float spawnYMin = -1.5f;
    public float spawnYMax = 2.0f;
    public float coinSpeed = 5f; // if coin has Rigidbody2D (Kinematic), we'll set velocity
    public int coinsPerBurst = 1; // set >1 to spawn a vertical group
    public float burstSpacing = 0.5f;

    float timer;

    void Update()
    {
        timer += Time.deltaTime;
        if (timer >= spawnRate)
        {
            SpawnCoins();
            timer = 0f;
        }
    }

    void SpawnCoins()
    {
        float baseY = Random.Range(spawnYMin, spawnYMax);

        for (int i = 0; i < coinsPerBurst; i++)
        {
            Vector3 spawnPos = new Vector3(transform.position.x, baseY + i * burstSpacing, 0f);
            GameObject coin = Instantiate(coinPrefab, spawnPos, Quaternion.identity);

            Rigidbody2D rb = coin.GetComponent<Rigidbody2D>();
            if (rb != null)
            {
                // kinematic or dynamic - set velocity to move left
                rb.velocity = Vector2.left * coinSpeed;
            }

            Destroy(coin, 10f);
        }
    }
}

