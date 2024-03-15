using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class CardPreview : MonoBehaviour
{
    public static bool isEnlarged = false;
    bool isAnimating = false;
    Vector3 originalScale;
    Vector3 originalPosition;
    Vector3 clickPosition;
    [SerializeField] float verticalOffset = 0f;

    Canvas canvas;

    void Start()
    {
        originalScale = transform.localScale;
        canvas = GetComponentInParent<Canvas>();
        Button button = GetComponent<Button>();
        button.onClick.AddListener(OnClick);
    }

    void OnClick()
    {
        if (!isAnimating && !isEnlarged)
        {
            clickPosition = transform.position;
            StartCoroutine(EnlargeCard());
            
            DisableOtherCardButtons();
        }
        else if (!isAnimating && isEnlarged)
        {
            StartCoroutine(ShrinkCard());
            
            EnableOtherCardButtons();
        }
    }

    IEnumerator EnlargeCard()
    {
        isAnimating = true;
        isEnlarged = true;

        Vector3 centerPosition = canvas.transform.position;
        centerPosition.y += verticalOffset;


        Renderer renderer = GetComponent<Renderer>();
        if (renderer != null)
        {
            renderer.sortingLayerName = "Foreground";
            renderer.sortingOrder = 9999;
        }

        while (transform.localScale.magnitude < originalScale.magnitude * 2.3f)
        {
            transform.localScale += originalScale * (Time.deltaTime * 2.5f);
            transform.position = Vector3.Lerp(transform.position, centerPosition, Time.deltaTime * 5f);
            yield return null;
        }

        isAnimating = false;
    }

    IEnumerator ShrinkCard()
    {
        isAnimating = true;
        isEnlarged = false;

        while (transform.localScale.magnitude > originalScale.magnitude)
        {
            transform.localScale -= originalScale * (Time.deltaTime * 2.5f);
            transform.position = Vector3.Lerp(transform.position, clickPosition, Time.deltaTime * 5f);
            yield return null;
        }

        transform.position = clickPosition;
        isAnimating = false;
    }

    void DisableOtherCardButtons()
    {
        CardPreview[] cards = FindObjectsOfType<CardPreview>();
        foreach (CardPreview card in cards)
        {
            if (card != this)
            {
                Button button = card.GetComponent<Button>();
                if (button != null)
                {
                    button.interactable = false;
                }
            }
        }
    }

    void EnableOtherCardButtons()
    {
        CardPreview[] cards = FindObjectsOfType<CardPreview>();
        foreach (CardPreview card in cards)
        {
            if (card != this)
            {
                Button button = card.GetComponent<Button>();
                if (button != null)
                {
                    button.interactable = true;
                }
            }
        }
    }

    public bool IsEnlarged()
    {
        return isEnlarged;
    }
}
