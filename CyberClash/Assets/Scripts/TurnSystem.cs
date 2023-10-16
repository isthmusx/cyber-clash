using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class TurnSystem : MonoBehaviour
{

    public static bool isYourTurn;
    public int yourTurn;
    public int yourOpponentTurn;
    public TMP_Text turnText;

    public int maxDF;
    public static int currentDF;
    public TMP_Text DFText;

    public static bool startTurn; 


    // Start is called before the first frame update
    void Start()
    {
        isYourTurn = true;
        yourTurn = 1;
        yourOpponentTurn = 0;

        maxDF = 1;
        currentDF = 1;

        startTurn = false;

    }

    // Update is called once per frame
    void Update()
    {
        if(isYourTurn == true)
        {
            turnText.text = "Your Turn";
        } else
        {
            turnText.text = "Opponent's Turn";
        }

        DFText.text = currentDF + "/" + maxDF;

    }

    public void EndYourTurn()
    {
        isYourTurn = false;
        yourOpponentTurn += 1;
    }
    public void EndYourOpponentTurn()
    {
        isYourTurn = true;
        yourTurn += 1;

        if (maxDF < 5)
        {
            maxDF += 1;
        }
        currentDF = maxDF;

        startTurn = true;
    }

}
