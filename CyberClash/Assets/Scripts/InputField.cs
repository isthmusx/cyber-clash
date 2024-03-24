using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class InputField : MonoBehaviour
{
    public TMP_InputField inputField;
    public int maxCharacterLimit = 10; // Set your desired character limit here

    void Start()
    {
        inputField.characterLimit = maxCharacterLimit;
    }
}
