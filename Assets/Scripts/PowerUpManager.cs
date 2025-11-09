using System.Collections;
using UnityEngine;

public class PowerUpManager : MonoBehaviour
{
    public static PowerUpManager Instance;
    private Character character;
    private bool isShieldActive = false;

    // Optional tuning values for magnet
    public float magnetRadius = 5f;
    public float magnetForce = 10f;

    void Awake()
    {
        if (Instance == null) Instance = this;
    }

    void Start()
    {
        character = FindObjectOfType<Character>();
    }

    public void ActivatePowerUp(PowerUpType type, float duration)
    {
        switch (type)
        {
            case PowerUpType.SpeedBoost:
                character.SetForwardSpeedMultiplier(1.8f, duration);
                break;
            case PowerUpType.Magnet:
                StartCoroutine(Magnet(duration));
                break;
            case PowerUpType.Shield:
                StartCoroutine(Shield(duration));
                break;
        }
    }

    // 🛡 Shield Power-Up
    private IEnumerator Shield(float duration)
    {
        Debug.Log("🛡 Invincibility activated!");
        isShieldActive = true;

        // Tint player cyan for feedback
        SpriteRenderer sr = character.GetComponent<SpriteRenderer>();
        Color originalColor = sr.color;
        sr.color = Color.cyan;

        // Disable collisions between Player and Obstacle layers
        Physics2D.IgnoreLayerCollision(
            LayerMask.NameToLayer("Player"),
            LayerMask.NameToLayer("Obstacle"),
            true
        );

        yield return new WaitForSeconds(duration);

        // Re-enable collisions
        Physics2D.IgnoreLayerCollision(
            LayerMask.NameToLayer("Player"),
            LayerMask.NameToLayer("Obstacle"),
            false
        );

        sr.color = originalColor;
        isShieldActive = false;
        Debug.Log("🛡 Invincibility ended!");
    }



    // 🧲 Magnet Power-Up
    private IEnumerator Magnet(float duration)
    {
        Debug.Log("🧲 Magnet activated!");
        SpriteRenderer sr = character.GetComponent<SpriteRenderer>();
        Color originalColor = sr.color;
        sr.color = Color.yellow;

        float timer = 0f;
        while (timer < duration)
        {
            timer += Time.deltaTime;

            // Find all coins near the player
            Collider2D[] hits = Physics2D.OverlapCircleAll(character.transform.position, magnetRadius);
            foreach (Collider2D hit in hits)
            {
                if (hit.CompareTag("Coin"))
                {
                    Vector3 dir = (character.transform.position - hit.transform.position).normalized;
                    hit.transform.position += dir * magnetForce * Time.deltaTime;
                }
            }

            yield return null; // wait one frame
        }

        sr.color = originalColor;
        Debug.Log("🧲 Magnet ended!");
    }

    public bool IsShieldActive() => isShieldActive;

    // Optional: visualize the magnet radius in Scene view
    void OnDrawGizmosSelected()
    {
        if (character != null)
        {
            Gizmos.color = Color.yellow;
            Gizmos.DrawWireSphere(character.transform.position, magnetRadius);
        }
    }
}
