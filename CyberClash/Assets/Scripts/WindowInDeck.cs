using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class WindowInDeck : MonoBehaviour
{
    public GameObject panel;
    public TMP_Text nameText;
    public int id;
    public int quantityOf;
    public GameObject creator;


    // Start is called before the first frame update
    void Start()
    {
        panel = GameObject.Find("Panel");
        creator = GameObject.Find("Collection");
        transform.SetParent(panel.transform);
        transform.localScale = new Vector3(1, 1, 1);

        id = DeckCreator.lastAdded;
    }

    // Update is called once per frame
    void Update()
    {
        quantityOf = creator.GetComponent<DeckCreator>().quantity[id];
        nameText.text = CardDatabase.cardList[id].cardName + " X " + quantityOf;
    }
}
