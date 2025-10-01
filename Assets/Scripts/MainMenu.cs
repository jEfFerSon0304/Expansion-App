using UnityEngine;
using UnityEngine.SceneManagement;
using static UnityEngine.Rendering.DebugUI;

public class MainMenu : MonoBehaviour
{
    public GameObject roundController;
    public GameObject howToPlayPanel;
    public GameObject guidePanel;
    public GameObject settingsPanel;
    public AudioClip defaultMusicClip;

    // Start the game (load your first game scene)
    //public void StartGame()
    //{
    //    SceneManager.LoadScene("GameScene"); // Replace with your game scene name
    //}

    public void Start()
    {
        AudioManager.Instance.PlayMusic(defaultMusicClip);
    }

    public void ShowRoundController() { 
        roundController.SetActive(true);
        howToPlayPanel.SetActive(false);
        guidePanel.SetActive(false);
        settingsPanel.SetActive(false);
        gameObject.SetActive(false);

        roundController.GetComponent<RoundController>().ResetRoundController();
    }

    // Show How to Play
    public void ShowHowToPlay()
    {
        howToPlayPanel.SetActive(true);
        roundController.SetActive(false);
        guidePanel.SetActive(false);
        settingsPanel.SetActive(false);
        gameObject.SetActive(false); // hide menu
    }

    // Show Creature & Event Guide
    public void ShowGuide()
    {
        guidePanel.SetActive(true);
        roundController.SetActive(false);
        howToPlayPanel.SetActive(false);
        settingsPanel.SetActive(false);
        gameObject.SetActive(false);
    }

    // Show Settings
    public void ShowSettings()
    {
        settingsPanel.SetActive(true);
        roundController.SetActive(false);
        howToPlayPanel.SetActive(false);
        guidePanel.SetActive(false);
        gameObject.SetActive(false);
    }

    // Go back to Main Menu
    public void BackToMenu()
    {
        roundController.SetActive(false);
        howToPlayPanel.SetActive(false);
        guidePanel.SetActive(false);
        settingsPanel.SetActive(false);
        gameObject.SetActive(true);
    }
}
