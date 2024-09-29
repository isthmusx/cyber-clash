using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class KeywordComponent : MonoBehaviour
{
    private bool replicateUsed = false; 
    private static bool applyReplicate = false;
    
    // Function to be called when the card is played
    public void OnCardPlayed(string keyword)
    {
        if (keyword == "REPLICATE" && !replicateUsed)
        {
            ActivateReplicate();
            replicateUsed = true;
        }
    }

    // Activate the keyword effect
    private void ActivateReplicate()
    {
        applyReplicate = true;
        Debug.Log("BUFF activated");
    }

    // Function to apply damage
    public int ApplyDamage(int baseDamage)
    {
        if (applyReplicate)
        {
            int doubledDamage = baseDamage * 2;
            applyReplicate = false; 
            Debug.Log("BUFF applied");
            return doubledDamage;
        }
        return baseDamage;
    }


}
