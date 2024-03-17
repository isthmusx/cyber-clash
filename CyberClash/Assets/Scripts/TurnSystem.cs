using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;
using System.Net.Security;
using Random = UnityEngine.Random;

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

    public int random;

    public bool turnEnd;
    public TMP_Text timerText;
    public int seconds;
    public bool timerStart;

    public static int maxEnemyDF;
    public static int currentEnemyDF;
    public TMP_Text enemyDFText;

    public static bool protectStart;


    // Start is called before the first frame update
    void Start()
    {
        StartGame();

        seconds = 20;
        timerStart = true;

        protectStart = true;
        StartCoroutine(Protection());

    }


    // Update is called once per frame
    void Update()
    {
        timerText.text = "" + seconds;
        
        if(isYourTurn == true)
        {
            turnText.text = "Your Turn";
        } else
        {
            turnText.text = "Opponent's Turn";
        }


        DFText.text = currentDF + "/" + maxDF;

        if (isYourTurn == true && seconds >0 && timerStart == true)
        {
            StartCoroutine(Timer());
            timerStart = false;
        }
        if (seconds == 0 && isYourTurn == true)
        {
            EndYourTurn();
            timerStart = true;
            seconds = 20;
            
        }
        

        if(isYourTurn == false && seconds >0 && timerStart == true)
        {
            StartCoroutine(EnemyTimer());
            timerStart=false;
        }

        if(seconds == 0 && isYourTurn == false)
        {
            EndYourOpponentTurn();
            timerStart = true;
            seconds = 20;
        }
        enemyDFText.text = currentEnemyDF + "/" + maxEnemyDF;

        if (AI.AIEndPhase == true)
        {
            EndYourOpponentTurn();
            AI.AIEndPhase = false;
        }

    }

    public void EndYourTurn()
    {
        isYourTurn = false;
        seconds = 20;
        yourOpponentTurn += 1;

        if (maxEnemyDF < 7)
        {
            maxEnemyDF += 1 ;
        }
        currentEnemyDF = maxEnemyDF;

        AI.draw = false;
        StartCoroutine(EnemyTimer());
        
    }
    public void EndYourOpponentTurn()
    {
        isYourTurn = true;
        seconds = 20;
        yourTurn += 1;

        if (maxDF < 7)
        {
            maxDF += 1;
        }
        currentDF = maxDF;

        startTurn = true;
        StartCoroutine(Timer());
    }

    public void StartGame()
    {
        random = Random.Range(0, 2);
        Debug.Log(random);
        if (random == 0)
        {
            isYourTurn = true;
            yourTurn = 1;
            yourOpponentTurn = 0;

            maxDF = 1;
            currentDF = 1;

            maxEnemyDF = 0;
            currentEnemyDF = 0;

            startTurn = false;

        }

        if (random == 1)
        {
            isYourTurn = false;
            yourTurn = 0;
            yourOpponentTurn = 1;

            maxDF = 0;
            currentDF = 0;

            maxEnemyDF = 1;
            currentEnemyDF = 1;
        }
    }

    IEnumerator Timer()
    {
        if (isYourTurn == true && seconds >0)
        {
            yield return new WaitForSeconds(1);
            
            seconds --;
            StartCoroutine(Timer());
        }
    }

    IEnumerator EnemyTimer()
    {
        if (isYourTurn == false && seconds > 0)
        {
            yield return new WaitForSeconds(1);

            seconds--;
            StartCoroutine(EnemyTimer());
        }
    }

    IEnumerator Protection()
    {
        yield return new WaitForSeconds(6f);
        protectStart = false;
    }

}