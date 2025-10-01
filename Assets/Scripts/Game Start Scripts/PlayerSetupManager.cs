using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Collections.Generic;

public class PlayerSetupManager : MonoBehaviour
{
    [Header("UI Panels")]
    public GameObject playerCountPanel;
    public GameObject playerNamesPanel;
    public GameObject gameStartPanel;

    [Header("Player Count")]
    public TMP_Dropdown playerCountDropdown;

    [Header("Player Name Entry")]
    public TextMeshProUGUI playerPromptText;
    public TMP_InputField playerNameInput;
    public Button nextButton;

    [Header("Game Start")]
    public TextMeshProUGUI selectedPlayerText;
    public TextMeshProUGUI tapToContinueText;
    public Button tapButton;

    [HideInInspector]
    public List<string> playerNames = new List<string>();

    private int totalPlayers;
    private int currentPlayerIndex = 0;
    private string currentSelectedPlayer;

    public MinigameManager minigameManager;

    void Start()
    {
        playerCountPanel.SetActive(true);
        playerNamesPanel.SetActive(false);
        gameStartPanel.SetActive(false);

        nextButton.onClick.AddListener(OnNextButtonClicked);
        tapButton.onClick.AddListener(OnTapToContinue);
    }

    // Called by Confirm Button
    public void ConfirmPlayerCount()
    {
        totalPlayers = playerCountDropdown.value + 2; // dropdown min is 2
        currentPlayerIndex = 0;
        playerNames.Clear();

        playerCountPanel.SetActive(false);
        playerNamesPanel.SetActive(true);

        UpdatePlayerPrompt();
    }

    public void OnNextButtonClicked()
    {
        string enteredName = playerNameInput.text.Trim();

        if (string.IsNullOrEmpty(enteredName))
        {
            Debug.LogWarning("Player name cannot be empty!");
            return;
        }

        playerNames.Add(enteredName);
        playerNameInput.text = "";
        currentPlayerIndex++;

        if (currentPlayerIndex < totalPlayers)
        {
            UpdatePlayerPrompt();
        }
        else
        {
            ShowGameStart();
        }
    }

    void UpdatePlayerPrompt()
    {
        playerPromptText.text = $"Enter Player {currentPlayerIndex + 1} Name:";

        if (currentPlayerIndex == totalPlayers - 1)
            nextButton.GetComponentInChildren<TextMeshProUGUI>().text = "Start";
        else
            nextButton.GetComponentInChildren<TextMeshProUGUI>().text = "Next";
    }

    void ShowGameStart()
    {
        playerNamesPanel.SetActive(false);
        gameStartPanel.SetActive(true);

        // Randomly select a player
        currentSelectedPlayer = playerNames[Random.Range(0, playerNames.Count)];
        selectedPlayerText.text = $"Player {currentSelectedPlayer} is selected!";
        tapToContinueText.text = "Tap the screen to continue";
    }

    public void OnTapToContinue()
    {
        gameStartPanel.SetActive(false);

        // Tell MinigameManager to start a random minigame
        minigameManager.StartRandomMinigame();
    }
}
