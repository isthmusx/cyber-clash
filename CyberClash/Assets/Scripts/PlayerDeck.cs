using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UIElements;
using UnityEngine.SceneManagement;

public class PlayerDeck : MonoBehaviour
{

    public List<Card> deck = new List<Card>();
    public List<Card> container = new List<Card>();
    public static List<Card> staticDeck = new List<Card>();

    public int x;
    public static int deckSize;

    public GameObject cardInDeck1;
    public GameObject cardInDeck2;
    public GameObject cardInDeck3;
    public GameObject cardInDeck4;

    public GameObject CardToHand;

    public GameObject CardBack;
    public GameObject Deck;

    public GameObject[] Clones;

    public GameObject Hand;

    public EndGame EndGame;

    public static GameObject surrenderWindow;
    public static GameObject battleZone;
    public GameObject zoneBlocker;
    
    public AudioSource drawSFX;

    void Awake()
    {
        //Shuffle();
    }

    void Start()
    {
        battleZone = GameObject.Find("Player Zone");

        
        x = 0;
        deckSize = 30;

        //for (int i = 0; i < deckSize; i++)
        //{
        //    x = Random.Range(0, 20);
        //    deck[i] = CardDatabase.cardList[x];

        //}


        if (MainMenu.faction == "Security")
        {
            for (int i = 0; i < 50; i++)
            {
                if (PlayerPrefs.GetInt("securityDeck" + i, 0) > 0)
                {
                    for (int j = 0; j < PlayerPrefs.GetInt("securityDeck" + i, 0); j++)
                    {
                        deck[x] = CardDatabase.cardList[i];
                        x++;
                    }
                }
            }
        }
        else if (MainMenu.faction == "Threat")
        {
            for (int i = 50; i < 100; i++) 
            {
                if (PlayerPrefs.GetInt("threatDeck" + i, 0) > 0) 
                {
                    for (int j = 0; j < PlayerPrefs.GetInt("threatDeck" + i, 0); j++) 
                    {
                        deck[x] = CardDatabase.cardList[i]; 
                        x++;
                    }
                }
            }
        }
            
            
            
            /*if(PlayerPrefs.GetInt("deck" + i, 0) > 0)
            {
                for (int j = 0; j < PlayerPrefs.GetInt("deck" + i, 0); j++ )
                {
                    deck[x] = CardDatabase.cardList[i];
                    x++;
                }
            }*/
        

        Shuffle();

        StartCoroutine(StartGame());
        
        drawSFX = GameObject.Find("DrawSFX").GetComponent<AudioSource>();

    }

    
    void Update()
    {
        staticDeck = deck;

        /*if (deckSize <= 0)
        {
            StartCoroutine(EndGameNow());
        }*/



        if (deckSize < 20)
        {
            cardInDeck1.SetActive(false);
        }
        if (deckSize < 10)
        {
            cardInDeck2.SetActive(false);
        }
        if (deckSize < 2)
        {
            cardInDeck3.SetActive(false);
        }
        if (deckSize < 1)
        {
            cardInDeck4.SetActive(false);
        }

        if (TurnSystem.startTurn == true)
        {
            if (CardsInHand.howMany < 10 && deckSize > 0)
            {
                StartCoroutine(Draw(1));
            }
            
            
            TurnSystem.startTurn = false;
        }
        
       

    }

    IEnumerator ShuffleNow()
    {
        yield return new WaitForSeconds(1);
        Clones = GameObject.FindGameObjectsWithTag("Clone");

        foreach(GameObject Clone in Clones)
        {
            Destroy(Clone);
        }

    }

    IEnumerator StartGame()
    {
        for(int i=0; i<=4; i++)
        {
            yield return new WaitForSeconds(1);
            Instantiate(CardToHand, transform.position, transform.rotation);
            drawSFX.Play();
        }
    }

    public void Shuffle()
    {
        for (int i = 0; i < deckSize; i++)
        {
            container[0] = deck[i];
            int randomIndex = Random.Range(i, deckSize);
            deck[i] = deck[randomIndex];
            deck[randomIndex] = container[0];
        }

        Instantiate(CardBack, transform.position, transform.rotation);
        StartCoroutine(ShuffleNow());

    }

    public IEnumerator Draw(int x)
    {
        for (int i = 0; i<x; i++)
        {
            yield return new WaitForSeconds(1);
            Instantiate(CardToHand, transform.position, transform.rotation);
            drawSFX.Play();
        }
    }

    public void OpenWindow()
    {
        surrenderWindow.SetActive(true);
    }
    public void CloseWindow()
    {
        surrenderWindow.SetActive(false);
    }

    

}
