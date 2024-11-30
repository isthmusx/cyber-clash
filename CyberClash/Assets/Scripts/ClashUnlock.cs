using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ClashUnlock : MonoBehaviour
{
    public Button clashButton; 
    // Start is called before the first frame update
    void Start()
    {
        if (PlayerPrefs.GetInt("storyComplete", 0) == 1)
        {
            // Unlock the button if the story is complete
            clashButton.interactable = true;
        }
        else
        {
            // Keep the button locked if the story is not complete
            clashButton.interactable = false;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void UnlockClash()
    {
        PlayerPrefs.SetInt("storyComplete", 1);
    }
}
