using UnityEngine;
using TMPro;

public class RoundController : MonoBehaviour
{
    [Header("UI References")]
    public TMP_Text eventTypeText;
    public TMP_Text eventNameText;
    public TMP_Text eventDescriptionText;
    public GameObject coverPanel; // 👈 the panel that covers the event area

    private string[] eventTypes = { "Battle", "Trade", "Discovery" };
    private string[] eventNames = { "Orc Ambush", "Merchant Caravan", "Ancient Ruins" };
    private string[] eventDescriptions =
    {
        "A group of orcs attack your party from the forest!",
        "A caravan of merchants offers rare goods at a discount.",
        "You discover the ruins of an ancient civilization."
    };

    private bool firstRound = true;

    void Start()
    {
        // When entering RoundController, show cover panel
        coverPanel.SetActive(true);

        // Clear texts at the start
        eventTypeText.text = "";
        eventNameText.text = "";
        eventDescriptionText.text = "";
    }

    public void NextRound()
    {
        if (firstRound)
        {
            // First click removes the cover, but does not show an event yet
            coverPanel.SetActive(false);
            firstRound = false;
        }

        // Pick a random event
        int randomIndex = Random.Range(0, eventTypes.Length);

        // Update UI with random event
        eventTypeText.text = eventTypes[randomIndex];
        eventNameText.text = eventNames[randomIndex];
        eventDescriptionText.text = eventDescriptions[randomIndex];
    }

    public void ResetRoundController()
    {
        coverPanel.SetActive(true);
        firstRound = true;

        eventTypeText.text = "";
        eventNameText.text = "";
        eventDescriptionText.text = "";
    }


    public void EndGame()
    {
        Debug.Log("Game Ended!");
        // Application.Quit(); // or return to Main Menu scene
    }
}
