using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UsernameManager : MonoBehaviour
{
    public TMP_InputField nameInputField;
    public GameObject nameInputPanel;
    public GameObject mainMenuPanel;
    public TMP_Text userText;

    private void Start()
    {
        
        // Check if the name is already saved
        if (PlayerPrefs.HasKey("PlayerName"))
        {
            // If the name is already saved, hide the input panel
            nameInputPanel.SetActive(false);
            mainMenuPanel.SetActive(true);

            userText.text = PlayerPrefs.GetString("PlayerName");

        }
        else
        {
            // If the name is not saved, show the input panel
            nameInputPanel.SetActive(true); 
            mainMenuPanel.SetActive(false);

        }
    }

    public void SaveUsername()
    {
        // Save the username when the user clicks the save button
        string playerName = nameInputField.text;
        PlayerPrefs.SetString("PlayerName", playerName);
        PlayerPrefs.Save();

        // Hide the input panel
        nameInputPanel.SetActive(false);
        mainMenuPanel.SetActive(true);
    }
}