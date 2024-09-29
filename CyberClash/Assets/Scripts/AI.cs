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
    public static bool summoned;

    public int howManyCards;

    public bool[] canAttack;
    public static bool AIEndPhase;

    public static int whichEnemy;

    public GameObject graveyard;

    public AudioSource drawSFX;
    public AudioSource dropSFX;
    public AudioSource attackSFX;
    public AudioSource healSFX;
    public AudioSource shieldSFX;

    void Awake()
    {
        //Shuffle();
    }

    void Start()
    {
        graveyard = GameObject.Find("Enemy Graveyard");
        StartCoroutine(WaitFiveSeconds());
        
        Hand = GameObject.Find("Enemy Hand");
        Zone = GameObject.Find("Enemy Zone");
        Graveyard = GameObject.Find("Enemy Graveyard");
        

        x = 0;
        deckSize = 30;

        draw = true;
        summoned = false;

        /*for(int i = 0; i < deckSize; i++)
        {
            x = Random.Range(0, 20);
            deck[i] = CardDatabase.cardList[x];
        }*/

        if (whichEnemy == 2)
        {
            for (int i = 0; i < deckSize; i++)
            {
                if (i < deckSize)
                {
                    x = Random.Range(0, 50);
                    deck[i] = CardDatabase.cardList[x];
                }
                else
                {
                    x = Random.Range(0, 50);
                    deck[i] = CardDatabase.cardList[x];
                }
            }
        }

        if (whichEnemy == 1)
        {
            for (int i = 0; i < deckSize; i++)
            {
                if (i < deckSize)
                {
                    x = Random.Range(50, 100);
                    deck[i] = CardDatabase.cardList[x];
                    //deck[i] = CardDatabase.cardList[2];
                }
                else
                {
                    x = Random.Range(50, 100);
                    deck[i] = CardDatabase.cardList[x];
                    //deck[i] = CardDatabase.cardList[3];
                }
            }
        }
        if (whichEnemy == 3)
        {
            for (int i = 0; i < deckSize; i++)
            {
                if (i < deckSize)
                {
                    x = Random.Range(105, 109);
                    deck[i] = CardDatabase.cardList[x];
                    //deck[i] = CardDatabase.cardList[2];
                }
                else
                {
                    x = Random.Range(105, 109);
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

        if(deckSize < 20)
        {
            cardInDeck1.SetActive(false);
        }
        if (deckSize < 10)
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
        

        if (TurnSystem.startTurn == false && draw == false && deckSize != 0)
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

            for (int i = 0; i < 50; i++)
            {
                if(i >= howManyCards)
                {
                    cardsInHand[i] = CardDatabase.cardList[0];
                }
            }
            j = 0;
        }

        // Algorithm Start
        
        if (TurnSystem.isYourTurn == false)
        {
            StartCoroutine(CardChecker());
            
            for (int i = 0; i < 50; i++)
            {
                if (cardsInHand[i].id != 0)
                {
                    if (currentDF >= cardsInHand[i].cardCost)
                    {
                        AICanSummon[i] = true;
                    }
                }
            }
            
            if (attackPhase == true && endPhase == false && Zone.transform.childCount > 0)
            {
                for (int i = 0; i < Zone.transform.childCount; i++)
                {
                    Transform cardTransform = Zone.transform.GetChild(i);
                    if (cardTransform != null) // Ensure the card still exists
                    {
                        // Attack the card
                        Debug.Log("Attacking with card: " + cardsInZone[i].cardName + ", Power: " + cardsInZone[i].cardPower);
                        Attack(i);
                        Heal(i);
                        Shield(i);
                        DrawCard(i);
                    }
                }

                endPhase = true; // Set end phase after attacking
            }
        }
        else
        {
            for (int i = 0; i < 50; i++)
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

        
        if (summonPhase == true)
        {
            StartCoroutine(MinimaxDecision());

        }
        
        if(true)
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

            for (int i = 0; i < 50; i++)
            {
                if(i >= howManyCards2)
                {
                    canAttack[i] = false;
                }
            }
            k = 0;

        }

        if(true)
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

            for (int i = 0; i< 50; i++)
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
            
            for(int i = 0; i < 50; i++)
            {
                if (canAttack[i] == true)
                {
                    Debug.Log("Attacking with card: " + cardsInZone[i].cardName + ", Power: " + cardsInZone[i].cardPower + ", Heal: " + cardsInZone[i].healXpower + ", Shield: " + cardsInZone[i].shieldXpower);
                    
                    Attack(i);
                    Heal(i);
                    Shield(i);
                    DrawCard(i);
                    //AddMaxDF(i);
                }
                
            }
            
            endPhase = true;
            
        }
        
        if(endPhase == true)
        {
            
            AIEndPhase = true;
            
        }

    }
    // Algorithm End

    
    
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
        for (int i = 0; i <= 5; i++)
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
        yield return new WaitForSeconds(Random.Range(3, 5));
    }

    IEnumerator WaitForSummonPhase()
    {
        yield return new WaitForSeconds(Random.Range(2, 4));
        summonPhase = true;
    }

    IEnumerator MinimaxDecision()
    {
        // Initialize variables to store the best move and its value
        Card bestMove = null;
        int bestValue = int.MinValue;

        
        
        // Iterate over each card in the AI's hand
        foreach (Transform child in Hand.transform)
        {
            AICardToHand cardToHand = child.GetComponent<AICardToHand>();

            
            Card card = new Card();
            card.id = cardToHand.id;  // Assuming id is a field in AICardToHand representing the card's ID
            card.cardPower = cardToHand.cardPower; // Assuming attack is a field in AICardToHand representing the card's attack value
            card.healXpower = cardToHand.healXpower;
            card.shieldXpower = cardToHand.shieldXpower;
            // Simulate summoning the current card and evaluate the resulting game state
            int value = EvaluateSummon(card);

            // Check if the current card's value is better than the current best move
            if (value > bestValue)
            {
                // Update the best move and its value
                bestMove = card;
                bestValue = value;
            }
        }

        // Execute the best move (summon the chosen card)
        
        yield return StartCoroutine(SimulateSummon(bestMove));
        
    }

    int EvaluateSummon(Card card)
    {
        // Evaluate the desirability of summoning the given card
        // This can be based on various factors such as card attributes, game state, etc.
        // For simplicity, let's assume a basic evaluation function that returns the card's attack value
        
        int score = card.cardPower * 2;
        
        if (EnemyHealth.staticHP <= (EnemyHealth.maxHP * 0.75))
        {
            if (card.healXpower > 0 && EnemyHealth.staticHP < EnemyHealth.maxHP)
            {
                score += card.healXpower * 3; 
            }
            else if (card.shieldXpower > 0)
            {
                score += card.shieldXpower * 2; 
            }
        }
        else
        {
            if (card.cardPower > 0)
            {
                score += card.cardPower * 2; 
            }
        }
        return score;
        
    }

    IEnumerator SimulateSummon(Card card)
    {
        summonThisId = 0;

        if (Hand.transform.childCount <= 0 && Zone.transform.childCount <= 0 && TurnSystem.turnCount != 1)
        {
            EnemyHealth.staticHP = 0;
        }
        else
        {
            int index = 0;
            for (int i = 0; i < deckSize; i++)
            {
                if (AICanSummon[i] == true)
                {
                    cardsID[index] = cardsInHand[i].id;
                    index++;
                }
            }

            if (card != null)
            {
                summonThisId = card.id;
            }
            
            if (TurnSystem.turnCount == 1) 
            {
                yield return new WaitForSeconds(6f); 
            }
            
            if (Zone.transform.childCount < 5)
            {
                foreach (Transform child in Hand.transform)
                {
                    if (child.GetComponent<AICardToHand>().id == summonThisId && CardDatabase.cardList[summonThisId].cardCost <= TurnSystem.currentEnemyDF)
                    {
                        child.transform.SetParent(Zone.transform);
                        TurnSystem.currentEnemyDF -= CardDatabase.cardList[summonThisId].cardCost;
                        summoned = true;
                        dropSFX.Play();
                    }

                }
            }
            else
            {
                Debug.Log("Cannot summon. Zone is full.");
            }
        }

        summonPhase = false;
        attackPhase = true;

        yield return null;
    }

    private void Attack(int i)
    {
        if (PlayerHealth.shield > 0)
        {
            if (PlayerHealth.shield >= cardsInZone[i].cardPower)
            {
                PlayerHealth.shield -= cardsInZone[i].cardPower;
            }
            else
            {
                float excessDamage = cardsInZone[i].cardPower - PlayerHealth.shield;
                PlayerHealth.shield = 0;
                PlayerHealth.staticHP -= excessDamage;
            }
        }
        else
        {
            PlayerHealth.staticHP -= cardsInZone[i].cardPower;
        }
        if (cardsInZone[i].cardPower > cardsInZone[i].shieldXpower && cardsInZone[i].cardPower > cardsInZone[i].healXpower)
        {
            attackSFX.Play();
        }
        else if (cardsInZone[i].shieldXpower > cardsInZone[i].cardPower && cardsInZone[i].shieldXpower > cardsInZone[i].healXpower)
        {
            shieldSFX.Play();
        }
        else if (cardsInZone[i].healXpower > cardsInZone[i].cardPower && cardsInZone[i].healXpower > cardsInZone[i].shieldXpower)
        {
            healSFX.Play();
        }
        
        Transform cardTransform = Zone.transform.GetChild(i);
        cardTransform.SetParent(graveyard.transform);
        cardTransform.position = new Vector3(cardTransform.position.x + 4000, cardTransform.position.y, cardTransform.position.z);
        
    }

    private void Heal(int i)
    {
        if (cardsInZone[i].healXpower > 0)
        {
            EnemyHealth.staticHP += cardsInZone[i].healXpower;
        }
    }

    private void Shield(int i)
    {
        if (cardsInZone[i].shieldXpower > 0)
        {
            EnemyHealth.shield += cardsInZone[i].shieldXpower;
        }
    }

    private void DrawCard(int i)
    {
        if (cardsInZone[i].drawXcards > 0 && deckSize != 0)
        {
            StartCoroutine(Draw(cardsInZone[i].drawXcards));
        }
    }

    private void AddMaxDF(int i)
    {
        TurnSystem.maxEnemyDF += i;
    }

    IEnumerator CardChecker()
    {
        if (howManyCards <= 0 && Zone.transform.childCount <= 0 && TurnSystem.turnCount != 1)
        {
            yield return new WaitForSeconds(3f);
            EnemyHealth.staticHP = 0; // Set enemy health to 0 if both hand and zone are empty
            Debug.Log("Enemy has lost, health set to 0!");
        }
    }
    

}
    

