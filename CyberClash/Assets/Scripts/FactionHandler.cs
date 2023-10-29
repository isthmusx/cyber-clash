using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FactionHandler : MonoBehaviour
{
    public string faction = "";
    public void HandleFactionn(int selectedFaction)
    {
        

        if (selectedFaction == 1)
        {
            faction = "Threat";
        }
        else if (selectedFaction == 2)
        {
            faction = "Security";
        }

        Debug.Log("Selected option: " + faction);
    }
}
