using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveTutorials : MonoBehaviour
{
    [SerializeField] private GameObject tutorialPanel;
    [SerializeField] private string tutorialName;
    private bool isTutorialCompleted;
    
    // Start is called before the first frame update
    void Start()
    {
        LoadTutorialStatus();
        if (!isTutorialCompleted)
        {
            ShowTutorial();
        }
    }

    // Update is called once per frame

    private void ShowTutorial()
    {
        if (tutorialPanel != null)
        {
            tutorialPanel.SetActive(true);
        }
    }
    public void CompleteTutorial()
    {
        isTutorialCompleted = true;
        tutorialPanel.SetActive(false);
        SaveTutorialStatus();
    }
    private void LoadTutorialStatus()
    {
        isTutorialCompleted = PlayerPrefs.GetInt(tutorialName, 0) == 1;
    }

    // Save the tutorial status when completed
    private void SaveTutorialStatus()
    {
        PlayerPrefs.SetInt(tutorialName, isTutorialCompleted ? 1 : 0);
        PlayerPrefs.Save();
    }
}
