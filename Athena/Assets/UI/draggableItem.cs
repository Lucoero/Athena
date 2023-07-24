using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;

public class draggableItem : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    /* DraggableItem
    * Le da la propiedad al item al que se le anexione de poder
    * ser arrastrado para colocarlo en otras celdas    
    */
    public Image itemInsideSlot;
    public GameObject Canvas;
    public showInventory showInventory;
    [HideInInspector] public Transform papaPrimigenio; // Para que el objeto al draggear se vea por delante de los botones
    public void OnBeginDrag(PointerEventData eventData)
    {
        papaPrimigenio = transform.parent; // Cojo el parent del item (su ubicacion en la jerarquia) 
        transform.SetParent(transform.root); // Lo cambio temporalmente por el de mayor capacidad
        transform.SetAsLastSibling(); // Le coloca entre los hijos el mas cercano a la pantalla
        itemInsideSlot.raycastTarget = false; // Para que no afecte al raycast de SlotSystem
    }

    public void OnDrag(PointerEventData eventData)
    {
        Vector3 mousePos = new Vector3 (Mouse.current.position.ReadValue().x, Mouse.current.position.ReadValue().y,Canvas.transform.position.y);
        mousePos = Camera.main.ScreenToWorldPoint(new Vector3(mousePos.x, mousePos.y, Camera.main.transform.position.y-Canvas.transform.position.y));
        transform.position = mousePos;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        transform.SetParent(papaPrimigenio); // Lo devuelvo a su ubicacion en la jerarquia
        itemInsideSlot.raycastTarget = true; // Para que le vuelvan a afectar los Raycasts
        showInventory.UpdateInventorySprites(); // Updateo el inventario
    }

}
