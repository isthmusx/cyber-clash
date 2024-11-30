using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.UI;
public class OpenPack : MonoBehaviour
{
    public float updated;
    public float max;

    public Image bar;

    public GameObject prefab;
    public GameObject pack;

    public GameObject c1;
    public GameObject c2;
    public GameObject c3;
    public GameObject c4;
    public GameObject c5;

    private bool skipPressed = false;

    public GameObject back;
    public GameObject panel;
    public GameObject text;

    public GameObject skipButton; // Reference to the skip button

    private Coroutine openingPackCoroutine; // Track the coroutine

    void Start()
    {
        max = 100;
        updated = 100;

        openingPackCoroutine = StartCoroutine(Wait());
    }

    void Update()
    {
        // Only update the bar if not skipping
        if (!skipPressed)
        {
            bar.fillAmount = updated / max;

            if (updated < 0)
            {
                updated = 0;
            }
            updated -= 50 * Time.deltaTime;
        }
    }

    IEnumerator Wait()
    {
        yield return new WaitForSeconds(2f);

        for (int i = 0; i < 5; i++)
        {
            if (skipPressed)
            {
                ShowAllCards(); // Skip to showing all cards
                yield break; // Exit the coroutine
            }

            Instantiate(prefab, pack.transform.position, Quaternion.identity);
            yield return new WaitForSeconds(1f);
        }

        yield return new WaitForSeconds(2.5f);

        // Now show the cards after pack opening
        skipButton.SetActive(false);// Disable the skip button
        ShowAllCards(); // Call the method to display all cards
    }

    void ShowAllCards()
    {
        if (pack != null) // Check if the pack exists
        {
            Destroy(pack);
        }
        panel.SetActive(true);
        text.SetActive(false);

        // Show all cards with delays
        c1.SetActive(true);
        StartCoroutine(ShowCardWithDelay(c2, 0.5f));
        StartCoroutine(ShowCardWithDelay(c3, 1.0f));
        StartCoroutine(ShowCardWithDelay(c4, 1.5f));
        StartCoroutine(ShowCardWithDelay(c5, 2.0f));

        // Activate back button after a delay
        StartCoroutine(ActivateBackButton(2.5f));
    }

    IEnumerator ShowCardWithDelay(GameObject card, float delay)
    {
        yield return new WaitForSeconds(delay);
        card.SetActive(true);
    }

    IEnumerator ActivateBackButton(float delay)
    {
        yield return new WaitForSeconds(delay);
        back.SetActive(true);
    }

    public void SkipAnimations()
    {
        skipPressed = true; // Set the skip flag

        if (openingPackCoroutine != null) // Stop the coroutine if it's running
        {
            StopCoroutine(openingPackCoroutine);
            skipButton.SetActive(false); // Disable the skip button
            ShowAllCards(); // Immediately show all cards
        }
    }
}