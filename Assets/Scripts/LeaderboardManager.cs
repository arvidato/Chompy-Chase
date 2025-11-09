using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using TMPro;

[System.Serializable]
public class ScoreEntry
{
    public string playerName;
    public float score;
    public ScoreEntry(string n, float s) { playerName = n; score = s; }
}

public class LeaderboardManager : MonoBehaviour
{
    public TMP_Text leaderboardText;
    private List<ScoreEntry> topScores = new List<ScoreEntry>();
    private const int MaxEntries = 5;

    private void Awake()
    {
        LoadScores();
        DisplayScores();
    }

    public void AddScore(string playerName, float newScore)
    {
        Debug.Log($"Adding score: {playerName} - {newScore}");
        LoadScores(); // merge with existing
        topScores.Add(new ScoreEntry(playerName, newScore));
        topScores = topScores.OrderByDescending(s => s.score).Take(MaxEntries).ToList();
        SaveScores();
        DisplayScores();
    }

    private void SaveScores()
    {
        PlayerPrefs.SetInt("ScoreCount", topScores.Count);
        for (int i = 0; i < topScores.Count; i++)
        {
            PlayerPrefs.SetString($"Name_{i}", topScores[i].playerName);
            PlayerPrefs.SetFloat($"Score_{i}", topScores[i].score);
        }
        PlayerPrefs.Save();
        Debug.Log("Scores saved!");
    }

    private void LoadScores()
    {
        topScores.Clear();
        int count = PlayerPrefs.GetInt("ScoreCount", 0);
        for (int i = 0; i < count; i++)
        {
            string name = PlayerPrefs.GetString($"Name_{i}", "Anonymous");
            float score = PlayerPrefs.GetFloat($"Score_{i}", 0f);
            topScores.Add(new ScoreEntry(name, score));
        }
    }

    private void DisplayScores()
    {
        if (leaderboardText == null) return;
        leaderboardText.text = "";
        for (int i = 0; i < topScores.Count; i++)
            leaderboardText.text += $"{i + 1}. {topScores[i].playerName} — {Mathf.RoundToInt(topScores[i].score)}m\n";
        Debug.Log("Leaderboard updated on screen");
    }
}
