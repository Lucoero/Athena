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
        // Variables
        GameObject sprite_A = eventData.pointerDrag; // Sprite que estamos draggeando
        Transform spriteB = transform.GetChild(0); // Sprite en el slot B.
        draggableItem item_A = sprite_A.GetComponent<draggableItem>(); // Llamo al transform del script draggableItem relacionado con el objeto
        Transform slot_A = item_A.papaPrimigenio; // Viejo slot de A
        // Transform es slot_B
        if (inventory.ChangeOrder(Convert.ToInt32(transform.name), Convert.ToInt32(slot_A.name))) // Marcar cambios en el inventario
        {
            // Cambiar la posicion item A
            item_A.papaPrimigenio = transform; // Le cambio el padre para que, al dejar de draggear, snapee hacia el.
            // Cambiar la posicion item B
            spriteB.SetParent(slot_A);
            inventory.selectedItemPos = Convert.ToInt32(transform.name); // Cambio el selectedItemPos para que el jugador no se pierda.
            return;
        }   
    }
}
