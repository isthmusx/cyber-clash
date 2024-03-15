using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SortingLayer : MonoBehaviour
{
    public string sortingLayerName = "Foreground";
    public int sortingOrder = 10;

    void Start()
    {
        Renderer renderer = GetComponent<Renderer>();
        renderer.sortingLayerName = sortingLayerName;
        renderer.sortingOrder = sortingOrder;
    }
}
