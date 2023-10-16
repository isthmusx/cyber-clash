using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardBack : MonoBehaviour
{

    public GameObject cardBack;
    public GameObject cardCostBack;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    public void UpdateCard(bool updown)
    {
        cardBack.SetActive(updown);
        cardCostBack.SetActive(!updown);
    }
}
