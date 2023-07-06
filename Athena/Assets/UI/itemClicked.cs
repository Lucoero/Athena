using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;
public class itemClicked : MonoBehaviour
{
    /* itemClicked
     * Cuando se pulsa el boton, recoge la posicion del boton por 
     * el nombre del mismo y le envia la informacion a itemSystem
     * y a showHotbar
    */

    // VARIABLES
    public Button thisButton;
    public int inventoryPosition; // Empezando desde el 0
    public inventorySystem inventory;


    // FUNCIONES
    public void OnClick()
    {
        inventory.selectedItemPos = inventoryPosition; // Actualizo el item seleccionado
        thisButton.Select(); // Hago que brille. POR ALGUNA RAZON MOVER AL PERSONAJE HACE QUE SE MUEVA LA SELECCION??? 
    }
}
