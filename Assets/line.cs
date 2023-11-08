using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class line : MonoBehaviour
{
    public List<GameObject> linesList;
    public LineRenderer lineCreator;
    Vector3 currentPosition, startMousePosition;
    // Start is called before the first frame update
    void Start()
    {
        lineCreator=GetComponent<LineRenderer>();
        lineCreator.positionCount=2;
        /*gameObject.SetActive(false);*/
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            /*gameObject.SetActive(true);*/
            startMousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            print("down");
        }

        if (Input.GetMouseButton(0))
        {

            currentPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            print("yo");
            lineCreator.SetPosition(0, new Vector3(startMousePosition.x, startMousePosition.y, 0f));
            lineCreator.SetPosition(lineCreator.positionCount - 1, new Vector3(currentPosition.x, currentPosition.y, 0f));
        }
    }
}
