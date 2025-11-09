using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterPowerUpManager : MonoBehaviour
{
    private PowerUpManager powerUpManager;
    private Character character;

    [Header("Default Power-up Duration (seconds)")]
    public float powerUpDuration = 5f;

    void Start()
    {
        powerUpManager = PowerUpManager.Instance;
        character = FindObjectOfType<Character>();

        if (powerUpManager == null)
        {
            Debug.LogError("⚠️ PowerUpManager not found in scene!");
            return;
        }

        int selectedIndex = PlayerPrefs.GetInt("EquippedCharacter", 0);
        ApplyStartingPowerUp(selectedIndex);
    }

    void ApplyStartingPowerUp(int index)
    {
        // 0–3 → no power-ups
        if (index >= 0 && index <= 3)
        {
            Debug.Log($"ℹ️ Character {index} starts with no power-ups.");
            return;
        }

        // 4–5 → Speed Boost
        if (index >= 4 && index <= 5)
        {
            powerUpManager.ActivatePowerUp(PowerUpType.SpeedBoost, powerUpDuration);
            Debug.Log($"⚡ Character {index} gets a Speed Boost!");
            return;
        }

        // 6–7 → Magnet (Money)
        if (index >= 6 && index <= 7)
        {
            powerUpManager.ActivatePowerUp(PowerUpType.Magnet, powerUpDuration);
            Debug.Log($"🧲 Character {index} gets a Magnet (Money) power-up!");
            return;
        }

        // 8–9 → Shield (Invulnerability)
        if (index >= 8 && index <= 9)
        {
            powerUpManager.ActivatePowerUp(PowerUpType.Shield, powerUpDuration);
            Debug.Log($"🛡️ Character {index} gets Invulnerability (Shield)!");
            return;
        }

        // 10+ → All three
        if (index >= 10)
        {
            powerUpManager.ActivatePowerUp(PowerUpType.SpeedBoost, powerUpDuration);
            powerUpManager.ActivatePowerUp(PowerUpType.Magnet, powerUpDuration);
            powerUpManager.ActivatePowerUp(PowerUpType.Shield, powerUpDuration);
            Debug.Log($"💥 Character {index} gets ALL power-ups!");
        }
    }
}
