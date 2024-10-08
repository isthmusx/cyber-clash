using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    private static ScoreManager _instance;

    public static ScoreManager Instance
    {
        get
        {
            if (_instance == null)
            {
                GameObject go = new GameObject("ScoreManager");
                _instance = go.AddComponent<ScoreManager>();
                DontDestroyOnLoad(go);
            }
            return _instance;
        }
    }

    private Dictionary<string, int> quizScores = new Dictionary<string, int>();

    private void Awake()
    {
        if (_instance == null)
        {
            _instance = this;
            DontDestroyOnLoad(gameObject);
            LoadAllScores(); // Load scores from PlayerPrefs on start
        }
        else
        {
            Destroy(gameObject);
        }

        DebugAllScores();
    }

    // Increase score for a specific quiz
    public void IncreaseScore(string quizName, int amount)
    {
        if (quizScores.ContainsKey(quizName))
        {
            quizScores[quizName] += amount;
        }
        else
        {
            quizScores[quizName] = amount;
        }
        SaveScore(quizName, quizScores[quizName]);
        Debug.Log($"Score for {quizName} increased. Current score: {quizScores[quizName]}");
    }

    // Decrease score for a specific quiz
    public void DecreaseScore(string quizName, int amount)
    {
        if (quizScores.ContainsKey(quizName))
        {
            quizScores[quizName] = Mathf.Max(0, quizScores[quizName] - amount); // Ensure score doesn't go negative
        }
        else
        {
            quizScores[quizName] = 0; // Ensure score doesn't go negative
        }
        SaveScore(quizName, quizScores[quizName]);
        Debug.Log($"Score for {quizName} decreased. Current score: {quizScores[quizName]}");
    }

    // Get the score for a specific quiz
    public int GetScore(string quizName)
    {
        if (quizScores.ContainsKey(quizName))
        {
            return quizScores[quizName];
        }
        return 0; // Return 0 if the quiz has no score yet
    }

    // Reset score for a specific quiz
    public void ResetScore(string quizName)
    {
        if (quizScores.ContainsKey(quizName))
        {
            quizScores[quizName] = 0;
            SaveScore(quizName, 0);
            Debug.Log($"Score for {quizName} reset. Current score: 0");
        }
    }

    // Reset all scores
    public void ResetAllScores()
    {
        quizScores.Clear();
        PlayerPrefs.DeleteAll(); // Clear all saved data
        Debug.Log("All scores reset.");
    }

    // Save score to PlayerPrefs
    private void SaveScore(string quizName, int score)
    {
        PlayerPrefs.SetInt(quizName, score);
        PlayerPrefs.Save();
    }

    // Load score from PlayerPrefs
    private int LoadScore(string quizName)
    {
        return PlayerPrefs.GetInt(quizName, 0); // Default score is 0 if not found
    }

    // Load all scores from PlayerPrefs
    private void LoadAllScores()
    {
        // Add any necessary quiz names here to initialize scores
        // Example: List<string> quizNames = new List<string> { "Quiz1", "Quiz2", "Quiz3" };
        List<string> quizNames = new List<string> { "Story2Quiz1", "Story2Quiz2", "Story3Quiz1", "Story4Quiz1", "Story4Quiz2", "Story5Quiz1", "Story5Quiz2", "Story6Quiz1", "Story6Quiz2"};
        foreach (var quizName in quizNames)
        {
            quizScores[quizName] = LoadScore(quizName);
        }
    }
    public void DebugAllScores()
    {
        foreach (var quizScore in quizScores)
        {
            Debug.Log($"Quiz: {quizScore.Key}, Score: {quizScore.Value}");
        }
    }
}
