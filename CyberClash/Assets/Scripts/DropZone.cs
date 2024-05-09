using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class DropZone : MonoBehaviour, IDropHandler, IPointerEnterHandler, IPointerExitHandler
{
    CardPreview cardPreview; // Reference to the CardPreview component
    public int maxChildCount = 5;
    void Start()
    {
        cardPreview = GetComponent<CardPreview>(); // Get the CardPreview component attached to the same GameObject
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        if (eventData.pointerDrag == null)
        {
            return;
        }

        // Check if the card is not enlarged before allowing dropping
        if (cardPreview != null && !cardPreview.IsEnlarged())
        {
            Draggable d = eventData.pointerDrag.GetComponent<Draggable>();
            if (d != null)
            {
                d.placeholderParent = this.transform;
            }
        }
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        if (eventData.pointerDrag == null)
        {
            return;
        }

        // Check if the card is not enlarged before allowing dropping
        if (cardPreview != null && !cardPreview.IsEnlarged())
        {
            Draggable d = eventData.pointerDrag.GetComponent<Draggable>();
            if (d != null && d.placeholderParent == this.transform)
            {
                d.placeholderParent = d.parentToReturnTo;
            }
        }
    }

    public void OnDrop(PointerEventData eventData)
    {
        if (PlayerDeck.battleZone.transform.childCount > maxChildCount)
        {
            Debug.Log("Cannot place more cards. Battle zone is full.");
            return;
        }
        Debug.Log(eventData.pointerDrag.name + " was dropped on " + gameObject.name);

        // Check if the card is not enlarged before allowing dropping
        if (cardPreview != null && !cardPreview.IsEnlarged())
        {
            Draggable d = eventData.pointerDrag.GetComponent<Draggable>();
            if (d != null)
            {
                d.parentToReturnTo = this.transform;
            }
        }
    }

    // Method to enable/disable DropZone script

}
