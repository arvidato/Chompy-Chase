using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
    public float thrustForce = 5f;
    public float forwardSpeed = 2f;
    public Rigidbody2D rb;
    public ParticleSystem ps;
    public SaveManager saveManager;

    private ParticleSystem.EmissionModule psEmission;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        psEmission = ps.emission;
    }

    void Update()
    {
        Vector2 velocity = rb.velocity;
        velocity.x = forwardSpeed;
        rb.velocity = velocity;

        if (Input.GetKey(KeyCode.Space) || Input.GetMouseButton(0))
        {
            rb.AddForce(Vector2.up * thrustForce, ForceMode2D.Force);
            psEmission.enabled = true;
        }
        else
        {
            psEmission.enabled = false;
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Obstacle"))
        {
            // 🛡 If shield power-up is active, ignore damage
            if (PowerUpManager.Instance != null && PowerUpManager.Instance.IsShieldActive())
            {
                Debug.Log("🛡 Shield protected from obstacle!");
                return;
            }

            Debug.Log("Character hit obstacle!");
            rb.simulated = false;
            saveManager.PlayerDied();
        }
    }

    // Optional helper (used by magnet, etc.)
    public void SetForwardSpeedMultiplier(float multiplier, float duration)
    {
        StartCoroutine(SpeedBoost(multiplier, duration));
    }

    private IEnumerator SpeedBoost(float multiplier, float duration)
    {
        float originalSpeed = forwardSpeed;
        forwardSpeed *= multiplier;
        Debug.Log("⚡ Speed boosted!");
        yield return new WaitForSeconds(duration);
        forwardSpeed = originalSpeed;
        Debug.Log("Speed boost ended.");
    }
}
