using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharacterUILoader : MonoBehaviour
{
    public Image characterImage; // Assign your UI Image here
    public Sprite[] characterSprites;

    void Start()
    {
        int equippedIndex = PlayerPrefs.GetInt("EquippedCharacter", 0);
        if (equippedIndex >= 0 && equippedIndex < characterSprites.Length)
        {
            characterImage.sprite = characterSprites[equippedIndex];
        }
        else
        {
            Debug.LogWarning("⚠ No valid character index found in PlayerPrefs!");
        }
    }
}
