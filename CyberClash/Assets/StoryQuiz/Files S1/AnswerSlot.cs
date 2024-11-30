    using UnityEngine;
    using UnityEngine.EventSystems;

    public class AnswerSlot : MonoBehaviour, IDropHandler, IPointerExitHandler
    {
        public GameObject correctAnswer;
        public GameObject CurrentItem { get; private set; }

        public void OnDrop(PointerEventData eventData)
        {
            if (CurrentItem == null && eventData.pointerDrag != null)
            {
                RectTransform draggedRectTransform = eventData.pointerDrag.GetComponent<RectTransform>();
                RectTransform slotRectTransform = GetComponent<RectTransform>();

                draggedRectTransform.anchoredPosition = slotRectTransform.anchoredPosition;
                CurrentItem = eventData.pointerDrag;
            }
        }

        public void OnPointerExit(PointerEventData eventData)
        {
            if (eventData.pointerDrag != null)
            {
                //CurrentItem = null;
            }
        }

        public bool HasCorrectAnswer()
        {
            bool hasCorrectAnswer = CurrentItem != null && CurrentItem == correctAnswer;
            Debug.Log($"CurrentItem: {CurrentItem}, CorrectAnswer: {correctAnswer}, HasCorrectAnswer: {hasCorrectAnswer}");
            return hasCorrectAnswer;
        }

        public void ResetSlot()
        {
            if (CurrentItem != null)
            {
                CurrentItem.GetComponent<RectTransform>().anchoredPosition = CurrentItem.GetComponent<DragAndDrop>().originalPosition; // Reset to original position
                CurrentItem = null; 
            }
        }

        public void RemoveItem()
        {
            CurrentItem = null;
        }
    }
