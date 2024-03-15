using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardDatabase : MonoBehaviour
{
    public static List<Card> cardList = new List<Card>();

    void Awake()
    {
        cardList.Add(new Card(1, "Infiltrator", "Threat", "Offense", 2, 100, "Infiltrate the system.\nDeals <b><color=red>100 Damage</color></b>.", Resources.Load <Sprite> ("Infiltrator"), 0,0));
        cardList.Add(new Card(2, "Fire Wally", "Security", "Defense", 1, 200, "Setup a firewall.\nGain <b><color=blue>50 Shield Power</color></b>.", Resources.Load<Sprite>("NoImage"), 0, 0));
        cardList.Add(new Card(3, "Power Interruption", "Universal", "Utility", 5, 300, "Black out the power source.\nUnable enemy to place cards.", Resources.Load<Sprite>("NoImage"), 0, 0));
        cardList.Add(new Card(4, "File Corrupter", "Threat", "Offense", 1, 100, "Corrupt files.\nDeal 50 damage.", Resources.Load<Sprite>("NoImage"), 0, 0));
        cardList.Add(new Card(5, "Encryptor", "Security", "Defense", 3, 100, "Encrypt files.\nGain 200 shields.", Resources.Load<Sprite>("NoImage"), 0, 0));
        cardList.Add(new Card(6, "Test Card13", "Threat", "Offense", 4, 150, "Sample.", Resources.Load<Sprite>("NoImage"), 0, 0));
        cardList.Add(new Card(7, "File Retriever", "Universal", "Utility", 4, 0, "Retrieve deleted files.\nReturn 1 card from graveyard.", Resources.Load<Sprite>("NoImage"), 1, 0));
        cardList.Add(new Card(8, "System Restore", "Universal", "Utility", 2, 0, "Restore system files.\nHeal 100 Health.", Resources.Load<Sprite>("NoImage"), 1, 100));
        cardList.Add(new Card(9, "Test Card1", "Universal", "Utility", 3, 0, "Sample.", Resources.Load<Sprite>("NoImage"), 0, 0));
        cardList.Add(new Card(10, "Test Card2", "Threat", "Offense", 4, 150, "Sample.", Resources.Load<Sprite>("NoImage"), 0, 0));
        cardList.Add(new Card(11, "Test Card3", "Security", "Defense", 5, 0, "Sample.", Resources.Load<Sprite>("NoImage"), 0, 0));
        cardList.Add(new Card(12, "Test Card4", "Threat", "Offense", 2, 100, "Infiltrate the system.\nDeals <b><color=red>100 Damage</color></b>.", Resources.Load<Sprite>("Infiltrator"), 0, 0));
        cardList.Add(new Card(13, "Test Card5", "Security", "Defense", 1, 200, "Setup a firewall.\nGain <b><color=blue>50 Shield Power</color></b>.", Resources.Load<Sprite>("NoImage"), 0, 0));
        cardList.Add(new Card(14, "Test Card6", "Universal", "Utility", 5, 300, "Black out the power source.\nUnable enemy to place cards.", Resources.Load<Sprite>("NoImage"), 0, 0));
        cardList.Add(new Card(15, "Test Card7", "Threat", "Offense", 1, 100, "Corrupt files.\nDeal 50 damage.", Resources.Load<Sprite>("NoImage"), 0, 0));
        cardList.Add(new Card(16, "Test Card8", "Security", "Defense", 3, 100, "Encrypt files.\nGain 200 shields.", Resources.Load<Sprite>("NoImage"), 0, 0));
        cardList.Add(new Card(17, "Test Card9", "Universal", "Utility", 4, 0, "Retrieve deleted files.\nReturn 1 card from graveyard.", Resources.Load<Sprite>("NoImage"), 1, 0));
        cardList.Add(new Card(18, "Test Card10", "Universal", "Utility", 5, 0, "Restore system files.\nHeal 100 Health.", Resources.Load<Sprite>("NoImage"), 1, 100));
        cardList.Add(new Card(19, "Test Card11", "Universal", "Utility", 5, 0, "Sample.", Resources.Load<Sprite>("NoImage"), 0, 0));
        cardList.Add(new Card(20, "Test Card12", "Threat", "Offense", 5, 150, "Sample.", Resources.Load<Sprite>("NoImage"), 0, 0));
    }
}
