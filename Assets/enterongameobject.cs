using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class enterongameobject : MonoBehaviour, IPointerEnterHandler
{
    public line lineObj;
    public void OnPointerEnter(PointerEventData eventData)
    {
        lineObj.lineCreator.positionCount++;
        lineObj.lineCreator.SetPosition(lineObj.lineCreator.positionCount-2,gameObject.transform.position);
    }


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


}
