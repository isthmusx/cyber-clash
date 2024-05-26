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
    
    public AudioSource winMusic;
    public AudioSource loseMusic;
    public AudioSource surrenderMusic;
    
    private bool isWinMusicPlaying = false;
    private bool isLoseMusicPlaying = false;

    //public MainMenu menu;

    void Start()
    {
        Time.timeScale = 1;
        mainTextObject.SetActive(false);
        subTextObject.SetActive(false);
        background.SetActive(false);
        turnText.SetActive(true);
        continueBTN.SetActive(false);
        rewardsText.SetActive(false);
        rewards.SetActive(false);

        gotCoins = false;
        gotExp = false;
        
        GameObject musicObject = GameObject.Find("Music"); 

        if (musicObject != null)
        {
            AudioSource musicSource = musicObject.GetComponent<AudioSource>();

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
            StartCoroutine(Win());
        }

        if (PlayerHealth.staticHP <= 0)
        {
            StartCoroutine(Lose());
        }
        
    }

    
    public void Surrender()
    {
        StartCoroutine(EndGameNow());
    }
    
    IEnumerator EndGameNow()
    {
        Time.timeScale = 0;
        surrenderMusic.Play();
        
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
        coinText.text = "0";
        surrenderWindow.SetActive(false);

        yield return new WaitForSeconds(5f);
    }

    public void Back()
    {
        SceneManager.LoadScene("Main Menu");
        Time.timeScale = 1;
    }

    private IEnumerator Win()
    {
        yield return new WaitForSeconds(5f);
        if (!isWinMusicPlaying)
        {
            isWinMusicPlaying = true;
            winMusic.Play();
        }
        
        Time.timeScale = 0;
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
        yield return new WaitForSeconds(5f);
    }

    private IEnumerator Lose()
    {
        yield return new WaitForSeconds(5f);
        if (!isWinMusicPlaying)
        {
            isWinMusicPlaying = true;
            loseMusic.Play();
        }
        
        Time.timeScale = 0;
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
        yield return new WaitForSeconds(5f);
    }

}
