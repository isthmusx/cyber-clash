using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PrimeNumberChecker : MonoBehaviour
{
    //variables for unity UI
    public GameObject modal;
    public TMP_Text modalText;
    public TMP_InputField inputNum;
    
    
    // check for prime number
    private bool IsPrime(int num)
    {
        //not prime if num is 0 or negative
        if (num < 1)
        {
            return false;
        }

        //check for prime
        for (int i = 2; i <= Math.Sqrt(num); i++)
        {
            if (num % i == 0)
            {
                return false;
            }
        }

        return true;
    }

    private double Factorial(int num)
    {
        int result = 1;

        //if the num is 1 or less it will be 0
        if(num <= 1)
        {
            result = 0;
        }
        
        //calculate for the factorial
        for (int i = 2; i <= num; i++)
        {
            result *= i;
        }

        return result;
    }
    
    //Activate the result modal
    public void ReleaseModal()
    {
        modal.SetActive(true);
        int num = Int32.Parse(inputNum.text);
        
        // Display text result
        if (IsPrime(num))
        {
            modalText.text = num + " is a Prime Number!" + "\n Factorial of " + num + " is " + Factorial(num);
        }
        else
        {
            modalText.text = num + " is not a Prime Number!" + "\n Factorial of " + num + " is " + Factorial(num);
        }
    }
}
