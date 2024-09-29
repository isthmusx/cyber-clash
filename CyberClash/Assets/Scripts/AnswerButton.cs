using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class AnswerButton : MonoBehaviour
{
    private bool isCorrect;
    [SerializeField] private TMP_Text answerText;
    public QuestionSetup questionSetup;
    public Energy energy;

    public GameObject wrongPanel;
    public GameObject correctPanel;
    
    public GameObject questionPanel;
    public GameObject energyFull;
    public void SetAnswerText(string newText)
    {
        answerText.text = newText;
    }
    public void SetIsCorrect(bool newBool)
    {
        isCorrect = newBool;
    }

    public void OnClick()
    {
        if (isCorrect)
        {
            Debug.Log("Correct");
            energy.GetEnergy();
            correctPanel.SetActive(true);
        }
        else
        {
            Debug.Log("Wrong");
            wrongPanel.SetActive(true);
        }

        if (questionSetup.questions.Count > 0)
        {
            questionSetup.SelectNewQuestion();
            questionSetup.SetQuestionValues();
            questionSetup.SetAnswerValues();
        }
        else
        {
            Debug.LogWarning("No more questions available");
        }
    }

    public void Update()
    {
        if (energy.energy == energy.maxEnergy)
        {
            energyFull.SetActive(true);
            questionPanel.SetActive(false);
        }
        else
        {
            energyFull.SetActive(false);
            questionPanel.SetActive(true);
        }
    }
}
