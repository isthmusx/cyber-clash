using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class EndGame : MonoBehaviour
{
    public TMP_Text victoryText;
    public TMP_Text victorySubText;
    public GameObject mainTextObject;
    public GameObject subTextObject;
    public GameObject background;
    public GameObject continueBTN;
    public GameObject turnText;
    public GameObject rewardsText;
    public GameObject rewards;
    public TMP_Text coinText;
    
    public static bool isWin;
    public GameObject surrenderWindow;

    public GameObject coinsWon;
    public bool gotCoins;
    public bool gotExp;
    
    public AudioSource audioSource;
    public AudioClip winMusic;
    public AudioClip loseMusic;
    public AudioClip surrenderMusic;

    //public MainMenu menu;

    void Start()
    {
        mainTextObject.SetActive(false);
        subTextObject.SetActive(false);
        background.SetActive(false);
        turnText.SetActive(true);
        continueBTN.SetActive(false);
        rewardsText.SetActive(false);
        rewards.SetActive(false);

        gotCoins = false;
        gotExp = false;
        
        GameObject musicObject = GameObject.Find("Music"); // Change "MusicObject" to the name of the GameObject containing the AudioSource

        if (musicObject != null)
        {
            // Get the AudioSource component
            AudioSource musicSource = musicObject.GetComponent<AudioSource>();

            // Stop the music if the AudioSource component exists and is playing
            if (musicSource != null && musicSource.isPlaying)
            {
                musicSource.Stop();
            }
        }

    }

    void Update()
    {
        
        if (EnemyHealth.staticHP <= 0)
        {
            isWin = true;
            mainTextObject.SetActive(true);
            subTextObject.SetActive(true);
            background.SetActive(true);
            turnText.SetActive(false);
            continueBTN.SetActive(true);
            rewardsText.SetActive(true);
            rewards.SetActive(true);
            victoryText.text = "<color=#08BDBD>Victory</color>";
            
            if (MainMenu.faction == "Threat")
            {
                victorySubText.text = "You have successfully breached the system.";
            }
            else if (MainMenu.faction == "Security")
            {
                victorySubText.text = "You have successfully defended the system.";
            }

            if (gotCoins == false)
            {
                coinsWon.GetComponent<Shop>().coins += 1000;
                coinText.text = "1000";
                gotCoins = true;
            }
            if (gotExp == false)
            {
                EXPController.WonEXP();
                gotExp = true;
                
            }
            audioSource.PlayOneShot(winMusic);

        }
        
        if (PlayerHealth.staticHP <= 0)
        {
            isWin = false;
            mainTextObject.SetActive(true);
            subTextObject.SetActive(true);
            background.SetActive(true);
            turnText.SetActive(false);
            continueBTN.SetActive(true);
            rewardsText.SetActive(true);
            rewards.SetActive(true);
            victoryText.text = "<color=#F21B3F>Defeat</color>";
            if (MainMenu.faction == "Threat")
            {
                victorySubText.text = "You have failed to breach the system.";
            }
            else if (MainMenu.faction == "Security")
            {
                victorySubText.text = "You have failed to defend the system.";
            }

            if (gotCoins == false)
            {
                coinsWon.GetComponent<Shop>().coins += 200;
                coinText.text = "200";
                gotCoins = true;
            }
            
            if (gotExp == false)
            {
                EXPController.WonEXP();
                gotExp = true;
            }
            audioSource.PlayOneShot(loseMusic);

        }
        
    }

    public void Surrender()
    {
        StartCoroutine(EndGameNow());
    }
    IEnumerator EndGameNow()
    {
        audioSource.PlayOneShot(surrenderMusic);
        mainTextObject.SetActive(true);
        subTextObject.SetActive(true);
        background.SetActive(true);
        turnText.SetActive(false);
        continueBTN.SetActive(true);
        rewardsText.SetActive(true);
        rewards.SetActive(true);
        victoryText.text = "<color=#F21B3F>Defeat</color>";
        if (MainMenu.faction == "Threat")
        {
            victorySubText.text = "You have failed to breach the system.";
        }
        else if (MainMenu.faction == "Security")
        {
            victorySubText.text = "You have failed to defend the system.";
        }

        if (gotCoins == false)
        {
            coinsWon.GetComponent<Shop>().coins += 200;
            coinText.text = "200";
            gotCoins = true;
        }
        
            
        surrenderWindow.SetActive(false);

        yield return new WaitForSeconds(5f);
        SceneManager.LoadScene("Main Menu");
    }
    

}
