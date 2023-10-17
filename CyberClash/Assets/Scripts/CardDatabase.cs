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
        cardList.Add(new Card(4, "File Corruptor", "Threat", "Offense", 1, 100, "Corrupt files.\nDeal 50 damage.", Resources.Load<Sprite>("NoImage"), 0, 0));
        cardList.Add(new Card(5, "Encryptor", "Security", "Defense", 3, 100, "Encrypt files.\nGain 200 shields.", Resources.Load<Sprite>("NoImage"), 0, 0));
        cardList.Add(new Card(6, "File Retriever", "Universal", "Utility", 4, 0, "Retrieve deleted files.\nReturn 1 card from graveyard.", Resources.Load<Sprite>("NoImage"), 1, 0));
        cardList.Add(new Card(6, "System Restore", "Universal", "Utility", 2, 0, "Restore system files.\nHeal 100 Health.", Resources.Load<Sprite>("NoImage"), 1, 100));
    }
}
