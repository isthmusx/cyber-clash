using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using TMPro;
using UnityEngine;

public class CardPreviewPopup : MonoBehaviour
{
    public GameObject cardPreviewPanel; 

    public Image cardImage; 
    public TMP_Text cardNameText; // Reference to the Text component for the card's name
    public TMP_Text cardCostText; // Reference to the Text component for the card's cost
    public TMP_Text cardDescriptionText; // Reference to the Text component for the card's description
    public TMP_Text cardKeywordText; // Reference to the Text component for the card's keyword
    public Image typeCost;
    public Image typeOutline;

    private void Update()
    {
        
    }

    private void Start()
    {
        // Ensure the panel is hidden at the start
        cardPreviewPanel.SetActive(false);
    }

    // This method will be called when a card is clicked
    public void ShowCard(ThisCard thisCard)
    {
        // Set the image and text components with card details
        cardImage.sprite = thisCard.thisSprite;
        cardNameText.text = thisCard.cardName;
        cardCostText.text = thisCard.cardCost.ToString();
        cardDescriptionText.text = thisCard.cardDescription;
        cardKeywordText.text = thisCard.cardKeyword;
        typeCost.preserveAspect = true;

        cardPreviewPanel.SetActive(true);
        switch (thisCard.cardType)
        {
            case "Offense":
                typeOutline.sprite = Resources.Load<Sprite>("OffenseOutline");
                typeCost.sprite = Resources.Load<Sprite>("CardDFOffense");
                cardNameText.color = new Color32(247, 27, 63, 255); 
                break;
            case "Defense":
                typeOutline.sprite = Resources.Load<Sprite>("DefenseOutline");
                typeCost.sprite = Resources.Load<Sprite>("CardDFDefense");
                cardNameText.color = new Color32(8, 129, 129, 255);
                break;
            case "Utility":
                typeOutline.sprite = Resources.Load<Sprite>("UtilityOutline");
                typeCost.sprite = Resources.Load<Sprite>("CardDFUtility");
                cardNameText.color = new Color32(255, 153, 20, 255);
                break;
            default:
                break;
        }
        
    }
    
    public void ShowCardAI(AICardToHand thisCard)
    {
        // Set the image and text components with card details
        cardImage.sprite = thisCard.thisSprite;
        cardNameText.text = thisCard.cardName;
        cardCostText.text = thisCard.cardCost.ToString();
        cardDescriptionText.text = thisCard.cardDescription;
        //cardKeywordText.text = thisCard.cardKeyword;
        typeCost.preserveAspect = true;

        cardPreviewPanel.SetActive(true);
        switch (thisCard.cardType)
        {
            case "Offense":
                typeOutline.sprite = Resources.Load<Sprite>("OffenseOutline");
                typeCost.sprite = Resources.Load<Sprite>("CardDFOffense");
                cardNameText.color = new Color32(247, 27, 63, 255); 
                break;
            case "Defense":
                typeOutline.sprite = Resources.Load<Sprite>("DefenseOutline");
                typeCost.sprite = Resources.Load<Sprite>("CardDFDefense");
                cardNameText.color = new Color32(8, 129, 129, 255);
                break;
            case "Utility":
                typeOutline.sprite = Resources.Load<Sprite>("UtilityOutline");
                typeCost.sprite = Resources.Load<Sprite>("CardDFUtility");
                cardNameText.color = new Color32(255, 153, 20, 255);
                break;
            default:
                break;
        }
        
    }

    // This method can be called by the close button to hide the panel
    public void HideCard()
    {
        cardPreviewPanel.SetActive(false);
    }
}
