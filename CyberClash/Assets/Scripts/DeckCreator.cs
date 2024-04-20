using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeckCreator : MonoBehaviour
{

    public int[] cardWithThisId;
    public bool mouseOverDeck;
    public int dragged;
    public GameObject coll;
    public int numberOfCardsInDatabase;
    public int sum;
    public int numberOfDifferentCards;
    public int[] savedDeck;
    public GameObject prefab;
    public bool[] alreadyCreated;
    public static int lastAdded;
    public int[] quantity;
    public GameObject errorModal;
    public GameObject successModal;
    
    // Start is called before the first frame update
    void Start()
    {
        sum = 0;
        numberOfCardsInDatabase = 100;
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void CreateSecurityDeck()
    {

        for (int i = 0; i < numberOfCardsInDatabase; i++)
        {
            sum += cardWithThisId[i];
        }

        if (sum == 30)
        {
            for (int i = 0; i < numberOfCardsInDatabase; i++)
            {
                PlayerPrefs.SetInt("securityDeck" + i, cardWithThisId[i]);
            }
            successModal.SetActive(true);
        }
        else
        {
            errorModal.SetActive(true);
        }
            
            
        sum = 0;
        numberOfDifferentCards = 0;

        for (int i = 0; i < numberOfCardsInDatabase; i++)
        {
            savedDeck[i] = PlayerPrefs.GetInt("securityDeck" + i, 0);
        }

        Debug.Log("Deck Created");

        }
    
    public void CreateThreatDeck()
    {
        for (int i = 0; i < numberOfCardsInDatabase; i++)
        {
            sum += cardWithThisId[i];
            
        }
        
        if (sum == 30)
        {
            for (int i = 0; i < numberOfCardsInDatabase; i++)
            {
                PlayerPrefs.SetInt("threatDeck" + i, cardWithThisId[i]);
            }
            successModal.SetActive(true);
        }
        else
        {
            errorModal.SetActive(true);
        }

        sum = 0;
        numberOfDifferentCards = 0;

        for (int i = 0; i < numberOfCardsInDatabase; i++)
        {
            savedDeck[i] = PlayerPrefs.GetInt("threatDeck" + i, 0);
        }
        
        
    }

    public void EnterDeck()
    {
        mouseOverDeck = true;
    }
    public void ExitDeck()
    {
        mouseOverDeck = false;
    }
    public void Card1()
    {
        if (MainMenu.deckSelected == "Security")
        {
            dragged = Collection.x;
        }
        else if (MainMenu.deckSelected == "Threat")
        {
            dragged = Collection.x + 50;
        }
    }
    public void Card2()
    {
        if (MainMenu.deckSelected == "Security")
        {
            dragged = Collection.x + 1;
        }
        else if (MainMenu.deckSelected == "Threat")
        {
            dragged = Collection.x + 51;
        }
    }
    public void Card3()
    {
        if (MainMenu.deckSelected == "Security")
        {
            dragged = Collection.x + 2;
        }
        else if (MainMenu.deckSelected == "Threat")
        {
            dragged = Collection.x + 52;
        }
    }
    public void Card4()
    {
        if (MainMenu.deckSelected == "Security")
        {
            dragged = Collection.x + 3;
        }
        else if (MainMenu.deckSelected == "Threat")
        {
            dragged = Collection.x + 53;
        }
    }
    public void Card5()
    {
        if (MainMenu.deckSelected == "Security")
        {
            dragged = Collection.x + 4;
        }
        else if (MainMenu.deckSelected == "Threat")
        {
            dragged = Collection.x + 54;
        }
    }

    public void Drop()
    {
        if (mouseOverDeck == true && coll.GetComponent<Collection>().HowManyCards[dragged] > 0 && CanDragCards())
        {
            cardWithThisId[dragged]++;

            //if (cardWithThisId[dragged] > 4)
            //{
            //    cardWithThisId[dragged] = 4;
            //}

            if (cardWithThisId[dragged] < 0)
            {
                cardWithThisId[dragged] = 0;
            }

            coll.GetComponent<Collection>().HowManyCards[dragged]--;

            CalculateDrop();

        }
    }

    public void CalculateDrop()
    {
        lastAdded = 0;
        int i = dragged;

        if (cardWithThisId[i] > 0 && alreadyCreated[i] == false)
        {
            lastAdded = i;
            Instantiate(prefab, new Vector3(0, 0, 0), Quaternion.identity);
            alreadyCreated[i] = true;
            quantity[i] = 1;

        } 
        else if (cardWithThisId[i] > 0 && alreadyCreated[i] == true)
        {
            quantity[i]++;
        }
    }
    public bool CanDragCards()
    {
        int totalCards = 0;
        for (int i = 0; i < cardWithThisId.Length; i++)
        {
            totalCards += cardWithThisId[i];
        }
        return totalCards < 30;
    }

}
