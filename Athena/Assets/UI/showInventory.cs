using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;
using UnityEngine.UI;

public class showInventory : MonoBehaviour
{
    /* showHotbar
     * Muestra los botones en la hotbar
    */

    // VARIABLES
    public Button[] buttons = new Button[10];
    public inventorySystem inventory;
    public Sprite defaultSprite;

    int i = 0; // Contador para el inventario
    // FUNCIONES
    public void Start() // Inicializa los sprites en los botones
    {
        foreach (Button button in buttons) 
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
    public void UpdateInventory() // Actualiza los sprites en los botones
    {
        foreach (Button button in buttons)
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
    }
}
