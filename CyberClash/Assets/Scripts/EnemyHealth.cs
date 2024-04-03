using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class EnemyHealth : MonoBehaviour
{
    public static float maxHP;
    public static float staticHP;
    public static float shield;
    public Image Health;
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
        Health.fillAmount = staticHP / maxHP;

        if (staticHP >= maxHP)
        {
            staticHP = maxHP;
        }

        HPText.text = staticHP + "/" + maxHP + " HP";

    }
}
