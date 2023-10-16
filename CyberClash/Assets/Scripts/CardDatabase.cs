using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardDatabase : MonoBehaviour
{
    public static List<Card> cardList = new List<Card>();

    void Awake()
    {
        cardList.Add(new Card(1, "Infiltrator", "Threat", "Offense", 2, 100, "Infiltrate the system dealing <b><color=red>100 Damage</color></b>.", Resources.Load <Sprite> ("Infiltrator"), 0));
        cardList.Add(new Card(2, "Fire Wally", "Security", "Defense", 1, 200, "Setup a firewall, gaining <b><color=blue>50 Shield Power</color></b>.", Resources.Load<Sprite>("NoImage"), 0));
        cardList.Add(new Card(3, "Power Interruption", "Universal", "Utility", 5, 300, "Black out the power source, unabling enemy to place cards.", Resources.Load<Sprite>("NoImage"), 0));
        cardList.Add(new Card(4, "File Corruptor", "Threat", "Offense", 1, 100, "Corrupt files dealing 50 instant damage.", Resources.Load<Sprite>("NoImage"), 0));
        cardList.Add(new Card(5, "Encryptor", "Security", "Defense", 3, 100, "Encrypt files gaining 200 shields.", Resources.Load<Sprite>("NoImage"), 0));
        cardList.Add(new Card(6, "File Retriever", "Universal", "Utility", 4, 0, "Retrieve deleted files.\nReturn 1 card from graveyard.", Resources.Load<Sprite>("NoImage"), 1));
    }
}
