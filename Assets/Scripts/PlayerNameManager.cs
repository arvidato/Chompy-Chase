using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerNameManager : MonoBehaviour
{
    public TMP_Text greetingText;

    private string playerName = "User1";

    void Start()
    {
        // Save it for later use in SaveManager
        PlayerPrefs.SetString("PlayerName", playerName);
        PlayerPrefs.Save();

        // Display it in your main menu
        if (greetingText != null)
            greetingText.text = $"Hello, {playerName}!";
    }
}

