using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Shop : MonoBehaviour
{

    public TMP_Text coinText;

    public int coins;
    
    
    // Start is called before the first frame update
    void Start()
    {
        coins = 100;

        coins = PlayerPrefs.GetInt("coins", 100);

    }

    // Update is called once per frame
    void Update()
    {
        coinText.text =  coins.ToString();
    }

    public void BuyPack()
    {
        coins -= 10;
        SceneManager.LoadScene("OpenPack");
        PlayerPrefs.SetInt("coins", coins);
    }
}
