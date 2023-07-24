using System;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;
using UnityEngine.EventSystems;
public class itemClicked : MonoBehaviour
{
    /* itemClicked
     * Cuando se pulsa el boton, recoge la posicion del boton por su nombre
     * para enviar la informacion a itemSystem y a showHotbar
    */

    // VARIABLES
    public Button thisButton;
    public inventorySystem inventory;

    int newPosition; // Empezando desde el 0


    // FUNCIONES
    public void OnClick()
    {
        newPosition = Convert.ToInt32(EventSystem.current.currentSelectedGameObject.name);
        if (inventory.CheckValidSIP(newPosition)) // Actualizo el item seleccionado
        {
            thisButton.Select(); // Hago que brille.
        } 
    }
}
