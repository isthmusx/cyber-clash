using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class AnswerChecker : MonoBehaviour
{
    public AnswerSlot[] answerSlots;
    public PanelRandomizer panelRandomizer;
    public GameObject panelToDisable;  // Reference to the current panel's GameObject
    
    private Button button;

    void Start()
    {
        button = GetComponent<Button>();
        button.onClick.AddListener(CheckAnswers);
        
    }

    void CheckAnswers()
    {
        bool oneCorrect = false;

        // Check all answer slots
        foreach (AnswerSlot slot in answerSlots)
        {
            if (slot.HasCorrectAnswer())
            {
                oneCorrect = true;
                Debug.Log("Correct Answer Found!");
                break; // Exit the loop as soon as one correct answer is found
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