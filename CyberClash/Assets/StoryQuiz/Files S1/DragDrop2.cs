using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class DragDrop2 : MonoBehaviour, IPointerDownHandler, IBeginDragHandler, IEndDragHandler, IDragHandler
{
    private RectTransform rectTransform;
    private Canvas canvas;
    private CanvasGroup canvasGroup;
    public Vector2 originalPosition { get; private set; }

    private void Awake()
    {
        rectTransform = GetComponent<RectTransform>();
        canvas = GetComponentInParent<Canvas>();
        canvasGroup = GetComponent<CanvasGroup>();
        originalPosition = rectTransform.anchoredPosition;
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        Debug.Log("Pointer Down");
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        Debug.Log("Begin Drag");
        canvasGroup.alpha = 0.6f;
        canvasGroup.blocksRaycasts = false;  // Allow drag
    }

    public void OnDrag(PointerEventData eventData)
    {
        Debug.Log("Dragging");
        rectTransform.anchoredPosition += eventData.delta / canvas.scaleFactor; // Move block with drag
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        canvasGroup.alpha = 1f;
        canvasGroup.blocksRaycasts = true;  // Enable raycast again after drag

        // Check if dropped on a valid slot
        if (eventData.pointerCurrentRaycast.isValid)
        {
            var slotObject = eventData.pointerCurrentRaycast.gameObject.GetComponent<AnswerSlot>();
            if (slotObject != null)
            {
                // Snap to the answer slot
                RectTransform slotRect = slotObject.GetComponent<RectTransform>();
                rectTransform.anchoredPosition = slotRect.anchoredPosition; // Snap to the slot's position
                Debug.Log("Snapped to slot at: " + slotRect.anchoredPosition);
                return;  // Exit after snapping
            }
        }

        // If not dropped on a valid slot, return to original position
        rectTransform.anchoredPosition = originalPosition;
        Debug.Log("Returned to original position");
    }

}
