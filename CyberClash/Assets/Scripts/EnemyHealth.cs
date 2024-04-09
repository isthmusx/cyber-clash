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

        int defaultMaxHP = 1000;

        // Ensure staticHP doesn't exceed maxHP
        if (staticHP >= maxHP)
        {
            staticHP = maxHP;
        }
    
        // Calculate totalHP including shield
        float totalHP = staticHP + shield;

        // Adjust maxHP based on totalHP
        if (totalHP > maxHP)
        {
            maxHP = Mathf.CeilToInt(totalHP);
        }
        else if (totalHP < defaultMaxHP)
        {
            maxHP = defaultMaxHP;
        }

        Health.fillAmount = staticHP / maxHP;
        Shield.fillAmount = (staticHP + shield) / maxHP;
        HPText.text = staticHP + "/" + maxHP + " HP";

    }
}
