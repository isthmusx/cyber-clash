using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class StoryRewards : MonoBehaviour
{
    public GameObject coinsWon;
    public TMP_Text coins;
    public TMP_Text unlock;
    public GameObject unlockIcon;

    public Image gearIcon1;
    public Image gearIcon3;
    public Sprite sprite1;
    public Sprite sprite3;

    private const string Story1Key = "Story1Done";
    private const string Story2Key = "Story2Done";
    private const string Story3Key = "Story3Done";
    private const string Story4Key = "Story4Done";
    private const string Story5Key = "Story5Done";

    public static void MarkStoryDone(int storyNumber)
    {
        string storyKey = GetStoryKey(storyNumber);
        PlayerPrefs.SetInt(storyKey, 1); 
        PlayerPrefs.Save(); 
    }
    public static bool IsStoryDone(int storyNumber)
    {
        string storyKey = GetStoryKey(storyNumber);
        return PlayerPrefs.GetInt(storyKey, 0) == 1; 
    }
    private static string GetStoryKey(int storyNumber)
    {
        switch (storyNumber)
        {
            case 1:
                return Story1Key;
            case 2:
                return Story2Key;
            case 3:
                return Story3Key;
            case 4:
                return Story4Key;
            case 5:
                return Story5Key;
            default:
                Debug.LogError("Invalid story number!");
                return "";
        }
    }
    

    public void Reward1()
    {
        if (!IsStoryDone(1))
        {
            EXPController.RewardXP();
            coinsWon.GetComponent<Shop>().coins += 1000;
            coins.text = "+ 1000 Coins";
            unlock.text = "New Story Unlocked";
            StarManager.Instance.AwardStar("Story1");
            StarManager.Instance.AwardStar("Story1");
            StarManager.Instance.AwardStar("Story1");
            sprite1 = Resources.Load<Sprite>("Gear/GearLightIcon");
            sprite3 = Resources.Load<Sprite>("Gear/GearLightIcon");
            gearIcon1.sprite = sprite1;
            gearIcon3.sprite = sprite3;
        }
        else
        {
            EXPController.RewardXPLose();
            coins.text = "+ 0 Coins";
            unlock.text = "";
            unlockIcon.SetActive(false);
            StarManager.Instance.AwardStar("Story1");
            StarManager.Instance.AwardStar("Story1");
            StarManager.Instance.AwardStar("Story1");
            sprite1 = Resources.Load<Sprite>("Gear/GearLightIcon");
            sprite3 = Resources.Load<Sprite>("Gear/GearLightIcon");
            gearIcon1.sprite = sprite1;
            gearIcon3.sprite = sprite3;
        }
    }
    public void Reward2()
    {
        if (!IsStoryDone(2))
        {
            EXPController.RewardXP();
            coinsWon.GetComponent<Shop>().coins += 1000;
            coins.text = "+ 1000 Coins";
            unlock.text = "New Story Unlocked";
            StarManager.Instance.AwardStar("Story2");
            if (ScoreManager.Instance.GetScore("Story2Quiz1") == 4)
            {
                StarManager.Instance.AwardStar("Story2");
                sprite1 = Resources.Load<Sprite>("Gear/GearLightIcon");
            }
            else
            {
                sprite3 = Resources.Load<Sprite>("Gear/GearDarkIcon");
            }

            if (ScoreManager.Instance.GetScore("Story2Quiz2") == 4)
            {
                StarManager.Instance.AwardStar("Story2");
                sprite3 = Resources.Load<Sprite>("Gear/GearLightIcon");
            }
            else
            {
                sprite3 = Resources.Load<Sprite>("Gear/GearDarkIcon");
            }

            gearIcon1.sprite = sprite1;
            gearIcon3.sprite = sprite3;
        }
        else
        {
            EXPController.RewardXPLose();
            coins.text = "+ 0 Coins";
            unlock.text = "";
            unlockIcon.SetActive(false);
            StarManager.Instance.AwardStar("Story2");
            if (ScoreManager.Instance.GetScore("Story2Quiz1") == 4)
            {
                StarManager.Instance.AwardStar("Story2");
                sprite1 = Resources.Load<Sprite>("Gear/GearLightIcon");
            }
            else
            {
                sprite1 = Resources.Load<Sprite>("Gear/GearDarkIcon");
            }

            if (ScoreManager.Instance.GetScore("Story2Quiz2") == 4)
            {
                StarManager.Instance.AwardStar("Story2");
                sprite3 = Resources.Load<Sprite>("Gear/GearLightIcon");
            }
            else
            {
                sprite3 = Resources.Load<Sprite>("Gear/GearDarkIcon");
            }
            gearIcon1.sprite = sprite1;
            gearIcon3.sprite = sprite3;
        }
    }
    public void Reward3()
    {
        if (!IsStoryDone(3))
        {
            EXPController.RewardXP();
            coinsWon.GetComponent<Shop>().coins += 1000;
            coins.text = "+ 1000";
            unlock.text = "New Story Unlocked";
            StarManager.Instance.AwardStar("Story3");
            if (ScoreManager.Instance.GetScore("Story3Quiz1") == 4)
            {
                StarManager.Instance.AwardStar("Story3");
                sprite1 = Resources.Load<Sprite>("Gear/GearLightIcon");
            }
            else
            {
                sprite3 = Resources.Load<Sprite>("Gear/GearDarkIcon");
            }

            if (ScoreManager.Instance.GetScore("Story3Quiz1") == 4)
            {
                StarManager.Instance.AwardStar("Story3");
                sprite3 = Resources.Load<Sprite>("Gear/GearLightIcon");
            }
            else
            {
                sprite3 = Resources.Load<Sprite>("Gear/GearDarkIcon");
            }

            gearIcon1.sprite = sprite1;
            gearIcon3.sprite = sprite3;
        }
        else
        {
            EXPController.RewardXPLose();
            coins.text = "+ 0";
            unlock.text = "";
            unlockIcon.SetActive(false);
            StarManager.Instance.AwardStar("Story3");
            StarManager.Instance.AwardStar("Story3");
            StarManager.Instance.AwardStar("Story3");
            sprite1 = Resources.Load<Sprite>("Gear/GearLightIcon");
            sprite3 = Resources.Load<Sprite>("Gear/GearLightIcon");
            gearIcon1.sprite = sprite1;
            gearIcon3.sprite = sprite3;
        }
    }
    public void Reward4()
    {
        if (!IsStoryDone(4))
        {
            EXPController.RewardXP();
            coinsWon.GetComponent<Shop>().coins += 1000;
            coins.text = "+ 1000";
            unlock.text = "New Story Unlocked";
        }
        else
        {
            EXPController.RewardXPLose();
            coins.text = "+ 0";
            unlock.text = "";
            unlockIcon.SetActive(false);
        }
    }
    public void Reward5()
    {
        if (!IsStoryDone(5))
        {
            EXPController.RewardXP();
            coinsWon.GetComponent<Shop>().coins += 1000;
            coins.text = "+ 1000";
            unlock.text = "";
        }
        else
        {
            EXPController.RewardXPLose();
            coins.text = "+ 0";
            unlock.text = "";
            unlockIcon.SetActive(false);
        }
    }
        
}
