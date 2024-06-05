using System;
using System.Text.RegularExpressions;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UsernameManager : MonoBehaviour
{
    public TMP_InputField nameInputField;
    public GameObject nameInputPanel;
    public GameObject mainMenuPanel;
    public GameObject tutorialPanel;
    public TMP_Text userText;
    public TMP_Text modalText;
    public GameObject modalPanel;
    public GameObject modalPanel2;

    private GameObject musicObject;

    private void Awake()
    {
        if (SceneManager.GetActiveScene().name == "Main Menu")
        {
            // Find the GameObject with the AudioSource component
            musicObject = GameObject.Find("Music");
            if (musicObject != null)
            {
                AudioSource musicSource = musicObject.GetComponent<AudioSource>();

                // If AudioSource component exists and is not already playing, start playing
                if (musicSource != null && !musicSource.isPlaying)
                {
                    musicSource.Play();
                }
            }
        }
    }

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

                modalPanel2.SetActive(true);
                
            }
        }
    }
}