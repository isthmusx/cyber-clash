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

    // Start is called before the first frame update
    void Start()
    {
        sum = 0;
        numberOfCardsInDatabase = 18;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void CreateDeck()
    {
        for (int i = 0; i <= numberOfCardsInDatabase; i++)
        {
            sum += cardWithThisId[i];
        }

        if (sum == 20)
        {
            for (int i = 0; i <= numberOfCardsInDatabase; i++)
            {
                PlayerPrefs.SetInt("deck" + i, cardWithThisId[i]);
            }
        }

        sum = 0;
        numberOfDifferentCards = 0;

        for (int i = 0; i <= numberOfCardsInDatabase; i++)
        {
            savedDeck[i] = PlayerPrefs.GetInt("deck" + i, 0);
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
        dragged = Collection.x;
    }
    public void Card2()
    {
        dragged = Collection.x + 1;
    }
    public void Card3()
    {
        dragged = Collection.x + 2;
    }
    public void Card4()
    {
        dragged = Collection.x + 3;
    }

    public void Drop()
    {
        if (mouseOverDeck == true && coll.GetComponent<Collection>().HowManyCards[dragged] > 0)
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

}
