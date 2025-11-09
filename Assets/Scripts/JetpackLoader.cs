using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JetpackLoader : MonoBehaviour
{
    [Header("Jetpack Sprites")]
    public Sprite defaultJetpack;
    public Sprite[] overrideJetpacks; // Optional per-character jetpacks

    private SpriteRenderer spriteRenderer;

    void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();

        int equippedIndex = PlayerPrefs.GetInt("EquippedCharacter", 0);

        // If a specific override exists, use it
        if (equippedIndex >= 0 && equippedIndex < overrideJetpacks.Length && overrideJetpacks[equippedIndex] != null)
        {
            spriteRenderer.sprite = overrideJetpacks[equippedIndex];
        }
        else
        {
            // Otherwise use the default jetpack
            spriteRenderer.sprite = defaultJetpack;
        }
    }
}
