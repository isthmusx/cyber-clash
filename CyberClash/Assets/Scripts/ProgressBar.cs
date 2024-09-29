using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ProgressBar : MonoBehaviour
{
    public Slider starProgressBar; // Reference to the progress bar on the home screen
    public TMP_Text progressText;
    public TMP_Text gearsCollectedText;

    public GameObject[] story1GearObjects;
    public GameObject[] story2GearObjects;
    public GameObject[] story3GearObjects;
    public GameObject[] story4GearObjects;
    public GameObject[] story5GearObjects;
    public GameObject[] story6GearObjects;
    
    // Separate arrays for each chapter's gears (3 gears per chapter)
    public Image[] story1Gears; // For Story 1
    public Image[] story2Gears; // For Story 2
    public Image[] story3Gears; // For Story 3
    public Image[] story4Gears; // For Story 4
    public Image[] story5Gears; // For Story 5
    public Image[] story6Gears;
    
    public Sprite inactiveGearSprite;
    public Sprite activeGearSprite;
    private void Start()
    {
        story1Gears = GetImageComponents(story1GearObjects);
        story2Gears = GetImageComponents(story2GearObjects);
        story3Gears = GetImageComponents(story3GearObjects);
        story4Gears = GetImageComponents(story4GearObjects);
        story5Gears = GetImageComponents(story5GearObjects);
        story6Gears = GetImageComponents(story6GearObjects);
        
        // Update the progress bar when the home screen is enabled
        if (StarManager.Instance != null)
        {
            StarManager.Instance.starProgressBar = starProgressBar; // Assign the progress bar to the StarManager
            StarManager.Instance.UpdateProgressBar();
            progressText.text = $"{(starProgressBar.value * 100f):0.00}%";
            gearsCollectedText.text = $"Gears Collected: {StarManager.Instance.GetTotalStars()} / {StarManager.Instance.GetMaxStars()}";

            // Update gears for each chapter
            UpdateChapterGears("Story1", story1Gears);
            UpdateChapterGears("Story2", story2Gears);
            UpdateChapterGears("Story3", story3Gears);
            UpdateChapterGears("Story4", story4Gears);
            UpdateChapterGears("Story5", story5Gears);
            UpdateChapterGears("Story6", story6Gears);
        }
    }
    private Image[] GetImageComponents(GameObject[] gearObjects)
    {
        Image[] images = new Image[gearObjects.Length];
        for (int i = 0; i < gearObjects.Length; i++)
        {
            if (gearObjects[i] != null)
            {
                images[i] = gearObjects[i].GetComponent<Image>();
            }
            else
            {
                Debug.LogError($"Gear object at index {i} is null!");
            }
        }
        return images;
    }

    // Method to update gears for each story based on stars
    private void UpdateChapterGears(string storyName, Image[] gears)
    {
        int starsForChapter = StarManager.Instance.GetStarsForStory(storyName);

        // Update each gear's image based on the number of stars collected for the given story
        for (int i = 0; i < gears.Length; i++)
        {
            if (i < starsForChapter)
            {
                gears[i].sprite = activeGearSprite; // Set to active (lit) gear
            }
            else
            {
                gears[i].sprite = inactiveGearSprite; // Set to inactive (unlit) gear
            }
        }
    }
}
