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
            Debug.Log("Checking slot: " + slot.name);
            if (!slot.HasCorrectAnswer())
            {
                allCorrect = false;
                string currentScene = SceneManager.GetActiveScene().name;
                if (currentScene != "Story6Quiz1" && currentScene != "Story6Quiz2")
                {
                    Debug.Log("Incorrect Answer Found! Breaking the loop in scene: " + currentScene);
                    break; // Exit the loop as soon as one incorrect answer is found if it's not Story6Quiz1 or Story6Quiz2
                }
                else
                {
                    Debug.Log("Incorrect Answer Found, but not breaking the loop for Story6Quiz1 or Story6Quiz2.");
                }
            }
            else
            {
                Debug.Log("Correct Answer Found in slot: " + slot.name); // Log when the correct answer is found

                // Increase score for Story6Quiz1 or Story6Quiz2
                string currentScene = SceneManager.GetActiveScene().name;
                if (currentScene == "Story6Quiz1")
                {
                    ScoreManager.Instance.IncreaseScore("Story6Quiz1", 1);
                    Debug.Log("Score increased for Story6Quiz1.");
                }
                else if (currentScene == "Story6Quiz2")
                {
                    ScoreManager.Instance.IncreaseScore("Story6Quiz2", 1);
                    Debug.Log("Score increased for Story6Quiz2.");
                }
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
            if (toggle.isOn && toggle.CompareTag("CorrectAnswer")) // Tag the correct toggle with "CorrectAnswer"
            {
                oneCorrect = true;
                Debug.Log("Correct Answer Found!");
                break;
            }

        }

        if (SceneManager.GetActiveScene().name == "Story6Quiz1")
        {
            panelRandomizer.finalPanel.SetActive(true);
        }
        if (SceneManager.GetActiveScene().name == "Story6Quiz2")
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