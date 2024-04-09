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

    public static void VersusMode()
    {
        mode = "versus";
    }
    public static void Story1()
    {
        mode = "story1";
    }
    public static void SelectSecurity()
    {
        deckSelected = "Security";
    }
    public static void SelectThreat()
    {
        deckSelected = "Threat";
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
            SceneManager.LoadSceneAsync(13);
        }

    }

    public static void UnlockNewlevel()
    {
        if(SceneManager.GetActiveScene().buildIndex >= PlayerPrefs.GetInt("ReachedIndex"))
        {
            PlayerPrefs.SetInt("ReachedIndex", SceneManager.GetActiveScene().buildIndex + 1);
            PlayerPrefs.SetInt("UnlockedLevel", PlayerPrefs.GetInt("UnlockedLevel", 1) + 1);
            PlayerPrefs.Save();
        }
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
