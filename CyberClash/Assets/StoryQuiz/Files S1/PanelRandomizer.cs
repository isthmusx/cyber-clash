using System.Collections.Generic;
using UnityEngine;

public class PanelRandomizer : MonoBehaviour
{
    public List<GameObject> panels;
    public GameObject finalPanel;
    public static GameObject correctModal;
    public static GameObject wrongModal;
    private void Start()
    {
        DontDestroyOnLoad(gameObject);

        foreach (GameObject panel in panels)
        {
            panel.SetActive(false);
        }

        if (finalPanel != null)
        {
            finalPanel.SetActive(false);
        }
        else
        {
            Debug.LogError("Final panel reference is not set.");
        }
        
        correctModal = GameObject.Find("ModalCorrect");
        wrongModal = GameObject.Find("ModalWrong");
        correctModal.SetActive(false);
        wrongModal.SetActive(false);
        
    }

    public void RandomizeAndShowPanel()
    {
        if (panels == null || panels.Count == 0)
        {
            Debug.LogError("Panel list is empty or not assigned.");
            if (finalPanel != null)
            {
                finalPanel.SetActive(true);
            }
            return;
        }

        int randomIndex = Random.Range(0, panels.Count);
        GameObject randomPanel = panels[randomIndex];

        // Activate the selected panel
        randomPanel.SetActive(true);

        // Remove the activated panel from the list to avoid showing it again
        panels.RemoveAt(randomIndex);
    }
    
}