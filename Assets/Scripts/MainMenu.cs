using UnityEngine;
using UnityEngine.SceneManagement;
using static UnityEngine.Rendering.DebugUI;

public class MainMenu : MonoBehaviour
{
    public GameObject howToPlayPanel;
    public GameObject guidePanel;
    public GameObject settingsPanel;

    // Start the game (load your first game scene)
    public void StartGame()
    {
        SceneManager.LoadScene("GameScene"); // Replace with your game scene name
    }

    // Show How to Play
    public void ShowHowToPlay()
    {
        howToPlayPanel.SetActive(true);
        gameObject.SetActive(false); // hide menu
    }

    // Show Creature & Event Guide
    public void ShowGuide()
    {
        guidePanel.SetActive(true);
        gameObject.SetActive(false);
    }

    // Show Settings
    public void ShowSettings()
    {
        settingsPanel.SetActive(true);
        gameObject.SetActive(false);
    }

    // Go back to Main Menu
    public void BackToMenu()
    {
        howToPlayPanel.SetActive(false);
        guidePanel.SetActive(false);
        settingsPanel.SetActive(false);
        gameObject.SetActive(true);
    }
}
