using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BackButton : MonoBehaviour
{
    public void BackToMenu()
    {
        Debug.Log("Returning to Main Menu");
        Time.timeScale = 1f;
        SceneManager.LoadScene("MainMenu");
    }
}
