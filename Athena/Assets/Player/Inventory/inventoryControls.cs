using System;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Experimental.Rendering;
using UnityEngine.InputSystem;
using UnityEngine.Rendering.Universal;

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
    public showInventory showInventory;
    public float dropDistance;
    public GameObject InventoryUI;

    bool inventoryIsOpen = true;
    string objectFoundName;
    // FUNCIONES
    private void Start()
    {
        InventoryUI.SetActive(false); // Empiezo con el inventario desactivado 
    }
    public void ActivateInventory(InputAction.CallbackContext context) // 1. Con la I
    {
        if (context.performed)
        {
            InventoryUI.SetActive(inventoryIsOpen); // Activo o desactivo
            inventoryIsOpen = !inventoryIsOpen; // Cambio el estado del inventario
            return;
        }
    }
    public void GetItem(InputAction.CallbackContext context) //2. Con la E
    {
        if (context.performed) // Para que no se repita en release
        {
            Ray rayCamera_Mouse = Camera.main.ScreenPointToRay(Mouse.current.position.ReadValue());
            
            if (Physics.Raycast(rayCamera_Mouse, out RaycastHit raycastHit) && raycastHit.collider.gameObject.tag == "Item") 
            {
                // Creamos el vector que une al jugador y al item (para comparaciones)
                Vector3 player_Item = raycastHit.point - player.position;
                // Ahora comprobamos que:

                // 1. No este demasiado lejos
                if (Vector3.Magnitude(player_Item) > pickupDistance)
                {
                    Debug.Log($"Estan muy lejos: {Vector3.Magnitude(player_Item)}");
                    return;
                }

                // 2. No haya objetos entre medias
                if (Physics.Raycast(player.position, player_Item, out RaycastHit rayhit) && rayhit.collider.gameObject.tag == "Obstacle")
                {
                    Debug.Log($"Esta {rayhit.collider.gameObject.name} entre medias");
                    return;
                }

                objectFoundName = raycastHit.collider.gameObject.name;
                // Recogo la cantidad del objeto
                int quantity = 1; // Por defecto pienso que va a ser 1
                int ncifras = 0; // Por defecto pienso que me lo indica con 0 numero de cifras en el nombre
                try
                {
                    quantity = Convert.ToInt32(objectFoundName.Remove(0, objectFoundName.Length - 2)); // Pienso que van a ser 2 cifras
                    ncifras = 2;
                }
                catch 
                {
                    try
                    {
                        quantity = Convert.ToInt32(objectFoundName.Remove(0, objectFoundName.Length - 1)); // Pienso que va ser 1 cifra
                        ncifras = 1;
                    }
                    catch
                    {
                     // No está indicado y, por ende, es solo 1.
                    }
                }
                if (objectFoundName.Contains("(Clone)")) { objectFoundName = objectFoundName.Remove(objectFoundName.Length - 7 - ncifras); } //Buscaré el original en vez de el clon.
                // Debug.Log($"Estoy seleccionando {objectFoundName}");
                // Lo intento coger. Si he podido, lo elimino de la escena. Si no, lo dejo ahi.
                if (inventory.GetObject(objectFoundName, quantity))
                {
                    showInventory.UpdateInventorySprites(); // Actualizo la hotbar
                    Destroy(raycastHit.collider.gameObject);
                    return;
                }
                Debug.Log($"Error en la recogida, no reconozco {objectFoundName} como item");
                return;
            }
            return;
        } 
        
    }
    public void DropObject(InputAction.CallbackContext context) //3. Con la Q
    {
        if (context.performed) 
        {
            if (inventory.DropObject(inventory.selectedItemPos, player.position + player.forward * dropDistance)) 
            {
                showInventory.UpdateInventorySprites(); // Si ha funcionado, actualizo los sprites
                return;
            }
        } 
    }
}
