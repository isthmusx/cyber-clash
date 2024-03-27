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
    public GameObject CardFive;

    public static int x;

    public int[] HowManyCards;

    public TMP_Text CardOneText;
    public TMP_Text CardTwoText;
    public TMP_Text CardThreeText;
    public TMP_Text CardFourText;
    public TMP_Text CardFiveText;

    public Button leftButton;
    public Button rightButton;
    
    public bool openPack;
    public int[] o;
    public int oo;
    public int rand;
    public string card;

    public int cardsInCollection;
    public int numberOfCardsInPage;

    public static string packType;
    
    // Start is called before the first frame update
    void Start()
    {
        x = 0;

        for (int i = 0; i < 100; i++)
        {
            HowManyCards[i] = PlayerPrefs.GetInt("x" + i, 0);
        }

        if (openPack == true)
        {
            for (int i = 0; i<=4;i++)
            {
                GetRandomCard();
            }
        }

        cardsInCollection = 100;
        numberOfCardsInPage = 5;

    }
    
    void Update()
    {
        if (openPack == false)
        {
            CardOne.GetComponent<CardInCollection>().thisId = x;
            CardTwo.GetComponent<CardInCollection>().thisId = x + 1;
            CardThree.GetComponent<CardInCollection>().thisId = x + 2;
            CardFour.GetComponent<CardInCollection>().thisId = x + 3;
            CardFive.GetComponent<CardInCollection>().thisId = x + 4;

            CardOneText.text = "x" + HowManyCards[x];
            CardTwoText.text = "x" + HowManyCards[x + 1];
            CardThreeText.text = "x" + HowManyCards[x + 2];
            CardFourText.text = "x" + HowManyCards[x + 3];
            CardFiveText.text = "x" + HowManyCards[x + 4];

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
            if (CardFiveText.text == "x0")
            {
                CardFive.GetComponent<CardInCollection>().beGray = true;
            }
            else
            {
                CardFive.GetComponent<CardInCollection>().beGray = false;
            }
        }

        for (int i = 0; i < 100; i++)
        {
            PlayerPrefs.SetInt("x" + i, HowManyCards[i]);
        }

        if (openPack == true)
        {
            CardOne.GetComponent<CardInCollection>().thisId = o[0];
            CardTwo.GetComponent<CardInCollection>().thisId = o[1];
            CardThree.GetComponent<CardInCollection>().thisId = o[2];
            CardFour.GetComponent<CardInCollection>().thisId = o[3];
            CardFive.GetComponent<CardInCollection>().thisId = o[4];
        }
        
        if (x <= 0)
        {
            leftButton.interactable = false;
        }
        else
        {
            leftButton.interactable = true;
        }
        if (x >= 95)
        {
            rightButton.interactable = false;
        }
        else
        {
            rightButton.interactable = true;
        }
        
    }

    public void Left()
    {
        if (x != 1)
        {
            x -= numberOfCardsInPage;
        }
    }
    public void Right()
    {
        if (x != (cardsInCollection - numberOfCardsInPage) + 1) ;
        {
            x += numberOfCardsInPage;
        }
        
        Debug.Log(x);
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

    public void GetRandomCard()
    {
        if (packType == "Security")
        {
            rand = Random.Range(0, 50);
            PlayerPrefs.SetInt("x"+rand, (int)HowManyCards[rand]++);
            card = CardDatabase.cardList[rand].cardName;
            print(""+card);

            for (int i = 0; i<50; i++)
            {
                PlayerPrefs.SetInt("x"+i, (int)HowManyCards[i]);
            }

            o[oo] = rand;
            oo++;
        
            print("card added");
        }
        else if(packType == "Threat")
        {
            rand = Random.Range(50, 100);
            PlayerPrefs.SetInt("x"+rand, (int)HowManyCards[rand]++);
            card = CardDatabase.cardList[rand].cardName;
            print(""+card);

            for (int i = 50; i<100; i++)
            {
                PlayerPrefs.SetInt("x"+i, (int)HowManyCards[i]);
            }

            o[oo] = rand;
            oo++;
        
            print("card added");
        }
        
    }


    
}
