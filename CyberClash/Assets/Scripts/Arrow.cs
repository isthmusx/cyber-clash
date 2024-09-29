using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arrow : MonoBehaviour
{
    public GameObject[] points;

    public GameObject point;
    public GameObject arrow;

    public int numberOfPoints;
    public static Vector2 startPoint;

    public float distance;

    public Vector2 direction;
    public float force;

    public static bool _Show;
    public static bool _Hide;

    // Start is called before the first frame update
    void Start()
    {
        points = new GameObject[numberOfPoints];

        for (int i = 0; i < numberOfPoints; i++)
        {
            if (i != numberOfPoints - 1)
            {
                points[i] = Instantiate(point, transform.position, Quaternion.identity);
                points[i].SetActive(false);
            }
            else
            {
                points[i] = Instantiate(arrow, transform.position, Quaternion.identity);
                points[i].SetActive(false);
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
            direction = touch.position;
            if (touch.phase == TouchPhase.Ended)
            {
                _Hide = true;
            }
        }
        
        distance = Vector3.Distance(startPoint, direction);
        force = distance / 10;

        for (int i = 0; i < numberOfPoints; i++)
        {
            Vector2 pointPosition = Vector2.Lerp(startPoint, direction, i * 0.1f);

            if (!float.IsInfinity(pointPosition.x) && !float.IsInfinity(pointPosition.y))
            {
                points[i].transform.position = new Vector3(pointPosition.x, pointPosition.y, 0);
            }

            if (_Show == true)
            {
                Show();
                _Show = false;
            }
            else if (_Hide == true)
            {
                Hide();
                _Hide = false;
            }
        }
    }

    public void Show()
    {
        for (int i = 0; i < numberOfPoints; i++)
        {
            points[i].SetActive(true);
        }
    }

    public void Hide()
    {
        for (int i = 0; i < numberOfPoints; i++)
        {
            points[i].SetActive(false);
        }
    }
}
