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
    public void DeckCreator()
    {
        SceneManager.LoadSceneAsync(14);
    }

    public void Inventory()
    {
        SceneManager.LoadSceneAsync(6);
    }

    public static string faction = "";
    public static string mode = "";
    public static void ThreatFaction()
    {
        faction = "Threat";
    }
    public static void SecurityFaction()
    {
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


}
