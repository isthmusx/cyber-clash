using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CardDisplay : MonoBehaviour
{ 
    public GameObject cardPrefab;  // Drag your card prefab into this field in the inspector
    public Transform cardContainer; // Container to hold the cards (e.g., a Panel or an empty GameObject with GridLayoutGroup)

    void Start()
    {
        DisplayCards();
    }

    void DisplayCards()
    {
        Debug.Log("Displaying cards...");

        if (cardPrefab == null)
        {
            Debug.LogError("CardPrefab is not assigned!");
            return;
        }

        if (cardContainer == null)
        {
            Debug.LogError("CardContainer is not assigned!");
            return;
        }

        int cardCount = CardDatabase.cardList.Count;

        // Ensure there are cards in the database
        if (cardCount == 0)
        {
            Debug.LogError("No cards found in CardDatabase!");
            return;
        }

        // Display all cards in the database
        for (int i = 0; i < cardCount; i++)
        {
            Card card = CardDatabase.cardList[i];
            Debug.Log("Instantiating card: " + card.cardName);

            // Instantiate the card and assign it to the container
            GameObject cardObject = Instantiate(cardPrefab, cardContainer);

            if (cardObject != null)
            {
                // Set the card data for the instantiated prefab
                CardUI cardUI = cardObject.GetComponent<CardUI>();
                if (cardUI != null)
                {
                    cardUI.SetCard(card); // Set the card values on the instantiated prefab
                }
                else
                {
                    Debug.LogError("CardUI component missing on instantiated prefab.");
                }
            }
            else
            {
                Debug.LogError("Failed to instantiate card: " + card.cardName);
            }
        }
    }

}
