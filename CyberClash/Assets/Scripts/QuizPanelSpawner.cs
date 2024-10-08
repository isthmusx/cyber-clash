using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class QuizPanelSpawner : MonoBehaviour
{
    public GameObject quizPanel;
    public TMP_Text questionText;
    public Button[] answerButtons;
    public QuizQuestion[] quizQuestions;
    public GameObject feedbackPanel;
    public TMP_Text feedbackText;

    public Button rewardButton1;
    public Button rewardButton2;
    public Button punishmentButton1;
    public Button punishmentButton2;

    private QuizQuestion currentQuestion;


    void Start()
    {
        Time.timeScale = 1;
        if (quizPanel == null || questionText == null || answerButtons == null || quizQuestions == null || feedbackPanel == null || feedbackText == null ||
            rewardButton1 == null || rewardButton2 == null || punishmentButton1 == null || punishmentButton2 == null)
        {
            Debug.LogError("Some UI components or quiz questions are not assigned in the Inspector.");
        }

        // Add listeners for reward and punishment buttons
        rewardButton1.onClick.AddListener(() => OnRewardButtonClick(1));
        rewardButton2.onClick.AddListener(() => OnRewardButtonClick(2));
        punishmentButton1.onClick.AddListener(() => OnPunishmentButtonClick(1));
        punishmentButton2.onClick.AddListener(() => OnPunishmentButtonClick(2));
    }

    public void SpawnQuizPanel()
    {
        if (quizPanel == null || questionText == null || answerButtons.Length == 0 || quizQuestions.Length == 0 || feedbackPanel == null || feedbackText == null ||
            rewardButton1 == null || rewardButton2 == null || punishmentButton1 == null || punishmentButton2 == null)
        {
            Debug.LogError("Quiz panel or UI components are not properly assigned.");
            return;
        }

        // Randomly select a question
        int randomIndex = Random.Range(0, quizQuestions.Length);
        currentQuestion = quizQuestions[randomIndex];

        // Display the question and answers
        questionText.text = currentQuestion.question;

        for (int i = 0; i < answerButtons.Length; i++)
        {
            if (i < currentQuestion.answers.Length)
            {
                answerButtons[i].GetComponentInChildren<TMP_Text>().text = currentQuestion.answers[i];
                int answerIndex = i;
                answerButtons[i].onClick.RemoveAllListeners();
                answerButtons[i].onClick.AddListener(() => CheckAnswer(answerIndex));
            }
            else
            {
                Debug.LogWarning($"Not enough answers provided for question: {currentQuestion.question}");
            }
        }

        // Activate the quiz panel
        quizPanel.SetActive(true);
        Time.timeScale = 0;  // Pauses the game when the quiz panel is shown
    }

    void CheckAnswer(int selectedAnswerIndex)
    {
        if (selectedAnswerIndex == currentQuestion.correctAnswerIndex)
        {
            ShowFeedback("Correct!", true);
        }
        else
        {
            ShowFeedback("Wrong!", false);
        }

        // Close the quiz panel after showing feedback
        CloseQuizPanel();
    }

    void ShowFeedback(string message, bool isCorrect)
    {
        feedbackText.text = message;
        feedbackPanel.SetActive(true);

        // Show reward or punishment buttons based on correctness
        if (isCorrect)
        {
            rewardButton1.gameObject.SetActive(true);
            rewardButton2.gameObject.SetActive(true);
            punishmentButton1.gameObject.SetActive(false);
            punishmentButton2.gameObject.SetActive(false);
        }
        else
        {
            rewardButton1.gameObject.SetActive(false);
            rewardButton2.gameObject.SetActive(false);
            punishmentButton1.gameObject.SetActive(true);
            punishmentButton2.gameObject.SetActive(true);
        }
    }

    void OnRewardButtonClick(int rewardIndex)
    {
        Debug.Log($"Reward {rewardIndex} selected.");
        // Implement reward logic here based on rewardIndex
        
        if (rewardIndex == 1)
        {
            PlayerHealth.staticHP += 250;  // Assuming you have an AddHealth method in PlayerHealth
            Debug.Log("Player received 250 health.");
            Time.timeScale = 1;
        }
        else if (rewardIndex == 2)
        {
            EnemyHealth.staticHP -= 250;  // Assuming you have a TakeDamage method in EnemyHealth
            Debug.Log("Enemy received 250 damage.");
            Time.timeScale = 1;
        }
        
        HideFeedback();
    }

    void OnPunishmentButtonClick(int punishmentIndex)
    {
        Debug.Log($"Punishment {punishmentIndex} selected.");
        // Implement punishment logic here based on punishmentIndex
        if (punishmentIndex == 1)
        {
            PlayerHealth.staticHP -= 250;  // Assuming you have an AddHealth method in PlayerHealth
            Debug.Log("Player received 250 damage.");
            Time.timeScale = 1;
        }
        else if (punishmentIndex == 2)
        {
            EnemyHealth.staticHP += 250;  // Assuming you have a TakeDamage method in EnemyHealth
            Debug.Log("Enemy received 250 health.");
            Time.timeScale = 1;
        }
        HideFeedback();
        
    }

    void HideFeedback()
    {
        feedbackPanel.SetActive(false);
        
    }

    public void CloseQuizPanel()
    {
        quizPanel.SetActive(false);
    }
}