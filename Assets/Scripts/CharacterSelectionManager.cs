using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class CharacterSelectionManager : MonoBehaviour
{
    [Header("UI References")]
    public Image characterPreview;
    public TMP_Text characterNameText;
    public TMP_Text characterDescriptionText; // 🆕 Description text

    [Header("Character Data")]
    public Sprite[] characterOptions;
    public string[] characterNames;
    [TextArea(2, 4)] public string[] characterDescriptions; // 🆕 Multi-line text

    private int currentIndex = 0;

    void Start()
    {
        currentIndex = PlayerPrefs.GetInt("EquippedCharacter", 0);
        UpdatePreview();
    }

    public void NextCharacter()
    {
        currentIndex++;
        if (currentIndex >= characterOptions.Length)
            currentIndex = 0;
        UpdatePreview();
    }

    public void PreviousCharacter()
    {
        currentIndex--;
        if (currentIndex < 0)
            currentIndex = characterOptions.Length - 1;
        UpdatePreview();
    }

    public void EquipCharacter()
    {
        PlayerPrefs.SetInt("EquippedCharacter", currentIndex);
        PlayerPrefs.Save();
        Debug.Log($"✅ Equipped Character: {characterNames[currentIndex]}");
    }

    public void BackToMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }

    private void UpdatePreview()
    {
        if (characterPreview != null)
            characterPreview.sprite = characterOptions[currentIndex];

        if (characterNameText != null && currentIndex < characterNames.Length)
            characterNameText.text = characterNames[currentIndex];

        if (characterDescriptionText != null && currentIndex < characterDescriptions.Length)
            characterDescriptionText.text = characterDescriptions[currentIndex];
    }
}
