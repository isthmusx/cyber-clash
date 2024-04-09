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
            if (MainMenu.deckSelected == "Security")
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
                
                if (x <= 0)
                {
                    leftButton.interactable = false;
                }
                else
                {
                    leftButton.interactable = true;
                }
                if (x >= 45)
                {
                    rightButton.interactable = false;
                }
                else
                {
                    rightButton.interactable = true;
                }
                
            }
            else if (MainMenu.deckSelected == "Threat")
            {
                CardOne.GetComponent<CardInCollection>().thisId = x + 50;
                CardTwo.GetComponent<CardInCollection>().thisId = x + 51;
                CardThree.GetComponent<CardInCollection>().thisId = x + 52;
                CardFour.GetComponent<CardInCollection>().thisId = x + 53;
                CardFive.GetComponent<CardInCollection>().thisId = x + 54;

                CardOneText.text = "x" + HowManyCards[x + 50];
                CardTwoText.text = "x" + HowManyCards[x + 51];
                CardThreeText.text = "x" + HowManyCards[x + 52];
                CardFourText.text = "x" + HowManyCards[x + 53];
                CardFiveText.text = "x" + HowManyCards[x + 54];
                
                if (x <= 0)
                {
                    leftButton.interactable = false;
                }
                else
                {
                    leftButton.interactable = true;
                }
                if (x >= 45)
                {
                    rightButton.interactable = false;
                }
                else
                {
                    rightButton.interactable = true;
                }
            }


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
    public void Card5Plus()
    {
        HowManyCards[x + 4]++;
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
        else if(packType == "SecurityOffense")
        {
            rand = Random.Range(0, 20);
            PlayerPrefs.SetInt("x"+rand, (int)HowManyCards[rand]++);
            card = CardDatabase.cardList[rand].cardName;
            print(""+card);

            for (int i = 0; i < 20; i++)
            {
                PlayerPrefs.SetInt("x"+i, (int)HowManyCards[i]);
            }

            o[oo] = rand;
            oo++;
        
            print("card added");
        }
        else if(packType == "SecurityDefense")
        {
            rand = Random.Range(20, 40);
            PlayerPrefs.SetInt("x"+rand, (int)HowManyCards[rand]++);
            card = CardDatabase.cardList[rand].cardName;
            print(""+card);

            for (int i = 20; i < 40; i++)
            {
                PlayerPrefs.SetInt("x"+i, (int)HowManyCards[i]);
            }

            o[oo] = rand;
            oo++;
        
            print("card added");
        }
        else if(packType == "SecurityUtility")
        {
            rand = Random.Range(40, 50);
            PlayerPrefs.SetInt("x"+rand, (int)HowManyCards[rand]++);
            card = CardDatabase.cardList[rand].cardName;
            print(""+card);

            for (int i = 40; i < 50; i++)
            {
                PlayerPrefs.SetInt("x"+i, (int)HowManyCards[i]);
            }

            o[oo] = rand;
            oo++;
        
            print("card added");
        }
        else if(packType == "ThreatOffense")
        {
            rand = Random.Range(50, 70);
            PlayerPrefs.SetInt("x"+rand, (int)HowManyCards[rand]++);
            card = CardDatabase.cardList[rand].cardName;
            print(""+card);

            for (int i = 50; i < 70; i++)
            {
                PlayerPrefs.SetInt("x"+i, (int)HowManyCards[i]);
            }

            o[oo] = rand;
            oo++;
        
            print("card added");
        }
        else if(packType == "ThreatDefense")
        {
            rand = Random.Range(70, 90);
            PlayerPrefs.SetInt("x"+rand, (int)HowManyCards[rand]++);
            card = CardDatabase.cardList[rand].cardName;
            print(""+card);

            for (int i = 70; i < 90; i++)
            {
                PlayerPrefs.SetInt("x"+i, (int)HowManyCards[i]);
            }

            o[oo] = rand;
            oo++;
        
            print("card added");
        }
        else if(packType == "ThreatUtility")
        {
            rand = Random.Range(90, 100);
            PlayerPrefs.SetInt("x"+rand, (int)HowManyCards[rand]++);
            card = CardDatabase.cardList[rand].cardName;
            print(""+card);

            for (int i = 90; i < 100; i++)
            {
                PlayerPrefs.SetInt("x"+i, (int)HowManyCards[i]);
            }

            o[oo] = rand;
            oo++;
        
            print("card added");
        }
        
    }


    
}
