using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Draggable : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{

    public Transform parentToReturnTo = null;
    public Transform placeholderParent = null;
    private static Draggable dragging;

    GameObject placeholder = null;
    CardPreview cardPreview;
    
    void Start()
    {
        cardPreview = GetComponent<CardPreview>();
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        dragging = this;
        //Debug.Log("OnBeginDrag");
        if (!cardPreview.IsEnlarged())
        {

            if (this != null && this.transform != null && this.transform.parent != null)
            {
                placeholder = new GameObject();
                placeholder.transform.SetParent(this.transform.parent);

                if (this.GetComponent<LayoutElement>() != null)
                {
                    LayoutElement le = placeholder.AddComponent<LayoutElement>();
                    le.preferredWidth = this.GetComponent<LayoutElement>().preferredWidth;
                    le.preferredHeight = this.GetComponent<LayoutElement>().preferredHeight;
                    le.flexibleWidth = 0;
                    le.flexibleHeight = 0;
                }

                placeholder.transform.SetSiblingIndex(this.transform.GetSiblingIndex());

                parentToReturnTo = this.transform.parent;
                placeholderParent = parentToReturnTo;

                if (this.transform.parent != null && this.transform.parent.parent != null)
                {
                    this.transform.SetParent(this.transform.parent.parent);
                }

                if (GetComponent<CanvasGroup>() != null)
                {
                    GetComponent<CanvasGroup>().blocksRaycasts = false;
                }
            }
        }
    }

    public void OnDrag(PointerEventData eventData)
    {
        //Debug.Log("OnDrag");
        if (!cardPreview.IsEnlarged())
        {
            this.transform.position = eventData.position;

            if (placeholder.transform.parent != placeholderParent)
            {
                placeholder.transform.SetParent(placeholderParent);
            }

            int newSiblingIndex = placeholderParent.childCount;

            for (int i = 0; i < placeholderParent.childCount; i++)
            {
                if (this.transform.position.x < placeholderParent.GetChild(i).position.x)
                {
                    newSiblingIndex = i;

                    if (placeholder.transform.GetSiblingIndex() < newSiblingIndex)
                    {
                        newSiblingIndex--;
                    }

                    break;
                }
            }

            placeholder.transform.SetSiblingIndex(newSiblingIndex);
        }
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        dragging = null;
        // Check if the parent to return to is not null
        if (parentToReturnTo != null)
        {
            // Set the parent and sibling index of the dragged object
            this.transform.SetParent(parentToReturnTo);

            // Ensure placeholder is not null before accessing its sibling index
            if (placeholder != null)
            {
                this.transform.SetSiblingIndex(placeholder.transform.GetSiblingIndex());
            }

            // Enable raycasts for the dragged object
            GetComponent<CanvasGroup>().blocksRaycasts = true;
        }

        // Destroy the placeholder object if it exists and handle any exceptions
        try
        {
            if (placeholder != null)
            {
                Destroy(placeholder);
            }
        }
        catch (System.Exception e)
        {
            Debug.LogError("Error while destroying placeholder: " + e.Message);
        }
    }
    public static Draggable GetDraggingObject()
    {
        return dragging;
    }
    public void ReturnToParent()
    {
        transform.SetParent(parentToReturnTo);
        transform.localPosition = Vector3.zero; // Reset local position
    }


}
