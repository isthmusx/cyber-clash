using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class EXPController : MonoBehaviour
{
    [SerializeField] private TMP_Text levelText;
    [SerializeField] private TMP_Text experienceText;
    [SerializeField] private int level;
    public static float currentExp;
    public string tier;
    [SerializeField] private float targetExp;
    [SerializeField] private Image EXPProgressBar;
    
    
    // Start is called before the first frame update
    void Start()
    {
        level = PlayerPrefs.GetInt("level", 1);
        currentExp = PlayerPrefs.GetFloat("currentExp", 0);
        targetExp = PlayerPrefs.GetFloat("targetExp", 1000);
    }

    // Update is called once per frame
    void Update()
    {
        experienceText.text = currentExp + " / " + targetExp;

        if (level >= 1)
        {
            tier = " (Noob)";
        } 
        else if (level >= 10)
        {
            tier = " (Skilled)";
        }
        else if (level >= 20)
        {
            tier = " (Expert)";
        }

        
        ExperienceController();
        
    }

    public void ExperienceController()
    {
        
        levelText.text = "LEVEL " + level.ToString() + tier;
        EXPProgressBar.fillAmount = (currentExp / targetExp);
        
        if (currentExp >= targetExp)
        {
            currentExp -= targetExp;
            level++;
            targetExp += 100;
            PlayerPrefs.SetInt("level", level);
            PlayerPrefs.SetFloat("targetExp", targetExp);
            
        }
        
    }

    public void AddXP()
    {
        currentExp += 150;
        PlayerPrefs.SetFloat("currentExp", currentExp);
    }
    
    public static void WonEXP()
    {
        if (EndGame.isWin == true)
        {
            currentExp += 550; 
            PlayerPrefs.SetFloat("currentExp", currentExp);
        } 
        else if (EndGame.isWin == false)
        {
            currentExp += 200; 
            PlayerPrefs.SetFloat("currentExp", currentExp);
        }
    }
    
}