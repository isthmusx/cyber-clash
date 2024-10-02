using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class AnswerChecker : MonoBehaviour
{
    public AnswerSlot[] answerSlots;
    public PanelRandomizer panelRandomizer;
    public GameObject panelToDisable;  // Reference to the current panel's GameObject
    public Toggle[] answerToggles;
    private Button button;

    void Start()
    {
        button = GetComponent<Button>();
        button.onClick.AddListener(CheckAnswers);
        
    }

    void CheckAnswers()
    {
        bool oneCorrect = false;
        bool allCorrect = true;
        
        // Check all answer slots
        foreach (AnswerSlot slot in answerSlots)
        {
            if (!slot.HasCorrectAnswer())
            {
                allCorrect = false;
                Debug.Log("Correct Answer Found!");
                break; // Exit the loop as soon as one correct answer is found
            }
        }
        
        
        if (allCorrect)
        {
            Debug.Log("All answers are correct!");
            oneCorrect = true; // You can set oneCorrect to true here if you need it
        }
        else
        {
            Debug.Log("Not all answers are correct.");
            oneCorrect = false; // Set oneCorrect to false if not all answers are correct
        }
        
        foreach (Toggle toggle in answerToggles)
        {
            if (toggle.isOn && toggle.CompareTag("CorrectAnswer"))  // Tag the correct toggle with "CorrectAnswer"
            {
                oneCorrect = true;
                Debug.Log("Correct Answer Found!");
                break;
            }
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
                    case "Story4Quiz1":
                        ScoreManager.Instance.IncreaseScore("Story4Quiz1", 1);
                        break;
                    case "Story4Quiz2":
                        ScoreManager.Instance.IncreaseScore("Story4Quiz2", 1);
                        break;
                    case "Story5Quiz1":
                        ScoreManager.Instance.IncreaseScore("Story5Quiz1", 1);
                        break;
                    case "Story5Quiz2":
                        ScoreManager.Instance.IncreaseScore("Story5Quiz2", 1);
                        break;
                    default:
                        break;
                }
               PanelRandomizer.correctModal.SetActive(true);
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
            PanelRandomizer.wrongModal.SetActive(true);
            
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