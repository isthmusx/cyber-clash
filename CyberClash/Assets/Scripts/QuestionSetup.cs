using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Random = UnityEngine.Random;

public class QuestionSetup : MonoBehaviour
{
    [SerializeField] public List<QuestionData> questions;
    private QuestionData currentQuestion;

    [SerializeField] private TMP_Text questionText;
    [SerializeField] private AnswerButton[] answerButtons;
    [SerializeField] private int correctAnswerChoice;

    private void Awake()
    {
        GetQuestionAssets();
    }

    // Start is called before the first frame update
    void Start()
    {
        SelectNewQuestion();
        SetQuestionValues();
        SetAnswerValues();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void GetQuestionAssets()
    {
        questions = new List<QuestionData>(Resources.LoadAll<QuestionData>("Questions"));
    }

    public void SelectNewQuestion()
    {
        int randomQuestionIndex = Random.Range(0, questions.Count);
        currentQuestion = questions[randomQuestionIndex];
        questions.RemoveAt(randomQuestionIndex);
    }

    public void SetQuestionValues()
    {
        questionText.text = currentQuestion.question;
    }

    public void SetAnswerValues()
    {
        List<string> answers = RandomizeAnswers(new List<string>(currentQuestion.answers));

        for (int i = 0; i < answerButtons.Length; i++)
        {
            bool isCorrect = i == correctAnswerChoice;

            answerButtons[i].SetIsCorrect(isCorrect);
            answerButtons[i].SetAnswerText(answers[i]);
        }
    }

    private List<string> RandomizeAnswers(List<string> originalList)
    {
        bool correctAnswerChosen = false;

        List<string> newList = new List<string>();
        for (int i = 0; i < answerButtons.Length; i++)
        {
            int random = Random.Range(0, originalList.Count);

            if (random == 0 && !correctAnswerChosen)
            {
                correctAnswerChoice = i;
                correctAnswerChosen = true;
            }
            
            newList.Add(originalList[random]);
            originalList.RemoveAt(random);
        }

        return newList;
    }
}
