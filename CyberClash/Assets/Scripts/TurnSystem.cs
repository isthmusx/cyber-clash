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

    public static int maxDF;
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
    public Image playerDF;
    public Image enemyDF;
    public float fillEnemyDF;
    public float fillPlayerDF;
    public float fillEnemyMaxDF;
    public float fillPlayerMaxDF;

    public static bool protectStart;
    public Button endTurnBTN;

    public static int roundCount;
    public static int turnCount;
    public TMP_Text roundText;
    bool isButtonEnabled = true;
    
    
    // Start is called before the first frame update
    void Start()
    {
        StartGame();

        seconds = 120;
        timerStart = true;

        protectStart = true;
        StartCoroutine(Protection());

        roundCount = 1;
        
    }


    // Update is called once per frame
    void Update()
    {
        timerText.text = "" + seconds;
        roundText.text = "Round " + turnCount;
        
        fillPlayerDF = currentDF;
        fillEnemyDF = currentEnemyDF;

        fillPlayerMaxDF = maxDF;
        fillEnemyMaxDF = maxEnemyDF;

        playerDF.fillAmount = fillPlayerDF / fillPlayerMaxDF;
        enemyDF.fillAmount = fillEnemyDF / fillEnemyMaxDF;
        
        if(isYourTurn == true)
        {
            turnText.text = "Your Turn";
            endTurnBTN.interactable = true;
        } else
        {
            turnText.text = "Enemy Turn";
            endTurnBTN.interactable = false;
        }


        DFText.text = currentDF + "/" + maxDF + " Energy";

        if (isYourTurn == true && seconds >0 && timerStart == true)
        {
            StartCoroutine(Timer());
            timerStart = false;
        }
        if (seconds == 0 && isYourTurn == true)
        {
            EndYourTurn();
            timerStart = true;
            seconds = 120;
            
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
            seconds = 120;
        }
        enemyDFText.text = currentEnemyDF + "/" + maxEnemyDF + " Energy";

        if (AI.AIEndPhase == true)
        {
            EndYourOpponentTurn();
            AI.AIEndPhase = false;
        }
        
        

    }

    public void EndYourTurn()
    {
        if (!isButtonEnabled)
            return; //
        
        if (Draggable.GetDraggingObject() != null)
        {
            Draggable.GetDraggingObject().ReturnToParent();
        }

        isYourTurn = false;
        seconds = 120;
        yourOpponentTurn += 1;

        if (maxEnemyDF < 7)
        {
            maxEnemyDF += 1 ;
            
        }
        currentEnemyDF = maxEnemyDF;
        
        

        AI.draw = false;

        turnCount++;

        StartCoroutine(EnemyTimer());
        
        DisableButtonForDelay();
    }
    public void EndYourOpponentTurn()
    {
        if (!isButtonEnabled)
            return; //
        
        isYourTurn = true;
        seconds = 120;
        yourTurn += 1;

        if (maxDF < 7)
        {
            maxDF += 1;
        }
        currentDF = maxDF;


        startTurn = true;

        turnCount++;

        StartCoroutine(Timer());
        
        
    }

    public void StartGame()
    {
        random = Random.Range(0, 2);

        if (!PlayerPrefs.HasKey("TutorialDone") || PlayerPrefs.GetInt("TutorialDone") == 0)
        {
            isYourTurn = true;
            yourTurn = 1;
            yourOpponentTurn = 0;

            maxDF = 1;
            currentDF = 1;

            maxEnemyDF = 0;
            currentEnemyDF = 0;

            startTurn = false;

            turnCount = 1;
        }
        else
        {
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

                turnCount = 1;

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

                turnCount = 1;
            }
        }
        
        
    }

    IEnumerator Timer()
    {
        if (isYourTurn == true && seconds > 0)
        {
            yield return new WaitForSeconds(1f);
            
            seconds --;
            StartCoroutine(Timer());
        }
    }

    IEnumerator EnemyTimer()
    {
        if (isYourTurn == false && seconds > 0)
        {
            yield return new WaitForSeconds(1f);

            seconds--;
            StartCoroutine(EnemyTimer());
        }
    }

    IEnumerator Protection()
    {
        yield return new WaitForSeconds(6f);
        protectStart = false;
    }
    IEnumerator EndTurnDisable()
    {
        yield return new WaitForSeconds(6f);
        endTurnBTN.interactable = true;
    }
    
    void DisableButtonForDelay()
    {
        isButtonEnabled = false;
        StartCoroutine(EnableButtonAfterDelay());
    }

    IEnumerator EnableButtonAfterDelay()
    {
        yield return new WaitForSeconds(1f); // Adjust delay as needed
        isButtonEnabled = true;
    }


}