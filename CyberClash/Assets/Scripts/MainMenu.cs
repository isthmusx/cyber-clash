using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    
    public void PlayAdvMode()
    {
        SceneManager.LoadSceneAsync(1);
    }

    public void PlayVSAI()
    {
        SceneManager.LoadSceneAsync(2);
    }

    public void PlayDeckBuilder()
    {
        SceneManager.LoadSceneAsync(3);
    }

    public void Back()
    {
        SceneManager.LoadSceneAsync(0);
    }

    public void GameVSAI()
    {
        SceneManager.LoadSceneAsync(4);
    }

    public void Shop()
    {
        SceneManager.LoadSceneAsync(5);
    }
    public void SecurityDeck()
    {
        SceneManager.LoadSceneAsync(17);
    }
    public void ThreatDeck()
    {
        SceneManager.LoadSceneAsync(18);
    }
    public void DeckSelect()
    {
        SceneManager.LoadSceneAsync(16);
    }

    public void Inventory()
    {
        SceneManager.LoadSceneAsync(6);
    }

    public static string faction = "";
    public static string mode = "";
    public static string deckSelected = "";
    public static void ThreatFaction()
    {
        AI.whichEnemy = 2;
        faction = "Threat";
    }
    public static void SecurityFaction()
    {
        AI.whichEnemy = 1;
        faction = "Security";
    }
    public static void SecurityFactionTutorial()
    {
        AI.whichEnemy = 1;
        faction = "SecurityTutorial";
    }
    public static void Story1Deck()
    {
        AI.whichEnemy = 3;
        faction = "Story1Deck";
    }
    public static void Story2Deck()
    {
        AI.whichEnemy = 3;
        faction = "Story2Deck";
    }
    public static void Story3Deck()
    {
        AI.whichEnemy = 3;
        faction = "Story3Deck";
    }
    public static void Story4Deck()
    {
        AI.whichEnemy = 3;
        faction = "Story4Deck";
    }
    public static void Story5Deck()
    {
        AI.whichEnemy = 3;
        faction = "Story5Deck";
    }
    public static void Story6Deck()
    {
        AI.whichEnemy = 3;
        faction = "Story6Deck";
    }
    public static void Story7Deck()
    {
        AI.whichEnemy = 3;
        faction = "Story7Deck";
    }

    public static void VersusMode()
    {
        mode = "versus";
    }
    public static void Story1()
    {
        mode = "story1";
    }
    public static void Story2()
    {
        mode = "story2";
    }
    public static void Story3()
    {
        mode = "story3";
    }
    public static void Story4()
    {
        mode = "story4";
    }
    public static void Story5()
    {
        mode = "story5";
    }
    public static void Story6()
    {
        mode = "story6";
    }
    public static void Story7()
    {
        mode = "story7";
    }
    public static void SelectSecurity()
    {
        deckSelected = "Security";
    }
    public static void SelectThreat()
    {
        deckSelected = "Threat";
    }

    public static string shopInventory;

    public static void ShopSelected()
    {
        shopInventory = "Shop";
    }
    public static void InventorySelected()
    {
        shopInventory = "Inventory";
    }

    public static void GameBack()
    {
        if(mode == "versus")
        {
            SceneManager.LoadSceneAsync(0);
        } 
        else if (mode == "story1" && EndGame.isWin == true)
        {
            SceneManager.LoadSceneAsync(12);
        }
        else if (mode == "story1" && EndGame.isWin == false)
        {
            SceneManager.LoadSceneAsync("Story Lose");
        }
        else if (mode == "story2" && EndGame.isWin == true)
        {
            SceneManager.LoadSceneAsync(19);
        }
        else if (mode == "story2" && EndGame.isWin == false)
        {
            SceneManager.LoadSceneAsync("Story 2-Lose");
        }
        else if (mode == "story3" && EndGame.isWin == true)
        {
            SceneManager.LoadSceneAsync(21);
        }
        else if (mode == "story3" && EndGame.isWin == false)
        {
            SceneManager.LoadSceneAsync("Story 3-Lose");
        }
        else if (mode == "story4" && EndGame.isWin == true)
        {
            SceneManager.LoadSceneAsync(23);
        }
        else if (mode == "story4" && EndGame.isWin == false)
        {
            SceneManager.LoadSceneAsync("Story 4-Lose");
        }
        else if (mode == "story5" && EndGame.isWin == true)
        {
            SceneManager.LoadSceneAsync(25);
        }
        else if (mode == "story5" && EndGame.isWin == false)
        {
            SceneManager.LoadSceneAsync("Story 5-Lose1");
        }
        else if (mode == "story6" && EndGame.isWin == true)
        {
            SceneManager.LoadSceneAsync(44);
        }
        else if (mode == "story6" && EndGame.isWin == false)
        {
            SceneManager.LoadSceneAsync("Story 6-Lose");
        }
        else if (mode == "story7" && EndGame.isWin == true)
        {
            SceneManager.LoadSceneAsync(49);
        }
        else if (mode == "story7" && EndGame.isWin == false)
        {
            SceneManager.LoadSceneAsync(48);
        }
        

    }


    
    public static void UnlockNewlevel()
    {
        if(SceneManager.GetActiveScene().buildIndex >= PlayerPrefs.GetInt("ReachedIndex"))
        {
            PlayerPrefs.SetInt("ReachedIndex", SceneManager.GetActiveScene().buildIndex + 1);
            PlayerPrefs.SetInt("UnlockedLevel", PlayerPrefs.GetInt("UnlockedLevel", 1) + 1);
            PlayerPrefs.Save();
            Debug.Log("new level unlocked");
        }


    }
    public static void UnlockAlllevel()
    {
        PlayerPrefs.SetInt("ReachedIndex", SceneManager.GetActiveScene().buildIndex + 1);
            PlayerPrefs.SetInt("UnlockedLevel", PlayerPrefs.GetInt("UnlockedLevel", 1) + 6);
            PlayerPrefs.Save();


    }

    public void SecurityPack()
    {
        Collection.packType = "Security";
    }
    public void SecurityOffensePack()
    {
        Collection.packType = "SecurityOffense";
    }
    public void SecurityDefensePack()
    {
        Collection.packType = "SecurityDefense";
    }
    public void SecurityUtilityPack()
    {
        Collection.packType = "SecurityUtility";
    }
    public void ThreatPack()
    {
        Collection.packType  = "Threat";
    }
    public void ThreatOffensePack()
    {
        Collection.packType  = "ThreatOffense";
    }
    public void ThreatDefensePack()
    {
        Collection.packType  = "ThreatDefense";
    }
    public void ThreatUtilityPack()
    {
        Collection.packType  = "ThreatUtility";
    }

}
