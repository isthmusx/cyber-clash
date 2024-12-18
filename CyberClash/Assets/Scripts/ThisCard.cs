using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using TMPro;
using System;

public class ThisCard : MonoBehaviour
{
    
    public List<Card> thisCard = new List<Card>();
    public int thisId;

    public int id;
    public string cardName;
    public string cardFaction;
    public string cardType;
    public int cardCost;
    public int cardPower;
    public string cardDescription;
    public string cardKeyword;
    public string cardInfo;
    
    public TMP_Text nameText;
    public TMP_Text factionText;
    public TMP_Text typeText;
    public TMP_Text costText;
    public TMP_Text descriptionText;
    public TMP_Text keywordText;
    
    public Sprite thisSprite;
    public Image thatImage;
    public Image typeOutline;
    public Image typeCost;

    public Image cardFrame;

    public bool cardBack;
    public static bool staticCardBack;
    CardBack CardBackScript;

    public GameObject Hand;

    public int numberOfCardInDeck;

    public bool canBeSummon;
    public bool summoned;
    public GameObject battleZone;

    public GameObject attackBorder;
    public GameObject summonBorder;

    public GameObject Target;
    public GameObject Enemy;

    public bool summoningSickness;
    public bool cantAttack;
    public bool canAttack;

    public static bool staticTargeting;
    public static bool staticTargetingEnemy;
    public bool targeting;
    public bool targetingEnemy;
    public bool onlyThisCardAttack;

    public bool canBeDestroyed;
    public GameObject Graveyard;
    public bool beInGraveyard;

    public int returnXcards;
    public bool useReturn;
    public static bool uCanReturn;

    public int healXpower;
    public bool canHeal;

    public int shieldXpower;
    public bool canShield;

    public int drawXcards;

    public int getXdatafrag;

    public int trueDamageXpower;
    
    public GameObject EnemyZone;
    public GameObject AICardToHand;

    public PlayerDeck playerDeck;
    
    public AudioSource attackSFX;
    public AudioSource shieldSFX;
    public AudioSource healSFX;
    public AudioSource dropSFX;
    public AudioSource trueDamageSFX;
    public AudioSource gainDFSFX;
    public AudioSource drawCardSFX;

    public KeywordComponent keywordComponent;
    public CardPreviewPopup previewPopup;
    
    public Animator attackAnimator;
    public Animator trueDamageAnimator;
    public Animator gainDataFragAnimator;
    public Animator drawCardAnimator;
    public Animator shieldAnimator;
    public Animator healAnimator;


    // Start is called before the first frame update
    void Start()
    {
        previewPopup = FindObjectOfType<CardPreviewPopup>();

        if (previewPopup == null)
        {
            Debug.LogError("CardPreviewPopup not found in the scene.");
        }
        keywordComponent = GetComponent<KeywordComponent>();
        CardBackScript = GetComponent<CardBack>();
        thisCard.Add(CardDatabase.cardList[thisId]);
        //thisCard[0] = CardDatabase.cardList[thisId];
        numberOfCardInDeck = PlayerDeck.deckSize;

        staticCardBack = cardBack;

        canBeSummon = false;
        summoned = false;

        canAttack = false;
        summoningSickness = true;

        Enemy = GameObject.Find("Enemy Character");

        targeting = false;
        targetingEnemy = false;

        canHeal = true;
        canShield = true;

        EnemyZone = GameObject.Find("Enemy Zone");
        Graveyard = GameObject.Find("Player Graveyard");
        playerDeck = FindObjectOfType<PlayerDeck>();
        
        attackSFX = GameObject.Find("AttackSFX").GetComponent<AudioSource>();
        healSFX = GameObject.Find("HealSFX").GetComponent<AudioSource>();
        shieldSFX = GameObject.Find("ShieldSFX").GetComponent<AudioSource>();
        dropSFX = GameObject.Find("DropSFX").GetComponent<AudioSource>();
        trueDamageSFX = GameObject.Find("TrueDamageSFX").GetComponent<AudioSource>();
        gainDFSFX = GameObject.Find("GainDFSFX").GetComponent<AudioSource>();
        drawCardSFX = GameObject.Find("DrawCardSFX").GetComponent<AudioSource>();
        
        attackAnimator = GameObject.FindWithTag("AttackAnimator")?.GetComponent<Animator>();
        trueDamageAnimator = GameObject.FindWithTag("TrueDamageAnimator")?.GetComponent<Animator>();
        healAnimator = GameObject.FindWithTag("HealAnimator")?.GetComponent<Animator>();
        shieldAnimator = GameObject.FindWithTag("ShieldAnimator")?.GetComponent<Animator>();
        gainDataFragAnimator = GameObject.FindWithTag("EnergyAnimator")?.GetComponent<Animator>();
        drawCardAnimator = GameObject.FindWithTag("DrawAnimator")?.GetComponent<Animator>();

    }

    // Update is called once per frame
    void Update()
    {
        Hand = GameObject.Find("Hand");
        if (this.transform.parent == Hand.transform.parent)
        {
            cardBack = false;
        }

        id = thisCard[0].id;
        cardName = thisCard[0].cardName;
        cardFaction = thisCard[0].cardFaction;
        cardType = thisCard[0].cardType;
        cardCost = thisCard[0].cardCost;
        cardPower = thisCard[0].cardPower;
        cardDescription = thisCard[0].cardDescription;
        cardKeyword = thisCard[0].cardKeyword;
        cardInfo = thisCard[0].cardInfo;
        thisSprite = thisCard[0].cardImage;

        returnXcards = thisCard[0].returnXcards;

        healXpower = thisCard[0].healXpower;
        
        shieldXpower = thisCard[0].shieldXpower;
        
        drawXcards = thisCard[0].drawXcards;

        getXdatafrag = thisCard[0].getXdatafrag;

        trueDamageXpower = thisCard[0].trueDamageXpower;

        nameText.text = "" + cardName;
        factionText.text = "" + cardFaction;
        typeText.text = "" + cardType;
        costText.text = "" + cardCost;
        descriptionText.text = "" + cardDescription;
        keywordText.text = "" + cardKeyword;
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

        //CardBackScript.UpdateCard(cardBack);

        if (this.tag == "Clone")
        {
            thisCard[0] = PlayerDeck.staticDeck[numberOfCardInDeck - 1];
            numberOfCardInDeck -= 1;
            PlayerDeck.deckSize -= 1;
            cardBack = false;
            this.tag = "Untagged";
        }


        if (TurnSystem.currentDF >= cardCost && summoned == false && beInGraveyard == false && TurnSystem.isYourTurn == true && TurnSystem.protectStart == false)
        {
            canBeSummon = true;
        }
        else
        {
            canBeSummon = false;
        }

        if (canBeSummon == true)
        {
            gameObject.GetComponent<Draggable>().enabled = true;
            StartAttack();
        }
        else
        {
            gameObject.GetComponent<Draggable>().enabled = false;
        }

        battleZone = GameObject.Find("Player Zone");

        if (summoned == false && this.transform.parent == battleZone.transform)
        {
            Summon();
        }
        
        if(canAttack == true && beInGraveyard == false)
        {
            attackBorder.SetActive(true);
        } else
        {
            attackBorder.SetActive(false);
        }
                
        if (TurnSystem.isYourTurn == false && summoned == true)
        {
            summoningSickness = false;
            canAttack = false;
        }

        if (TurnSystem.isYourTurn == true && summoningSickness == false && cantAttack == false)
        {
            canAttack = true;
        }else
        {
            canAttack = false;
        }

        targeting = staticTargeting;
        targetingEnemy = staticTargetingEnemy;

        if (targetingEnemy == true)
        {
            Target = Enemy;
        } else
        {
            Target = null;
        }

        if (targeting == true /* && targetingEnemy == true */ && onlyThisCardAttack == true)
        {
            Attack();
        }

        if (canBeSummon == true || uCanReturn == true && beInGraveyard == true)
        {
            summonBorder.SetActive(true);
        } else
        {
            summonBorder.SetActive(false);
        }

        
        /*if (returnXcards > 0 && summoned == true && useReturn == false && TurnSystem.isYourTurn == true)
        {
            Return(returnXcards);
            useReturn = true;
        }*/

        if (TurnSystem.isYourTurn == false)
        {
            uCanReturn = false;
        }
        
        //KEYWORDS
        

    }

    public void Summon()
    {
        TurnSystem.currentDF -= cardCost;
        summoned = true;
        dropSFX.Play();
        
        if (PlayerDeck.deckSize !=0 && drawXcards > 0)
        {
            StartCoroutine(playerDeck.Draw(drawXcards));
        }
        if (TurnSystem.currentDF < TurnSystem.maxDF && getXdatafrag > 0)
        {
            TurnSystem.currentDF += getXdatafrag;
        }

    }
    
    public void PlayCard()
    {
        if (keywordComponent != null && cardKeyword != "None")
        {
            keywordComponent.OnCardPlayed(cardKeyword);
        }

    }

    public void Attack()
    {
        if (canAttack == true && summoned == true)
        {
            int damageToDeal = cardPower;

            // Apply keyword effects
            if (keywordComponent != null)
            {
                damageToDeal = keywordComponent.ApplyDamage(cardPower);
            }
            
            if (Target != null)
            {
                if (Target == Enemy)
                {
                    PlayCard();
                    Debug.Log(damageToDeal);
                    if (EnemyHealth.shield > 0)
                    {
                        if (EnemyHealth.shield >= damageToDeal)
                        {
                            EnemyHealth.shield -= damageToDeal;
                        }
                        else
                        {
                            float excessDamage = damageToDeal - EnemyHealth.shield;
                            EnemyHealth.shield = 0;
                            EnemyHealth.staticHP -= excessDamage;
                        }
                    }
                    else
                    {
                        EnemyHealth.staticHP -= damageToDeal;
                    }

                    if (trueDamageXpower > 0)
                    {
                        EnemyHealth.staticHP -= trueDamageXpower;
                    }
                    
                    targeting = false;
                    cantAttack = true;

                    Arrow._Hide = true;
                    
                    if (canHeal == true && summoned == true)
                    {
                        Heal();
                        canHeal = false;
                    }
        
                    if (canShield == true && summoned == true)
                    {
                        Shield();
                        canShield = false;
                    }

                    if (PlayerDeck.deckSize !=0 && summoned == true)
                    {
                        //StartCoroutine(playerDeck.Draw(drawXcards));
                    }

                    if (cardPower > shieldXpower && cardPower > healXpower)
                    {
                        attackSFX.Play();
                        attackAnimator.SetTrigger("TriggerDamage");
                    }
                    else if (trueDamageXpower > 0)
                    {
                        trueDamageSFX.Play();
                        trueDamageAnimator.SetTrigger("TriggerDamage");
                    }
                    else if (getXdatafrag > 0)
                    {
                        gainDFSFX.Play();
                        gainDataFragAnimator.SetTrigger("TriggerHeal");
                    }
                    else if (drawXcards > 0)
                    {
                        drawCardAnimator.SetTrigger("TriggerHeal");
                        drawCardSFX.Play();
                    }
                    else if (shieldXpower > cardPower && shieldXpower > healXpower)
                    {
                        shieldSFX.Play();
                        shieldAnimator.SetTrigger("TriggerHeal");
                    }
                    else if (healXpower > cardPower && healXpower > shieldXpower)
                    {
                        healSFX.Play();
                        healAnimator.SetTrigger("TriggerHeal");
                    }
                    
                    
                    Destroy();

                }
            }
            else
            {
                foreach(Transform child in EnemyZone.transform)
                {
                    if (child.GetComponent<AICardToHand>().isTarget == true)
                    {
                        /* child.GetComponent<AICardToHand>().hurted = cardPower;
                        hurted = child.GetComponent<AICardToHand>().cardPower; */
                        cantAttack = true;
                        
                        //Arrow._Hide = true;
                    }
                }
            }
        }
    }

    public void UntargetEnemy()
    {
        staticTargetingEnemy = false;
    }
    public void TargetEnemy()
    {
        staticTargetingEnemy = true;
    }
    public void StartAttack()
    {
        staticTargeting = true;
        if (canAttack == true)
        {
            Arrow._Show = true;
            Arrow.startPoint = transform.position;
        }
    }
    public void StopAttack()
    {
        staticTargeting = false;
    }
    public void OneCardAttack()
    {
        onlyThisCardAttack = true;
    }
    public void OneCardAttackStop()
    {
        onlyThisCardAttack = false;
    }

    public void Destroy()
    {
        Graveyard = GameObject.Find("Player Graveyard");
        canBeDestroyed = true;
        if (canBeDestroyed == true)
        {
            /*this.transform.SetParent(Graveyard.transform);
            canBeDestroyed = false;
            summoned = false;
            beInGraveyard = true;*/

            for (int i = 0; i < 100; i++)
            {
                if (Graveyard.GetComponent<GraveyardScript>().graveyard[i].id == 0)
                {
                    Graveyard.GetComponent<GraveyardScript>().graveyard[i] = CardDatabase.cardList[id];

                    Graveyard.GetComponent<GraveyardScript>().objectsInGraveyard[i] = this.gameObject;
                    
                    canBeDestroyed = false;
                    summoned = false;
                    beInGraveyard = true;
                    transform.SetParent(Graveyard.transform);
                    transform.position = new Vector3(transform.position.x + 4000, transform.position.y,
                        transform.position.z);

                    break;
                }
            }
            
        }

    }

    public void Return(int x)
    {
        Graveyard.GetComponent<GraveyardScript>().returnCard = x;
    }

    /*public void ReturnCard()
    {
        uCanReturn = true;
    }

    public void ReturnThis()
    {
        if (beInGraveyard == true && uCanReturn == true)
        {
            this.transform.SetParent(Hand.transform);
            uCanReturn = false;
            beInGraveyard = false;
            summoningSickness = true;
        }
    }*/

    public void Heal()
    {
        PlayerHealth.shield += healXpower;
    }
    public void Shield()
    {
        PlayerHealth.shield += shieldXpower;
    }
    public void OnCardClick()
    {
        if (previewPopup != null)
        {
            // Show card details in the preview popup
            previewPopup.ShowCard(this);
        }
    }

}