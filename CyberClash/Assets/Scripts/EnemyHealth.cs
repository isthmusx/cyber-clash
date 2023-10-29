using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class EnemyHealth : MonoBehaviour
{
    public static float maxHP;
    public static float staticHP;
    //public static float hp;
    public Image Health;
    public TMP_Text HPText;


    // Start is called before the first frame update
    void Start()
    {
        maxHP = 1000;
        staticHP = 100;

    }

    // Update is called once per frame
    void Update()
    {
        Health.fillAmount = staticHP / maxHP;

        if (staticHP >= maxHP)
        {
            staticHP = maxHP;
        }

        HPText.text = staticHP.ToString();

    }
}
