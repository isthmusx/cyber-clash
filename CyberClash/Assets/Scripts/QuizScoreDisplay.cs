using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class QuizScoreDisplay : MonoBehaviour
{
    public TMP_Text score;
    public string quizName;
    // Start is called before the first frame update
    void Awake()
    {
        quizName = SceneManager.GetActiveScene().name;
        DisplayScore();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void DisplayScore()
    {
        score.text = "You got " + ScoreManager.Instance.GetScore(quizName).ToString() + " correct answers";
    }
}
