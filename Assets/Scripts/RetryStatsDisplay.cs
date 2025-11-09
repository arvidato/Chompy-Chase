using UnityEngine;
using TMPro;

public class RetryStatsDisplay : MonoBehaviour
{
    public TMP_Text distanceText;
    public TMP_Text coinsText;

    void Start()
    {
        float lastDistance = PlayerPrefs.GetFloat("LastDistance", 0f);
        int lastCoins = PlayerPrefs.GetInt("LastCoins", 0);

        // Round distance to nearest whole number for display
        distanceText.text = $"Distance: {Mathf.RoundToInt(lastDistance)} m";
        coinsText.text = $"Coins Collected: {lastCoins}";
    }
}
