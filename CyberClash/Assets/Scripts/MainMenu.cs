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

    public static string faction = "";
    public static void ThreatFaction()
    {
            faction = "Threat";
    }
    public static void SecurityFaction()
    {
        faction = "Security";
    }


}
