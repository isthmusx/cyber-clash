using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PlayerHealth : MonoBehaviour
{
    public static float maxHP;
    public static float staticHP;
    public static float shield;
    public Image Health;
    public Image Shield;
    public TMP_Text HPText;


    // Start is called before the first frame update
    void Start()
    {
        maxHP = 1000;
        staticHP = 1000;
        shield = 0;
    }

    // Update is called once per frame
    void Update()
    {
        
        if (staticHP >= maxHP)
        {
            staticHP = maxHP;
        }

        Health.fillAmount = staticHP / maxHP;
        Shield.fillAmount = (staticHP + shield) / maxHP;
        HPText.text = staticHP + "/" + maxHP + " HP";
        //Debug.Log("HP: " + staticHP);
        //Debug.Log("Shield: " + shield);
    }
}
