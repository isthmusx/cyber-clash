using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StarManager : MonoBehaviour
{
    private static StarManager _instance;

    public static StarManager Instance
    {
        get
        {
            if (_instance == null)
            {
                GameObject go = new GameObject("StarManager");
                _instance = go.AddComponent<StarManager>();
                DontDestroyOnLoad(go);
            }
            return _instance;
        }
    }

    private Dictionary<string, int> storyStars = new Dictionary<string, int>();
    private const int maxStarsPerStory = 3;
    private int totalStories = 6; // Adjust based on your game's number of stories

    public Slider starProgressBar; // UI Slider for the progress bar

    private void Awake()
    {
        if (_instance == null)
        {
            _instance = this;
            DontDestroyOnLoad(gameObject);
            LoadAllStars(); // Load stars when the game starts
            UpdateProgressBar();
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void AwardStar(string storyName)
    {
        if (storyStars.ContainsKey(storyName))
        {
            storyStars[storyName] = Mathf.Min(storyStars[storyName] + 1, maxStarsPerStory);
        }
        else
        {
            storyStars[storyName] = 1;
        }

        SaveStars(storyName);
        Debug.Log($"Star awarded to {storyName}! Total stars: {storyStars[storyName]}");
        UpdateProgressBar();
    }

    public int GetStarsForStory(string storyName)
    {
        return storyStars.ContainsKey(storyName) ? storyStars[storyName] : 0;
    }

    public void ResetStarsForStory(string storyName)
    {
        if (storyStars.ContainsKey(storyName))
        {
            storyStars[storyName] = 0;
            SaveStars(storyName); // Save reset stars
            Debug.Log($"Stars reset for {storyName}. Total stars: {storyStars[storyName]}");
        }
        UpdateProgressBar();
    }

    public void ResetAllStars()
    {
        storyStars.Clear();
        PlayerPrefs.DeleteAll(); // Clear all saved stars
        Debug.Log("All stars reset.");
        UpdateProgressBar();
    }

    public int GetTotalStars()
    {
        int totalStars = 0;
        foreach (var stars in storyStars.Values)
        {
            totalStars += stars;
        }
        return totalStars;
    }

    public int GetMaxStars()
    {
        return totalStories * maxStarsPerStory;
    }

    public void UpdateProgressBar()
    {
        if (starProgressBar != null)
        {
            starProgressBar.value = (float)GetTotalStars() / GetMaxStars();
            Debug.Log($"Progress bar updated: {starProgressBar.value * 100}%");
        }
    }

    private void SaveStars(string storyName)
    {
        if (storyStars.ContainsKey(storyName))
        {
            PlayerPrefs.SetInt(storyName + "_Stars", storyStars[storyName]);
            PlayerPrefs.Save();
        }
    }

    private void LoadStars(string storyName)
    {
        if (PlayerPrefs.HasKey(storyName + "_Stars"))
        {
            storyStars[storyName] = PlayerPrefs.GetInt(storyName + "_Stars");
        }
    }

    private void LoadAllStars()
    {
        // Load stars for all stories
        for (int i = 1; i <= totalStories; i++)
        {
            string storyName = "Story" + i; // Assuming stories are named Story1, Story2, etc.
            LoadStars(storyName);
        }
    }
}