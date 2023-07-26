using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;
using UnityEngine.UI;

public class showInventory : MonoBehaviour
{
    /* showInventory
     * Muestra los sprites de los objetos en los botones
    */

    // VARIABLES
    public Button[] buttons = new Button[20];
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
                button.transform.GetChild(0).GetComponent<Image>().sprite = inventory.itemList[i].icon;
                i++;
            }
            catch
            {
                button.transform.GetChild(0).GetComponent<Image>().sprite = defaultSprite;
                i++;
            }
        }
        i = 0; // Reseteo el contador
        buttons[inventory.selectedItemPos].Select(); // Hago que el item seleccionado brille
    }
    public void UpdateInventorySprites() // Actualiza los sprites en los botones
    {
        foreach (Button button in buttons)
        {
            try
            {
                button.transform.GetChild(0).GetComponent<Image>().sprite = inventory.itemList[i].icon;
                i++;
            }
            catch
            {
                button.transform.GetChild(0).GetComponent<Image>().sprite = defaultSprite;
                i++;
            }
        }
        i = 0; // Reseteo el contador
    }
}
