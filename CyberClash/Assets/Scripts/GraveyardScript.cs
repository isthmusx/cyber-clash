using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class GraveyardScript : MonoBehaviour
{
    public List<Card> graveyard = new List<Card>();
    public int howManyCards;
    public GameObject cardBack;

    public GameObject graveWindow;
    public GameObject card1, card2, card3, card4;
    public int controller;
    
    public GameObject[] objectsInGraveyard;
    public GameObject hand;
    public int returnCard;
    public bool uCanReturn;

    // Start is called before the first frame update
    void Start()
    {
        controller = 4;
    }

    // Update is called once per frame
    void Update()
    {
        card1.GetComponent<CardInCollection>().thisId = graveyard[controller - 4].id;
        card2.GetComponent<CardInCollection>().thisId = graveyard[controller - 3].id;
        card3.GetComponent<CardInCollection>().thisId = graveyard[controller - 2].id;
        card4.GetComponent<CardInCollection>().thisId = graveyard[controller - 1].id;

        if (card1.GetComponent<CardInCollection>().thisId == 0)
        {
            card1.SetActive(false);
        }
        else
        {
            card1.SetActive(true);
        }
        if (card2.GetComponent<CardInCollection>().thisId == 0)
        {
            card2.SetActive(false);
        }
        else
        {
            card2.SetActive(true);
        }
        if (card3.GetComponent<CardInCollection>().thisId == 0)
        {
            card3.SetActive(false);
        }
        else
        {
            card3.SetActive(true);
        }
        if (card4.GetComponent<CardInCollection>().thisId == 0)
        {
            card4.SetActive(false);
        }
        else
        {
            card4.SetActive(true);
        }
        
        CalculateGraveyard();

        if (howManyCards > 0)
        {
            cardBack.SetActive(true);
        }
        else
        {
            cardBack.SetActive(false);
        }

        if (returnCard > 0 && uCanReturn == false)
        {
            Open();
            uCanReturn = true;
        }
        
    }

    public void CalculateGraveyard()
    {
        int x = 0;
        for (int i = 0; i<40; i++)
        {
            if (graveyard[i].id != 0)
            {
                x++;
            }
        }

        howManyCards = x;
    }

    public void Open()
    {
        graveWindow.SetActive(true);
    }
    public void Close()
    {
        graveWindow.SetActive(false);
    }
    public void Left()
    {
        if (controller > 4)
        {
            controller--;
        }
    }
    public void Right()
    {
        if (controller < howManyCards)
        {
            controller++;
        }
    }

    public void ReturnCard1()
    {
        if (uCanReturn == true)
        {
            objectsInGraveyard[controller - 4].GetComponent<ThisCard>().summoned = false;
            objectsInGraveyard[controller - 4].GetComponent<ThisCard>().useReturn = false;
            objectsInGraveyard[controller - 4].GetComponent<ThisCard>().beInGraveyard = false;
            objectsInGraveyard[controller - 4].transform.parent = hand.transform;

            card1.GetComponent<CardInCollection>().thisId = 0;
            
            graveyard[controller - 4] = CardDatabase.cardList[0];
            objectsInGraveyard[controller - 4] = null;
            
            Close();

            uCanReturn = false;
            returnCard--;
        }
    }
    
    public void ReturnCard2()
    {
        if (uCanReturn == true)
        {
            objectsInGraveyard[controller - 3].GetComponent<ThisCard>().summoned = false;
            objectsInGraveyard[controller - 3].GetComponent<ThisCard>().useReturn = false;
            objectsInGraveyard[controller - 3].GetComponent<ThisCard>().beInGraveyard = false;
            objectsInGraveyard[controller - 3].transform.parent = hand.transform;

            card2.GetComponent<CardInCollection>().thisId = 0;
            
            graveyard[controller - 3] = CardDatabase.cardList[0];
            objectsInGraveyard[controller - 3] = null;
            
            Close();

            uCanReturn = false;
            returnCard--;
        }
    }
    
    public void ReturnCard3()
    {
        if (uCanReturn == true)
        {
            objectsInGraveyard[controller - 2].GetComponent<ThisCard>().summoned = false;
            objectsInGraveyard[controller - 2].GetComponent<ThisCard>().useReturn = false;
            objectsInGraveyard[controller - 2].GetComponent<ThisCard>().beInGraveyard = false;
            objectsInGraveyard[controller - 2].transform.parent = hand.transform;

            card3.GetComponent<CardInCollection>().thisId = 0;
            
            graveyard[controller - 2] = CardDatabase.cardList[0];
            objectsInGraveyard[controller - 2] = null;
            
            Close();

            uCanReturn = false;
            returnCard--;
        }
    }
    
    public void ReturnCard4()
    {
        if (uCanReturn == true)
        {
            objectsInGraveyard[controller - 1].GetComponent<ThisCard>().summoned = false;
            objectsInGraveyard[controller - 1].GetComponent<ThisCard>().useReturn = false;
            objectsInGraveyard[controller - 1].GetComponent<ThisCard>().beInGraveyard = false;
            objectsInGraveyard[controller - 1].transform.parent = hand.transform;

            card4.GetComponent<CardInCollection>().thisId = 0;
            
            graveyard[controller - 1] = CardDatabase.cardList[0];
            objectsInGraveyard[controller - 1] = null;
            
            Close();

            uCanReturn = false;
            returnCard--;
        }
    }
    
}
