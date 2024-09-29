using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;

public class GameplayTutorial : MonoBehaviour
{
    public GameObject tutorialPanel;
    public GameObject panel4;
    public GameObject panel5;

    public Button surrenderBTN;
    
    // Start is called before the first frame update
    public bool timePause;
    void Start()
    {
        if (!PlayerPrefs.HasKey("TutorialDone") || PlayerPrefs.GetInt("TutorialDone") == 0)
        {
            timePause = true;
            tutorialPanel.SetActive(true);
            surrenderBTN.interactable = false;
        }
        else
        {
            timePause = false;
            tutorialPanel.SetActive(false);
        }

        UpdateTimeScale();
    }

// Update is called once per frame
    void Update()
    {
        UpdateTimeScale();
    }

// Update the time scale based on the pause state
    void UpdateTimeScale()
    {
        if (timePause)
        {
            Time.timeScale = 0;
        }
        else
        {
            Time.timeScale = 1;
        }
    }

    public void TutorialCompleted()
    {
        tutorialPanel.SetActive(false);
        timePause = false;
        PlayerPrefs.SetInt("TutorialDone", 1);
    }

    public void StartTutorialButton()
    {
        timePause = false;
        StartCoroutine(WaitFiveSeconds());
        
    }

    IEnumerator WaitFiveSeconds()
    {
        yield return new WaitForSeconds(7f); 
        timePause = true;
        panel4.SetActive(false);
        panel5.SetActive(true);
    }
    public void PauseTime()
    {
        timePause = true;
    }
    public void ContinueTime()
    {
        timePause = false;
    }


}
