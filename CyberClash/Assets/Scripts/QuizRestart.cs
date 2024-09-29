using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class QuizRestart : MonoBehaviour
{
    
    // Start is called before the first frame update
    public string quizName;
    void Awake()
    {
        quizName = SceneManager.GetActiveScene().name;
        switch (quizName)
        {
            case "Story2Quiz1":
                ScoreManager.Instance.ResetScore("Story2Quiz1");
                break;
            case "Story2Quiz2":
                ScoreManager.Instance.ResetScore("Story2Quiz2");
                break;
            default:
                break;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    
    
}
