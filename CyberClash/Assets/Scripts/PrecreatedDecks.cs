using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PrecreatedDecks : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void DeckSelected(int num)
    {
        int[][] precreatedDecks = new int[][]
        {
            new int[] {1, 1, 1, 1, 0, 1, 1, 0, 1, 1, 1, 1, 0, 1, 1, 1, 0, 1, 1, 0, 1, 1, 0, 0, 1, 1, 0, 1, 1, 0, 0, 1, 0, 0, 1, 0, 0, 1, 0, 0, 1, 0, 1, 0, 1, 1, 1, 0, 0, 1},
            new int[] {0, 1, 1, 1, 1, 0, 1, 1, 1, 0, 1, 1, 0, 1, 1, 1, 1, 1, 0, 0, 1, 0, 1, 0, 1, 0, 1, 0, 0, 0, 1, 1, 0, 1, 1, 0, 1, 0, 1, 0, 1, 0, 1, 0, 1, 0, 1, 1, 0, 1},
            new int[] {1, 1, 1, 0, 1, 1, 1, 1, 1, 0, 1, 1, 1, 0, 1, 1, 1, 0, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 1, 1, 1, 1, 0, 1, 1, 0, 1, 1, 1, 0, 1, 1, 0, 0, 1, 1, 1}
        };


        if (num >= 0 && num < precreatedDecks.Length)
        {
            for (int i = 0; i < precreatedDecks[num].Length; i++)
            {
                PlayerPrefs.SetInt("securityDeck" + i, precreatedDecks[num][i]);
                PlayerPrefs.SetInt("threatDeck" + i, precreatedDecks[num][i]);
            }

            Debug.Log($"Deck {num} selected and saved successfully!");
        }
        else
        {
            Debug.LogError("Invalid deck index!");
        }
    }


}
