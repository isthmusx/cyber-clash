using System;
using System.Text.RegularExpressions;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UsernameManager : MonoBehaviour
{
    public TMP_InputField nameInputField;
    public GameObject nameInputPanel;
    public GameObject mainMenuPanel;
    public TMP_Text userText;
    public TMP_Text modalText;
    public GameObject modalPanel;

    private void Start()
    {
        if (PlayerPrefs.HasKey("PlayerName"))
        {
            nameInputPanel.SetActive(false);
            mainMenuPanel.SetActive(true);

            userText.text = PlayerPrefs.GetString("PlayerName");

        }
        else
        {
            nameInputPanel.SetActive(true); 
            mainMenuPanel.SetActive(false);

        }
    }

    public void Update()
    {
        userText.text = PlayerPrefs.GetString("PlayerName");

    }

    public void SaveUsername()
    {
        string playerName = nameInputField.text;

        if (string.IsNullOrEmpty(playerName) || string.IsNullOrWhiteSpace(playerName))
        {
            modalText.text = "Enter a username.";
            modalPanel.SetActive(true);
        }
        else
        {
            if (Regex.IsMatch(playerName, @"[^a-zA-Z0-9\s]"))
            {
                modalText.text = "Username cannot contain symbols.";
                modalPanel.SetActive(true);
            }
            else
            {
                PlayerPrefs.SetString("PlayerName", playerName);
                PlayerPrefs.Save();

                nameInputPanel.SetActive(false);
                mainMenuPanel.SetActive(true);
            }
        }
    }
}