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
    public showHotbar showHotbar;
    public float dropDistance;

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
        if (context.performed) // Para que no se repita en release
        {
            Ray rayCamera_Mouse = Camera.main.ScreenPointToRay(Mouse.current.position.ReadValue());
            
            if (Physics.Raycast(rayCamera_Mouse, out RaycastHit raycastHit) && raycastHit.collider.gameObject.tag == "Item") 
            {
                // Creamos el vector que une al jugador y al item (para comparaciones)
                Vector3 player_Item = raycastHit.point - player.position;
                // Ahora comprobamos que:

                //1. No este demasiado lejos
                if (Vector3.Magnitude(player_Item) > pickupDistance)
                {
                    Debug.Log($"Estan muy lejos: {Vector3.Magnitude(player_Item)}");
                    return;
                }

                //2. No haya objetos entre medias
                if (Physics.Raycast(player.position, player_Item, out RaycastHit rayhit) && rayhit.collider.gameObject.tag == "Obstacle")
                {
                    Debug.Log($"Esta {rayhit.collider.gameObject.name} entre medias");
                    return;
                }

                objectFoundName = raycastHit.collider.gameObject.name;
                if (objectFoundName.Contains("(Clone)")) { objectFoundName = objectFoundName.Remove(objectFoundName.Length - 7); } //Buscaré el original en vez de el clon.
                // Debug.Log($"Estoy seleccionando {objectFoundName}");
                // Lo intento coger. Si he podido, lo elimino de la escena. Si no, lo dejo ahi.
                if (inventory.GetObject(objectFoundName))
                {
                    showHotbar.UpdateHotbar(); // Actualizo la hotbar
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
                showHotbar.UpdateHotbar(); // Si ha funcionado, actualizo los sprites
                return;
            }
        } 
    }
}
