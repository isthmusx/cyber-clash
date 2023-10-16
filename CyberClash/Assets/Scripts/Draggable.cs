using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Draggable : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{

    public Transform parentToReturnTo = null;
    public Transform placeholderParent = null;

    GameObject placeholder = null;

    public void OnBeginDrag(PointerEventData eventData)
    {

        //Debug.Log("OnBeginDrag");

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

    public void OnDrag(PointerEventData eventData)
    {
        //Debug.Log("OnDrag");
        this.transform.position = eventData.position;

        if(placeholder.transform.parent != placeholderParent)
        {
            placeholder.transform.SetParent(placeholderParent);
        }

        int newSiblingIndex = placeholderParent.childCount;

        for (int i=0; i < placeholderParent.childCount; i++)
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

    public void OnEndDrag(PointerEventData eventData)
    {
        //Debug.Log("OnEndnDrag");

        this.transform.SetParent(parentToReturnTo);
        this.transform.SetSiblingIndex(placeholder.transform.GetSiblingIndex());
        GetComponent<CanvasGroup>().blocksRaycasts = true;

        Destroy(placeholder);

    }

}
