using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Collection : MonoBehaviour
{

    public GameObject CardOne;
    public GameObject CardTwo;
    public GameObject CardThree;
    public GameObject CardFour;

    public int x;

    public int[] HowManyCards;

    public TMP_Text CardOneText;
    public TMP_Text CardTwoText;
    public TMP_Text CardThreeText;
    public TMP_Text CardFourText;

    // Start is called before the first frame update
    void Start()
    {
        x = 0;

        for (int i = 0; i <= 18; i++)
        {
            HowManyCards[i] = PlayerPrefs.GetInt("x" + i, 0);
        }

    }

    // Update is called once per frame
    void Update()
    {
        CardOne.GetComponent<CardInCollection>().thisId = x;
        CardTwo.GetComponent<CardInCollection>().thisId = x + 1;
        CardThree.GetComponent<CardInCollection>().thisId = x + 2;
        CardFour.GetComponent<CardInCollection>().thisId = x + 3;

        CardOneText.text = "x" + HowManyCards[x];
        CardTwoText.text = "x" + HowManyCards[x + 1];
        CardThreeText.text = "x" + HowManyCards[x + 2];
        CardFourText.text = "x" + HowManyCards[x + 3];

        if (CardOneText.text == "x0")
        {
            CardOne.GetComponent<CardInCollection>().beGray = true;
        }
        else
        {
            CardOne.GetComponent<CardInCollection>().beGray = false;
        }
        if (CardTwoText.text == "x0")
        {
            CardTwo.GetComponent<CardInCollection>().beGray = true;
        }
        else
        {
            CardTwo.GetComponent<CardInCollection>().beGray = false;
        }
        if (CardThreeText.text == "x0")
        {
            CardThree.GetComponent<CardInCollection>().beGray = true;
        }
        else
        {
            CardThree.GetComponent<CardInCollection>().beGray = false;
        }
        if (CardFourText.text == "x0")
        {
            CardFour.GetComponent<CardInCollection>().beGray = true;
        }
        else
        {
            CardFour.GetComponent<CardInCollection>().beGray = false;
        }

        for (int i = 0; i <= 18; i++)
        {
            PlayerPrefs.SetInt("x" + i, HowManyCards[i]);
        }

    }

    public void Left()
    {
        x -= 4;
    }
    public void Right()
    {
        x += 4;
    }
    public void Card1Minus()
    {
        HowManyCards[x]--;
    }
    public void Card1Plus()
    {
        HowManyCards[x]++;
    }
    public void Card2Minus()
    {
        HowManyCards[x + 1]--;
    }
    public void Card2Plus()
    {
        HowManyCards[x + 1]++;
    }
    public void Card3Minus()
    {
        HowManyCards[x + 2]--;
    }
    public void Card3Plus()
    {
        HowManyCards[x + 2]++;
    }
    public void Card4Minus()
    {
        HowManyCards[x + 3]--;
    }
    public void Card4Plus()
    {
        HowManyCards[x + 3]++;
    }
}
