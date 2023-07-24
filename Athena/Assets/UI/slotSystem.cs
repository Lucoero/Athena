using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System;

public class slotSystem : MonoBehaviour, IDropHandler
{
    /* SlotSystem
	Permite el movimiento de objetos entre slots.
    */

    // VARIABLES
    public inventorySystem inventory;


    // FUNCIONES
    public void OnDrop(PointerEventData eventData)
    {
        GameObject itemDropped = eventData.pointerDrag; // Cojo el slot que este justo debajo del ratón
        draggableItem item = itemDropped.GetComponent<draggableItem>(); // Llamo al transform del script draggableItem relacionado con el objeto
        item.papaPrimigenio = transform; // Le cambio el padre para que, al dejar de draggear, snapee hacia el. 
        // POR TERMINAR Falta que modifique la informacion en los arrays del inventario
        inventory.ChangeOrder(Convert.ToInt32(transform.name)); // Cojo el nombre del botón y lo uso como posición para intercambiar en el inventario
    }
}
