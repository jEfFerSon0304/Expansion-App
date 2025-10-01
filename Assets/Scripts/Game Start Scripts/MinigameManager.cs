using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Collections;

public class MinigameManager : MonoBehaviour
{
    [Header("Mini-Game Panels")]
    public GameObject[] minigamePanels;          // Reflex Duel, Lucky Chest
    public GameObject blankPanel;                // full-screen tappable placeholder
    public GameObject roundControllerPanel;      // next panel after blank

    [Header("Reflex Duel UI")]
    public GameObject reflexDuelPanel;
    public TextMeshProUGUI getReadyText;
    public TextMeshProUGUI tapNowText;
    public Button reflexTapButton;
    public GameObject reflexResultPanel;
    public TextMeshProUGUI reflexResultText;

    [Header("Lucky Chest UI")]
    public GameObject luckyChestPanel;
    public Button chest1Button;
    public Button chest2Button;
    public Button chest3Button;
    public GameObject chestResultPanel;
    public TextMeshProUGUI chestResultText;

    private int playerCoins = 0;
    private int currentMinigameIndex = -1;

    void Start()
    {
        // Reflex Duel
        reflexTapButton.onClick.AddListener(OnReflexTap);
        reflexResultPanel.GetComponent<Button>().onClick.AddListener(OnResultPanelTapped);

        // Lucky Chest
        chest1Button.onClick.AddListener(() => OnChestSelected(1));
        chest2Button.onClick.AddListener(() => OnChestSelected(2));
        chest3Button.onClick.AddListener(() => OnChestSelected(3));
        chestResultPanel.GetComponent<Button>().onClick.AddListener(OnResultPanelTapped);

        // Blank Panel tap
        blankPanel.GetComponent<Button>().onClick.AddListener(OnBlankPanelTapped);
    }

    #region Mini-Game Start
    public void StartRandomMinigame()
    {
        foreach (GameObject panel in minigamePanels)
            panel.SetActive(false);

        int randomIndex = Random.Range(0, minigamePanels.Length);
        currentMinigameIndex = randomIndex;

        GameObject selectedPanel = minigamePanels[randomIndex];
        selectedPanel.SetActive(true);

        if (randomIndex == 0) StartCoroutine(StartReflexDuel());
        else if (randomIndex == 1) StartLuckyChest();
    }
    #endregion

    #region Reflex Duel
    private bool canTap = false;  // window when tapping is correct
    private bool hasTapped = false;
    private float lateWindowStart = 0f; // time when "Tap Now!" appeared
    private float maxTapTime = 0.5f;      // duration for correct tap window

    private IEnumerator StartReflexDuel()
    {
        hasTapped = false;
        canTap = false;
        reflexTapButton.interactable = true;

        getReadyText.gameObject.SetActive(true);
        tapNowText.gameObject.SetActive(false);
        reflexResultPanel.SetActive(false);

        // Player can tap early already
        float delay = Random.Range(1f, 3f);
        yield return new WaitForSeconds(delay);

        // Correct window opens
        getReadyText.gameObject.SetActive(false);
        tapNowText.gameObject.SetActive(true);
        canTap = true;
        lateWindowStart = Time.time; // mark when correct window starts
    }

    private void OnReflexTap()
    {
        if (hasTapped) return;
        hasTapped = true;
        reflexTapButton.interactable = false;
        getReadyText.gameObject.SetActive(false);
        tapNowText.gameObject.SetActive(false);

        if (!canTap)
        {
            // Tapped too early
            playerCoins -= 5;
            ShowReflexResult("-5 Coins! Too early!");
            return;
        }

        float elapsedSinceTapNow = Time.time - lateWindowStart;

        if (elapsedSinceTapNow > maxTapTime)
        {
            // Tapped late
            playerCoins -= 5;
            ShowReflexResult("-5 Coins! Too late!");
        }
        else
        {
            // Correct tap
            playerCoins += 10;
            ShowReflexResult("+10 Coins!");
        }
    }

    private void ShowReflexResult(string message)
    {
        reflexResultText.text = message;
        reflexResultPanel.SetActive(true);
    }
    #endregion

    #region Lucky Chest
    private void StartLuckyChest()
    {
        chestResultPanel.SetActive(false);
        chest1Button.interactable = true;
        chest2Button.interactable = true;
        chest3Button.interactable = true;
    }

    private void OnChestSelected(int chestNumber)
    {
        chest1Button.interactable = false;
        chest2Button.interactable = false;
        chest3Button.interactable = false;

        int outcome = Random.Range(0, 2);
        if (outcome == 1)
        {
            playerCoins += 10;
            ShowChestResult($"+10 Coins from Chest {chestNumber}!");
        }
        else
        {
            playerCoins -= 5;
            ShowChestResult($"-5 Coins from Chest {chestNumber}!");
        }
    }

    private void ShowChestResult(string message)
    {
        chestResultText.text = message;
        chestResultPanel.SetActive(true);
    }
    #endregion

    #region Panel Transitions
    private void OnResultPanelTapped()
    {
        // Hide mini-game & result panel
        if (currentMinigameIndex >= 0 && currentMinigameIndex < minigamePanels.Length)
            minigamePanels[currentMinigameIndex].SetActive(false);

        reflexResultPanel.SetActive(false);
        chestResultPanel.SetActive(false);

        // Show blank panel
        blankPanel.SetActive(true);
    }

    private void OnBlankPanelTapped()
    {
        blankPanel.SetActive(false);
        roundControllerPanel.SetActive(true);
    }
    #endregion
}
