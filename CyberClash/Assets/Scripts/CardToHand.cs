using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardToHand : MonoBehaviour
{
    public GameObject Hand;
    public GameObject It;

    // Start is called before the first frame update
    void Start()
    {
        Hand = GameObject.Find("Hand");

            It.transform.SetParent(Hand.transform);
            It.transform.localScale = new Vector3(0.4f, 0.44f, 0.4f);
            It.transform.position = new Vector3(transform.position.x, transform.position.y, -48);
            It.transform.eulerAngles = new Vector3(25, 0, 0);
        
    }

    // Update is called once per frame
    void Update()
    {


            


    }
}
