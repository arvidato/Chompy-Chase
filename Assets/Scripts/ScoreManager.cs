using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager Instance;

    public int sessionCoins = 0;       // Coins earned this run
    public int totalCoins = 0;         // All-time total
    public TextMeshProUGUI scoreText;

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);

            SceneManager.sceneLoaded += OnSceneLoaded;

            // Load total coins when game starts
            totalCoins = PlayerPrefs.GetInt("TotalCoins", 0);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void Start()
    {
        UpdateUI();
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        GameObject obj = GameObject.Find("ScoreText");
        if (obj != null)
        {
            scoreText = obj.GetComponent<TextMeshProUGUI>();
            UpdateUI();
        }
    }

    public void AddScore(int amount)
    {
        sessionCoins += amount;
        UpdateUI();
    }

    public void SaveCoinsToTotal()
    {
        totalCoins += sessionCoins;
        PlayerPrefs.SetInt("TotalCoins", totalCoins);
        PlayerPrefs.Save();
        Debug.Log($"💰 Saved total coins: {totalCoins}");

        // reset for next run
        sessionCoins = 0;
        UpdateUI();
    }

    public void ResetScore()
    {
        sessionCoins = 0;
        UpdateUI();
    }

    void UpdateUI()
    {
        if (scoreText != null)
            scoreText.text = sessionCoins.ToString();
    }
}
