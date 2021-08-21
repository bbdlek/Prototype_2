using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Inventory : MonoBehaviour
{
    public void OnBeginDrag(PointerEventData eventData)
    {
        Debug.Log("Start");
        //throw new System.NotImplementedException();
    }

    public void OnDrag(PointerEventData eventData)
    {
        Debug.Log("Draging");
        //throw new System.NotImplementedException();
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        Debug.Log("EndDrag");
        // throw new System.NotImplementedException();
    }
}
