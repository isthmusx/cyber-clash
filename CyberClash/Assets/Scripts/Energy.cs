using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class Energy : MonoBehaviour
{
    public TMP_Text energyText;

    public int energy;
    public int maxEnergy;

    public Button securityBTN;
    public Button threatBTN;


    
    // Start is called before the first frame update
    void Start()
    {
        

        
        maxEnergy = 5;
        energy = 5;
        energy = PlayerPrefs.GetInt("energy", 5);
    }

    public void GetEnergy()
    {
        if (energy < maxEnergy)
        {
            energy += 1;
            PlayerPrefs.SetInt("energy", energy);
        }
    }

    public void UseEnergy()
    {
        if (energy > 0)
        {
            energy -= 1;
            PlayerPrefs.SetInt("energy", energy);
        }
    }

    private void Update()
    {
        energyText.text =  energy.ToString() + " / " + maxEnergy;
        Scene currentScene = SceneManager.GetActiveScene();
        
        if (currentScene.name == "Versus AI")
        {
            if (energy == 0)
            {
                securityBTN.interactable = false;
                threatBTN.interactable = false;
            }
            else
            {
                securityBTN.interactable = true;
                threatBTN.interactable = true;
            }
            
        }

    }
}
