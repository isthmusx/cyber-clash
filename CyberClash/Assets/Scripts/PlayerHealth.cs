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

    // Reference to the QuizPanelSpawner
    public QuizPanelSpawner quizPanelSpawner;

    // Flags to track if a quiz has been triggered
    private bool triggered90 = false;
    private bool triggered70 = false;
    private bool triggered50 = false;
    private bool triggered30 = false;
    private bool triggered10 = false;

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
            maxHP = totalHP;
        }
        else if (totalHP <= defaultMaxHP)
        {
            maxHP = defaultMaxHP;
        }

        // Update UI elements
        Health.fillAmount = staticHP / maxHP;
        Shield.fillAmount = (staticHP + shield) / maxHP;
        HPText.text = staticHP + "/" + maxHP + " HP";

        // Check for health thresholds and trigger quizzes
        float healthPercentage = staticHP / maxHP;

        if (healthPercentage <= 0.90f && !triggered90)
        {
            quizPanelSpawner.SpawnQuizPanel();
            triggered90 = true;
        }
        else if (healthPercentage <= 0.70f && !triggered70)
        {
            quizPanelSpawner.SpawnQuizPanel();
            triggered70 = true;
        }
        else if (healthPercentage <= 0.50f && !triggered50)
        {
            quizPanelSpawner.SpawnQuizPanel();
            triggered50 = true;
        }
        else if (healthPercentage <= 0.30f && !triggered30)
        {
            quizPanelSpawner.SpawnQuizPanel();
            triggered30 = true;
        }
        else if (healthPercentage <= 0.10f && !triggered10)
        {
            quizPanelSpawner.SpawnQuizPanel();
            triggered10 = true;
        }
    }
}