using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TurnIndicator : MonoBehaviour
{
    public GameObject playerPanel;
    public GameObject enemyPanel;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (TurnSystem.isYourTurn == true)
        {
            playerPanel.SetActive(true);
            enemyPanel.SetActive(false);
        }
        else if (TurnSystem.isYourTurn == false)
        {
            playerPanel.SetActive(false);
            enemyPanel.SetActive(true);
        }
    }
}
