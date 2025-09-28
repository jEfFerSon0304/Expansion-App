using UnityEngine;

public class ConfirmEndGame : MonoBehaviour
{
    public GameObject confirmPanel;  
    public GameObject mainMenuPanel;  

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
