using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    public int value = 1;
    public AudioClip collectSound;               // optional: assign in prefab
    public GameObject collectParticlePrefab;     // optional: particle prefab

    void OnTriggerEnter2D(Collider2D other)
    {
        if (!other.CompareTag("Player")) return;

        // Add score
        ScoreManager.Instance.AddScore(value);

        // Play sound (safe even if collectSound is null)
        if (collectSound != null) AudioSource.PlayClipAtPoint(collectSound, transform.position);

        // Spawn particle effect (optional)
        if (collectParticlePrefab != null)
            Instantiate(collectParticlePrefab, transform.position, Quaternion.identity);

        // Destroy coin
        Destroy(gameObject);
    }
}

