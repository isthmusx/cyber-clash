using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class AICardToHand : MonoBehaviour
{
    
    public List<Card> thisCard = new List<Card>();

    public static List<Card> cardsInHandStatic = new List<Card>();
    public List<Card> cardsInHand = new List<Card>();
    public static int cardsInHandNumber;

    public int thisId;
    public int id;

    public string cardName;
    public string cardFaction;
    public string cardType;
    public int cardCost;
    public int cardPower;
    public string cardDescription;

    public TMP_Text nameText;
    public TMP_Text factionText;
    public TMP_Text typeText;
    public TMP_Text costText;
    public TMP_Text descriptionText;

    public Sprite thisSprite;
    public Image thatImage;
    public Image typeOutline;
    public Image typeCost;

    public Image cardFrame;

    public static int DrawX;
    public int drawXcards;
    public int addXmaxDF;

    public int returnXcards;

    public int healXpower;
    public bool canHeal;

    public GameObject Hand;

    public int z;
    public GameObject It;

    public int numberOfCardsInDeck;

    public bool isTarget;
    public GameObject graveyard;
    public GameObject Target;
    public GameObject Enemy;

    public bool thisCardCanBeDestroyed;

    public GameObject cardBack;
    public GameObject AIZone;

    public bool canAttack;
    public bool summoningSickness;

    void Start()
    {


        thisCard[0] = CardDatabase.cardList[thisId];
        Hand = GameObject.Find("Enemy Hand");

        z = 0;
        numberOfCardsInDeck = AI.deckSize;

        graveyard = GameObject.Find("Enemy Graveyard");
        StartCoroutine(AfterVoidStart());

        AIZone = GameObject.Find("Enemy Zone");

        summoningSickness = true;

    }

    
    void Update()
    {
        if(z == 0)
        {
            Hand = GameObject.Find("Enemy Hand");

            It.transform.SetParent(Hand.transform);
            It.transform.localScale = new Vector3(0.4f, 0.44f, 0.4f);
            It.transform.position = new Vector3(transform.position.x, transform.position.y, -48);
            It.transform.eulerAngles = new Vector3(25, 0, 0);

            z = 1;
        }

        id = thisCard[0].id;
        cardName = thisCard[0].cardName;
        cardFaction = thisCard[0].cardFaction;
        cardType = thisCard[0].cardType;
        cardCost = thisCard[0].cardCost;
        cardPower = thisCard[0].cardPower;
        cardDescription = thisCard[0].cardDescription;

        thisSprite = thisCard[0].cardImage;

        returnXcards = thisCard[0].returnXcards;

        healXpower = thisCard[0].healXpower;

        nameText.text = "" + cardName;
        factionText.text = "" + cardFaction;
        typeText.text = "" + cardType;
        costText.text = "" + cardCost;
        descriptionText.text = "" + cardDescription;
        thatImage.sprite = thisSprite;

        typeOutline.preserveAspect = true;
        typeCost.preserveAspect = true;

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

        if(this.tag == "Clone")
        {  

            thisCard[0] = AI.staticEnemyDeck[numberOfCardsInDeck - 1];
            numberOfCardsInDeck -= 1;
            AI.deckSize -= 1;
            this.tag = "Untagged";
        }

        /*if (thisCardCanBeDestroyed == true)
        {
            this.transform.SetParent(graveyard.transform);

        }*/

        if (this.transform.parent == Hand.transform)
        {
            cardBack.SetActive(true);
        }
        if (this.transform.parent == AIZone.transform)
        {
            cardBack.SetActive(false);
        }

        if (TurnSystem.isYourTurn == false && summoningSickness == false)
        {
            canAttack = true;
        }
        else
        {
            canAttack = false;
        }

        if (TurnSystem.isYourTurn == true && this.transform.parent == AIZone.transform)
        {
            summoningSickness = false;
        }
    }

    public void BeingTarget()
    {
        isTarget = true;
    }
    public void DontBeingTarget()
    {
        isTarget = false;
    }

    IEnumerator AfterVoidStart()
    {
        yield return new WaitForSeconds(1);
        thisCardCanBeDestroyed = true;
    }

}
