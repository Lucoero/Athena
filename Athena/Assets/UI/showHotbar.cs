using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;
using UnityEngine.UI;

public class showHotbar : MonoBehaviour
{
    /* showHotbar
     * Muestra los botones en la hotbar
    */

    // VARIABLES
    public UnityEngine.UI.Button[] buttons = new UnityEngine.UI.Button[5];
    public inventorySystem inventory;
    public Sprite defaultSprite;

    int i = 0; // Contador para el inventario
    // FUNCIONES
    public void Start() // Inicializa los sprites en los botones
    {
        foreach (UnityEngine.UI.Button button in buttons) 
        {
            try
            {
                button.image.sprite = inventory.itemList[i].icon; 
                i++;
            }
            catch
            {
                button.image.sprite = defaultSprite; 
                i++;
            }
        }
        i = 0; // Reseteo el contador
        buttons[inventory.selectedItemPos].Select(); // Hago que el item seleccionado brille
    }
    public void displaySprite(int pos) // Actualiza los sprites en los botones
    {
        try
        {
            buttons[pos].image.sprite = inventory.itemList[i].icon;
        }
        catch
        {
            buttons[pos].image.sprite = defaultSprite;
        }
    }
}
