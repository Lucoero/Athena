using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;

public class inventoryControls : MonoBehaviour
{
    /* Inventory Controls
     * Actua como intermediario entre el inventario y el jugador.
     * Permite el uso de las siguientes acciones 
     * 1. Abrir y cerrar el inventario
     * 2. Recoger objetos
     * 3. Tirar objetos
     * 4. Mover objetos (intercambiar posicion)
    */

    // VARIABLES
    public Transform player;
    public float pickupDistance;
    public inventorySystem inventory;

    bool inventoryIsOpen = false;
    string objectFoundName;
    // FUNCIONES
    public void ActivateInventory(InputAction.CallbackContext context) // 1. Con la I
    {
        if (inventoryIsOpen)
        {
            // Se cierra el inventario
            inventoryIsOpen = false;
            return;
        }
        // En caso contrario, se abre
        inventoryIsOpen = true;
        return;
    }
    public void GetItem(InputAction.CallbackContext context) //2. Con la E
    {
        if (context.performed){ return; } // Para que no se repita en release
        // Calculo la direccion de la mirada
        Vector3 mousePos = Mouse.current.position.ReadValue();
        Vector3 objectPos = Camera.main.WorldToScreenPoint(player.position);
        Vector3 direccion = new Vector3(mousePos.x - objectPos.x,player.position.y ,mousePos.y - objectPos.y); // Problema de esto: Si player y object estan a distintas alturas bye bye
        // Lanzo Raycast: Compruebo que esta a una distancia maxima, y si hay algo entre medias
        if (Physics.Raycast(player.position, direccion, out RaycastHit raycastHit, pickupDistance))
        {
            objectFoundName = raycastHit.collider.gameObject.name;
            // Debug.Log($"Estoy seleccionando {objectFoundName}");
            // Lo intento coger. Si he podido, lo elimino de la escena. Si no, lo dejo ahi.
            if (inventory.GetObject(objectFoundName))
            {
                Destroy(raycastHit.collider.gameObject);
                return;
            }
            return;
        }
    }
}
