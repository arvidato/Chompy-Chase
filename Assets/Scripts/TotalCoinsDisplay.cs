using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TotalCoinsDisplay : MonoBehaviour
{
    public TMP_Text totalCoinsText;

    void Start()
    {
        int totalCoins = PlayerPrefs.GetInt("TotalCoins", 0);
        totalCoinsText.text = $"Total Coins: {totalCoins}";
    }
}
