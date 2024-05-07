using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class StoryUsername : MonoBehaviour
{
    public TMP_Text userText;
    // Start is called before the first frame update
    void Start()
    {
        userText.text = PlayerPrefs.GetString("PlayerName");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
