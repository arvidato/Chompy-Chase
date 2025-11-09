using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SaveManager : MonoBehaviour
{
    public Transform player;
    public LeaderboardManager leaderboardManager;

    private float playerDistance;

    void Update()
    {
        if (player != null)
            playerDistance = player.position.x; // or .z if you use z-axis
    }

    public void PlayerDied()
    {
        string playerName = PlayerPrefs.GetString("PlayerName", "User1");
        float distance = player.position.x; // or z, depending on your axis
        int coins = ScoreManager.Instance != null ? ScoreManager.Instance.sessionCoins : 0;

        Debug.Log($"Game Over! Saving {playerName}'s score: {distance}m, {coins} coins.");

        // Save to leaderboard
        if (leaderboardManager != null)
            leaderboardManager.AddScore(playerName, distance);

        // Save coins permanently
        if (ScoreManager.Instance != null)
            ScoreManager.Instance.SaveCoinsToTotal();

        // ✅ Save run results for RetryScene display
        PlayerPrefs.SetFloat("LastDistance", distance);
        PlayerPrefs.SetInt("LastCoins", coins);
        PlayerPrefs.Save();

        StartCoroutine(DelayedLoadRetry(0.5f));
    }


    IEnumerator DelayedLoadRetry(float delay)
    {
        yield return new WaitForSeconds(delay);
        SceneManager.LoadScene("RetryScene");
    }
}
