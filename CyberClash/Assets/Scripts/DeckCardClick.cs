using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeckCardClick : MonoBehaviour
{
    
    public CardPreviewPopup previewPopup;

    // Start is called before the first frame update
    void Start()
    {
        previewPopup = FindObjectOfType<CardPreviewPopup>();

        if (previewPopup == null)
        {
            Debug.LogError("CardPreviewPopup not found in the scene.");
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

}
