using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AI : MonoBehaviour
{
    // Start is called before the first frame update

    public List<Card> deck = new List<Card>();
    public List<Card> container = new List<Card>();
    public static List<Card> staticEnemyDeck = new List<Card>();
    public List<Card> cardsInHand = new List<Card>();
    public List<Card> cardsInZone = new List<Card>();


    public GameObject Hand;
    public GameObject Zone;
    public GameObject Graveyard;

    public int x;
    public static int deckSize;

    public GameObject cardInDeck1;
    public GameObject cardInDeck2;
    public GameObject cardInDeck3;
    public GameObject cardInDeck4;

    public GameObject CardToHand;

    public GameObject[] Clones;

    public GameObject CardBack;

    public static bool draw;

    public int currentDF;

    public bool[] AICanSummon;

    public bool drawPhase;
    public bool summonPhase;
    public bool attackPhase;
    public bool endPhase;

    public int[] cardsID;

    public int summonThisId;

    public AICardToHand aiCardToHand;

    public int summonID;

    public int howManyCards;

    public bool[] canAttack;
    public static bool AIEndPhase;

    public static int whichEnemy;
    void Awake()
    {
        //Shuffle();
    }

    void Start()
    {

        StartCoroutine(WaitFiveSeconds());

        
        Hand = GameObject.Find("Enemy Hand");
        Zone = GameObject.Find("Enemy Zone");
        Graveyard = GameObject.Find("Enemy Graveyard");

        x = 0;
        deckSize = 40;

        draw = true;

        /*for(int i = 0; i < deckSize; i++)
        {
            x = Random.Range(0, 20);
            deck[i] = CardDatabase.cardList[x];
        }*/

        if (whichEnemy == 1)
        {
            for (int i = 0; i < deckSize; i++)
            {
                if (i <= 19)
                {
                    x = Random.Range(0, 20);
                    deck[i] = CardDatabase.cardList[x];
                }
                else
                {
                    x = Random.Range(0, 20);
                    deck[i] = CardDatabase.cardList[x];
                }
            }
        }

        if (whichEnemy == 2)
        {
            for (int i = 0; i < deckSize; i++)
            {
                if (i <= 19)
                {
                    x = Random.Range(0, 20);
                    deck[i] = CardDatabase.cardList[x];
                    //deck[i] = CardDatabase.cardList[2];
                }
                else
                {
                    x = Random.Range(0, 20);
                    deck[i] = CardDatabase.cardList[x];
                    //deck[i] = CardDatabase.cardList[3];
                }
            }
        }
        
        Shuffle();
        StartCoroutine(StartGame());

    }

    void Update()
    {
        staticEnemyDeck = deck;

        if(deckSize < 30)
        {
            cardInDeck1.SetActive(false);
        }
        if (deckSize < 20)
        {
            cardInDeck1.SetActive(false);
        }
        if (deckSize < 2)
        {
            cardInDeck1.SetActive(false);
        }
        if (deckSize < 1)
        {
            cardInDeck1.SetActive(false);
        }

        if (AICardToHand.DrawX > 0)
        {
            StartCoroutine(Draw(AICardToHand.DrawX));
            AICardToHand.DrawX = 0;
        }
        

        if (TurnSystem.startTurn == false && draw == false)
        {
            StartCoroutine(Draw(1));
            draw = true;
        }

        currentDF = TurnSystem.currentEnemyDF;

        if(0 == 0)
        {
            int j = 0;
            howManyCards = 0;

            foreach (Transform child in Hand.transform)
            {
                howManyCards++;
            }

            foreach (Transform child in Hand.transform)
            {
                cardsInHand[j] = child.GetComponent<AICardToHand>().thisCard[0];
                j++;
            }

            for (int i = 0; i<deckSize; i++)
            {
                if(i >= howManyCards)
                {
                    cardsInHand[i] = CardDatabase.cardList[0];
                }
            }
            j = 0;
        }

        if (TurnSystem.isYourTurn == false)
        {
            for (int i = 0; i < deckSize; i++)
            {
                if (cardsInHand[i].id != 0)
                {
                    if (currentDF >= cardsInHand[i].cardCost)
                    {
                        AICanSummon[i] = true;
                    }
                }
            }
        }
        else
        {
            for (int i = 0; i < deckSize; i++)
            {
                AICanSummon[i] = false;
            }
        }

        if (TurnSystem.isYourTurn == false)
        {
            drawPhase = true;
        }

        if (drawPhase == true && summonPhase == false && attackPhase == false)
        {
            StartCoroutine(WaitForSummonPhase());
        }

        if (TurnSystem.isYourTurn == true)
        {
            drawPhase = false;
            summonPhase = false;
            attackPhase = false;
            endPhase = false;
        }

        // Algorithm Start
        if (summonPhase == true)
        {
            summonID = 0;
            summonThisId = 0;

            int index = 0;
            for (int i = 0; i < deckSize; i++)
            {
                if (AICanSummon[i] == true)
                {
                    cardsID[index] = cardsInHand[i].id;
                    index++;
                }
            }

            for (int i = 0; i < deckSize; i++)
            {
                if (cardsID[i] != 0)
                {
                    if (cardsID[i] > summonID)
                    {
                        summonID = cardsID[i];
                    }
                }
            }

            summonThisId = summonID;

            foreach (Transform child in Hand.transform)
            {
                if (child.GetComponent<AICardToHand>().id == summonThisId && CardDatabase.cardList[summonThisId].cardCost <= TurnSystem.currentEnemyDF)
                {
                    child.transform.SetParent(Zone.transform);
                    TurnSystem.currentEnemyDF -= CardDatabase.cardList[summonThisId].cardCost;
                    Debug.Log("Card Cost for ID " + summonThisId + ": " + CardDatabase.cardList[summonThisId].cardCost);
                    break;
                }

            }

            summonPhase = false;
            attackPhase = true;

        }

        // Algorithm End

        if(0 == 0)
        {
            int k = 0;
            int howManyCards2 = 0;

            foreach (Transform child in Zone.transform)
            {
                howManyCards2++;
            }

            foreach (Transform child in Zone.transform)
            {
                canAttack[k] = child.GetComponent<AICardToHand>().canAttack;
                k++;
            }

            for (int i = 0; i<deckSize; i++)
            {
                if(i >= howManyCards2)
                {
                    canAttack[i] = false;
                }
            }
            k = 0;
        }

        if(0 == 0)
        {
            int l = 0;
            int howManyCards3 = 0;

            foreach (Transform child in Zone.transform)
            {
                howManyCards3++;
            }

            foreach (Transform child in Zone.transform)
            {
                cardsInZone[l] = child.GetComponent<AICardToHand>().thisCard[0];
                l++;
            }

            for (int i = 0; i<deckSize; i++)
            {
                if(i >= howManyCards3)
                {
                    cardsInHand[i] = CardDatabase.cardList[0];
                }
            }
            l = 0;
        }

        if( attackPhase == true && endPhase == false)
        {
            for(int i = 0; i < 40; i++)
            {
                if(canAttack[i] == true)
                {
                    PlayerHealth.staticHP -= cardsInZone[i].cardPower;

                }
            }
            endPhase = true;
        }

        if(endPhase == true)
        {
            AIEndPhase = true;
        }

    }

    public void Shuffle()
    {
        for (int i = 0; i<deckSize; i++)
        {
            container[0] = deck[i];
            int randomIndex = Random.Range(i, deckSize);
            deck[i] = deck[randomIndex];
            deck[randomIndex] = container[0];
        }
        //Instantiate(CardBack, transform.position, transform.rotation);


        StartCoroutine(ShuffleNow());
    }

    IEnumerator StartGame()
    {
        for (int i = 0; i <= 4; i++)
        {
            yield return new WaitForSeconds(1);
            Instantiate(CardToHand, transform.position, transform.rotation);
        }
    }

    IEnumerator ShuffleNow()
    {
        yield return new WaitForSeconds(1);
        Clones = GameObject.FindGameObjectsWithTag("Clone");

        foreach ( GameObject Clone in Clones){
            Destroy(Clone);
        }

    }

    IEnumerator Draw(int x)
    {
        for (int i = 0; i < x; i++)
        {
            yield return new WaitForSeconds(1);
            Instantiate(CardToHand, transform.position, transform.rotation);
        }
    }

    IEnumerator WaitFiveSeconds()
    {
        yield return new WaitForSeconds(Random.Range(1, 5));
    }

    IEnumerator WaitForSummonPhase()
    {
        yield return new WaitForSeconds(Random.Range(1, 5));
        summonPhase = true;
    }
}
