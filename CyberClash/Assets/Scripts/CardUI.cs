using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;using UnityEngine.UI;

public class CardUI : MonoBehaviour
{
    public TMP_Text nameText;
    public TMP_Text costText;
    public TMP_Text descriptionText;
    public Image cardImage;
    public Image typeOutline;
    public Image typeCost;

    public void SetCard(Card card)
    {
        Debug.Log($"Setting card: {card.cardName}, Type: {card.cardType}, Cost: {card.cardCost}");

        nameText.text = card.cardName;
        costText.text = card.cardCost.ToString();
        descriptionText.text = card.cardDescription;
        cardImage.sprite = card.cardImage;

        switch (card.cardType)
        {
            case "Offense":
                typeOutline.sprite = Resources.Load<Sprite>("OffenseOutline");
                typeCost.sprite = Resources.Load<Sprite>("CardDFOffense");
                nameText.color = new Color32(247, 27, 63, 255);
                break;
            case "Defense":
                typeOutline.sprite = Resources.Load<Sprite>("DefenseOutline");
                typeCost.sprite = Resources.Load<Sprite>("CardDFDefense");
                nameText.color = new Color32(8, 129, 129, 255);
                break;
            case "Utility":
                typeOutline.sprite = Resources.Load<Sprite>("UtilityOutline");
                typeCost.sprite = Resources.Load<Sprite>("CardDFUtility");
                nameText.color = new Color32(255, 153, 20, 255);
                break;
            default:
                Debug.LogWarning("Unknown card type: " + card.cardType);
                break;
        }
    }

}
