using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollingBackground : MonoBehaviour
{
    public float scrollSpeed = 2.0f;
    public float scrollDistance = 5.0f;

    private Vector2 startPos;
    private float direction = 1.0f;

    void Start()
    {
        startPos = transform.position;
    }

    void Update()
    {
        float newPos = Mathf.PingPong(Time.time * scrollSpeed, scrollDistance) - (scrollDistance / 2);
        transform.position = startPos + Vector2.right * newPos * direction;
    }
}