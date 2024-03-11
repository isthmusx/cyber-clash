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

    public GameObject surrenderWindow;


    void Awake()
    {
        //Shuffle();
    }

    void Start()
    {
        x = 0;
        deckSize = 20;

        //for (int i = 0; i < deckSize; i++)
        //{
        //    x = Random.Range(0, 20);
        //    deck[i] = CardDatabase.cardList[x];

        //}

        for (int i = 1; i <= 20; i++)
        {
            if(PlayerPrefs.GetInt("deck" + i, 0) > 0)
            {
                for (int j = 1; j <= PlayerPrefs.GetInt("deck" + i, 0); j++ )
                {
                    deck[x] = CardDatabase.cardList[i];
                    x++;
                }
            }
        }

        //Shuffle();

        StartCoroutine(StartGame());

    }

    
    void Update()
    {
        staticDeck = deck;

        if (deckSize <= 0)
        {
            EndGame.mainTextObject.SetActive(true);
            EndGame.subTextObject.SetActive(true);
            EndGame.background.SetActive(true);
            EndGame.turnText.SetActive(false);
            EndGame.continueBTN.SetActive(true);
            EndGame.victoryText.text = "<color=#F21B3F>Defeat</color>";
            if (MainMenu.faction == "Threat")
            {
                EndGame.victorySubText.text = "You have failed to breach the system.";
            }
            else if (MainMenu.faction == "Security")
            {
                EndGame.victorySubText.text = "You have failed to defend the system.";
            }
        }



        if (deckSize < 30)
        {
            cardInDeck1.SetActive(false);
        }
        if (deckSize < 20)
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
            if (CardsInHand.howMany < 10)
            {
                StartCoroutine(Draw(1));
            }
            else
            {
                
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

    IEnumerator Draw(int x)
    {
        for (int i = 0; i<x; i++)
        {
            yield return new WaitForSeconds(1);
            Instantiate(CardToHand, transform.position, transform.rotation);
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

    public void Surrender()
    {
        StartCoroutine(EndGameNow());
    }

    IEnumerator EndGameNow()
    {
        EndGame.mainTextObject.SetActive(true);
        EndGame.subTextObject.SetActive(true);
        EndGame.background.SetActive(true);
        EndGame.turnText.SetActive(false);
        EndGame.continueBTN.SetActive(true);
        EndGame.victoryText.text = "<color=#F21B3F>Defeat</color>";
        if (MainMenu.faction == "Threat")
        {
            EndGame.victorySubText.text = "You have failed to breach the system.";
        }
        else if (MainMenu.faction == "Security")
        {
            EndGame.victorySubText.text = "You have failed to defend the system.";
        }
        surrenderWindow.SetActive(false);

        yield return new WaitForSeconds(5f);
        SceneManager.LoadScene("Main Menu");
    }

}
