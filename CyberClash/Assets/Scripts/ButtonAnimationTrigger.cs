using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonAnimationTrigger : MonoBehaviour
{
    private void Start()
    {
        Time.timeScale = 1;
    }

    public Animator animator; // Reference to the Animator component

    // Call this function when the button is clicked
    public void PlayAnimation()
    {
        if (animator != null)
        {
            animator.SetTrigger("PlayAnimation"); // Replace "Play" with the trigger parameter name in your Animator
        }
        Debug.Log("Current Time Scale: " + Time.timeScale);

    }
}
