using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using TMPro;
using UnityEngine;
using UnityEngine.UI;


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

    public GameObject coinsWon;
    public bool gotCoins;
    public bool gotExp;

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

        }
    }
    

}
