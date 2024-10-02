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
            case "Story3Quiz1":
                ScoreManager.Instance.ResetScore("Story3Quiz1");
                break;
            case "Story4Quiz1":
                ScoreManager.Instance.ResetScore("Story4Quiz1");
                break;
            case "Story4Quiz2":
                ScoreManager.Instance.ResetScore("Story4Quiz2");
                break;
            case "Story5Quiz1":
                ScoreManager.Instance.ResetScore("Story5Quiz1");
                break;
            case "Story5Quiz2":
                ScoreManager.Instance.ResetScore("Story5Quiz2");
                break;
            case "Story6Quiz1":
                ScoreManager.Instance.ResetScore("Story6Quiz1");
                break;
            case "Story6Quiz2":
                ScoreManager.Instance.ResetScore("Story6Quiz2");
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
