using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{

    public void PlayGame()
    {
        SceneManager.LoadScene("GameScene");
    }

    public void GoToLeaderboard()
    {
        SceneManager.LoadScene("LeaderboardScene");
    }

    public void GoToCustomize()
    {
        SceneManager.LoadScene("CustomizeScene");
    }

    public void QuitGame()
    {
        Debug.Log("Quit!");
        Application.Quit();
    }
}
