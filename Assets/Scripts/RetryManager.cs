using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RetryManager : MonoBehaviour
{
    public void Retry()
    {
        Debug.Log("Retry button pressed!");
        Time.timeScale = 1f; // reset pause
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void BackToMenu()
    {
        Debug.Log("Returning to Main Menu");
        Time.timeScale = 1f;
        SceneManager.LoadScene("MainMenu");
    }

    public void QuitGame()
    {
        Debug.Log("Quit!");
        Application.Quit();
    }
}

