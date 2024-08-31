using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]

public class Card
{
    public int id;
    public string cardName;
    public string cardFaction;
    public string cardType;
    public int cardCost;
    public int cardPower;
    public string cardDescription;

    public Sprite cardImage;

    public int returnXcards;

    public int healXpower;

    public int shieldXpower;

    public int drawXcards;

    public string cardKeyword;
    

    public Card()
    {

    }

    public Card(int Id, string CardName, string CardFaction, string CardType, int CardCost, int CardPower, string CardDescription, Sprite CardImage, int ReturnXcards, int HealXpower, int ShieldXpower, int DrawXcards, string CardKeyword)
    {
        id = Id;
        cardName = CardName;
        cardFaction = CardFaction;
        cardType = CardType;
        cardCost = CardCost;
        cardPower = CardPower;
        cardDescription = CardDescription;
        cardImage = CardImage;
        returnXcards = ReturnXcards;
        healXpower = HealXpower;
        shieldXpower = ShieldXpower;
        drawXcards = DrawXcards;
        cardKeyword = CardKeyword;
    }

}
