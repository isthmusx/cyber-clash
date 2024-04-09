using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Shop : MonoBehaviour
{
    public GameObject modal;

    public TMP_Text coinText;

    public int coins;

    public bool playAI;
    
    // Start is called before the first frame update
    void Start()
    {
        coins = 100;

        coins = PlayerPrefs.GetInt("coins", 100);

    }

    // Update is called once per frame
    void Update()
    {
        if (playAI == false)
        {
            coinText.text =  coins.ToString();
        }
        else
        {
            PlayerPrefs.SetInt("coins", coins);
        }
    }

    public void BuyPack()
    {
        if (coins >= 500)
        {
            coins -= 500;
            SceneManager.LoadScene("OpenPack");
            PlayerPrefs.SetInt("coins", coins);
        }
        else
        {
            modal.SetActive(true);
        }
        
    }
    public void BuyOffensePack()
    {
        if (coins >= 800)
        {
            coins -= 800;
            SceneManager.LoadScene("OpenPack");
            PlayerPrefs.SetInt("coins", coins);
        }
        else
        {
            modal.SetActive(true);
        }
        
    }
    public void BuyDefensePack()
    {
        if (coins >= 800)
        {
            coins -= 800;
            SceneManager.LoadScene("OpenPack");
            PlayerPrefs.SetInt("coins", coins);
        }
        else
        {
            modal.SetActive(true);
        }
        
    }
    public void BuyUtilityPack()
    {
        if (coins >= 800)
        {
            coins -= 800;
            SceneManager.LoadScene("OpenPack");
            PlayerPrefs.SetInt("coins", coins);
        }
        else
        {
            modal.SetActive(true);
        }
        
    }
}
