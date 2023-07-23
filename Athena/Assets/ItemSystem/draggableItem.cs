using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;

public class draggableItem : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    /* DraggableItem
    * Le da la propiedad al item al que se le anexione de poder
    * ser arrastrado para colocarlo en otras celdas    
    */
    public GameObject Canvas;
    public void OnBeginDrag(PointerEventData eventData)
    {
        Debug.Log("Empiezo el drag");
    }

    public void OnDrag(PointerEventData eventData)
    {
        Vector2 mouseScreenPos = Mouse.current.position.ReadValue();
        transform.position = Camera.main.ScreenToWorldPoint(new Vector3 (mouseScreenPos.x,mouseScreenPos.y ,Canvas.transform.position.y));
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        Debug.Log("Acabo el drag");
    }

}
