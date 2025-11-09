using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterLoader : MonoBehaviour
{
    public Sprite[] characterSprites;
    private SpriteRenderer spriteRenderer;

    void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();

        int equippedIndex = PlayerPrefs.GetInt("EquippedCharacter", 0);
        if (equippedIndex >= 0 && equippedIndex < characterSprites.Length)
            spriteRenderer.sprite = characterSprites[equippedIndex];
    }
}

