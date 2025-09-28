using UnityEngine;

public class ConfirmEndGame : MonoBehaviour
{
    public GameObject confirmPanel;   // Your confirm popup panel
    public GameObject mainMenuPanel;  // Your main menu panel

    // Show confirmation popup
    public void ShowConfirmPanel()
    {
        confirmPanel.SetActive(true);
    }

    // Player clicked "Yes"
    public void ConfirmYes()
    {
        // Hide confirm panel
        confirmPanel.SetActive(false);

        // Show main menu again
        mainMenuPanel.SetActive(true);
    }

    // Player clicked "No"
    public void ConfirmNo()
    {
        // Just hide the confirmation popup
        confirmPanel.SetActive(false);
    }
}
