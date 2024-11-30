using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CardInCollection : MonoBehaviour
{
    public List<Card> thisCard = new List<Card>();
    public int thisId;

    public int id;
    public string cardName;
    public int cardCost;
    public string cardDescription;

    public TMP_Text nameText;
    public TMP_Text costText;
    public TMP_Text descriptionText;

    public Sprite thisSprite;
    public Image thatImage;
    public Image typeOutline;
    public Image typeCost;

    public Image cardFrame;

    public bool beGray;
    public GameObject cardBack;
    public CardPreviewPopup previewPopup;

    // Start is called before the first frame update
    void Start()
    {
        thisCard[0] = CardDatabase.cardList[thisId];
        previewPopup = FindObjectOfType<CardPreviewPopup>();
    }

    // Update is called once per frame
    void Update()
    {
        thisCard[0] = CardDatabase.cardList[thisId];

        id = thisCard[0].id;
        cardName = thisCard[0].cardName;
        cardCost = thisCard[0].cardCost;
        cardDescription = thisCard[0].cardDescription;
        thisSprite = thisCard[0].cardImage;

        nameText.text = "" + cardName;
        costText.text = "" + cardCost;
        descriptionText.text = "" + cardDescription;
        thatImage.sprite = thisSprite;

        typeOutline.preserveAspect = true;
        typeCost.preserveAspect = true;

        if (beGray == true)
        {
            cardBack.gameObject.SetActive(true);
        }
        else
        {
            switch (thisCard[0].cardType)
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
                    break;
            }
            cardBack.gameObject.SetActive(false);
        }
    }
    public void OnCardClick()
    {
        if (previewPopup != null)
        {
            // Show card details in the preview popup
            previewPopup.ShowCardDeck(this);
        }
    }
}
