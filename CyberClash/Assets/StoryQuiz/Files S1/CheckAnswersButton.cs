using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class AnswerChecker : MonoBehaviour
{
    public AnswerSlot[] answerSlots;
    public PanelRandomizer panelRandomizer;
    public GameObject panelToDisable; // Reference to the current panel's GameObject
    public Toggle[] answerToggles;
    private Button button;
    public string trivia;
    bool answerSelected = false;

    void Start()
    {
        button = GetComponent<Button>();
        button.onClick.AddListener(CheckAnswers);

    }

    void CheckAnswers()
    {
        bool oneCorrect = false;
        bool allCorrect = true;

        int correctAnswerCount = 0;

        // Check all answer slots
        correctAnswerCount = 0; // Reset count before the loop

        foreach (AnswerSlot slot in answerSlots)
        {
            Debug.Log($"Slot {slot.name}: Correct Answer - {slot.HasCorrectAnswer()}"); 
            bool hasCorrectAnswer = slot.HasCorrectAnswer(); // Store the result for logging and condition checking

            if (SceneManager.GetActiveScene().name == "Story4Quiz1")
            {
                if (hasCorrectAnswer)
                {
                    correctAnswerCount++;
                    ScoreManager.Instance.IncreaseScore("Story4Quiz1", 1);
                    Debug.Log("Score increased for Story4Quiz1.");
                }
                
            }
            
            else if (SceneManager.GetActiveScene().name == "Story4Quiz2")
            {
                if (hasCorrectAnswer)
                {
                    ScoreManager.Instance.IncreaseScore("Story4Quiz2", 1);
                    Debug.Log("Score increased for Story4Quiz2.");
                }
            }
            else
            {
                if (hasCorrectAnswer)
                {
                    oneCorrect = true;
                }
                else
                {
                    oneCorrect = false;
                }
                
            }

            Debug.Log($"Slot {slot.name} has correct answer: {hasCorrectAnswer}");
        }

        Debug.Log($"Total correct answers: {correctAnswerCount}");

        
        

        /*if (allCorrect)
        {
            Debug.Log("All answers are correct!");
            oneCorrect = true; // You can set oneCorrect to true here if you need it
        }
        else
        {
            Debug.Log("Not all answers are correct.");
            oneCorrect = false; // Set oneCorrect to false if not all answers are correct
        }*/

        foreach (Toggle toggle in answerToggles)
        {
            if (toggle.isOn)
            {
                answerSelected = true; // Mark that an answer has been selected

                if (toggle.CompareTag("CorrectAnswer")) // Tag the correct toggle with "CorrectAnswer"
                {
                    oneCorrect = true;
                    Debug.Log("Correct Answer Found!");
                    break;
                }
            }
        }

        if (SceneManager.GetActiveScene().name == "Story4Quiz1")
        {
            panelRandomizer.finalPanel.SetActive(true);
        }
        if (SceneManager.GetActiveScene().name == "Story4Quiz2")
        {
            panelRandomizer.finalPanel.SetActive(true);
        }

        // If at least one answer is correct, show the next panel
        if (oneCorrect)
        {
            // Disable the current panel before activating the next one
            if (panelToDisable != null)
            {
                panelToDisable.SetActive(false);
                switch (SceneManager.GetActiveScene().name)
                {
                    case "Story2Quiz1":
                        ScoreManager.Instance.IncreaseScore("Story2Quiz1", 1);
                        break;
                    case "Story2Quiz2":
                        ScoreManager.Instance.IncreaseScore("Story2Quiz2", 1);
                        break;
                    case "Story3Quiz1":
                        ScoreManager.Instance.IncreaseScore("Story3Quiz1", 1);
                        break;
                    /*case "Story4Quiz1":
                        ScoreManager.Instance.IncreaseScore("Story4Quiz1", 1);
                        break;
                    case "Story4Quiz2":
                        ScoreManager.Instance.IncreaseScore("Story4Quiz2", 1);
                        break;*/
                    case "Story5Quiz1":
                        ScoreManager.Instance.IncreaseScore("Story5Quiz1", 1);
                        break;
                    case "Story5Quiz2":
                        ScoreManager.Instance.IncreaseScore("Story5Quiz2", 1);
                        break;
                    case "Story6Quiz1":
                        ScoreManager.Instance.IncreaseScore("Story6Quiz1", 1);
                        break;
                    case "Story6Quiz2":
                        ScoreManager.Instance.IncreaseScore("Story6Quiz2", 1);
                        break;
                    default:
                        break;
                }
                panelRandomizer.ShowCorrectPanelWithTrivia(trivia);
            }
            else
            {
                
                Debug.LogError("Panel to disable reference is not set.");
            }

            if (panelRandomizer != null)
            {
                panelRandomizer.RandomizeAndShowPanel();
            }
            else
            {
                Debug.LogError("PanelRandomizer reference is not set.");
            }
        }
        else
        {
            panelRandomizer.ShowWrongPanelWithTrivia(trivia);
            
            if (panelRandomizer != null)
            {
                panelRandomizer.RandomizeAndShowPanel();
            }
            else
            {
                Debug.LogError("PanelRandomizer reference is not set.");
            }
            panelToDisable.SetActive(false);
            Debug.Log("No correct answers found.");
        }
    }
}