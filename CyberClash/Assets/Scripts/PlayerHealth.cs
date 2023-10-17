using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PlayerHealth : MonoBehaviour
{
    public static float maxHP;
    public static float staticHP;
    public float hp;
    public Image Health;
    public TMP_Text HPText;


    // Start is called before the first frame update
    void Start()
    {
        maxHP = 1000;
        staticHP = 800;

    }

    // Update is called once per frame
    void Update()
    {
        hp = staticHP;
        Health.fillAmount = hp / maxHP;

        if (hp >= maxHP)
        {
            hp = maxHP;
        }

        HPText.text = hp.ToString();
    }
}
