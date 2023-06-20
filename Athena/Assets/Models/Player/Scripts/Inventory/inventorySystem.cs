using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class inventorySystem : ScriptableObject
{
    /* inventorySystem
	Nuestro inventario será (de momento) dos arrays de 10.
    El primero será itemData, para almacenar la información de los objetos
    El segundo guardará la cantidad que tenemos de cada objeto.  
    Las primeras 5 posiciones serán la hotbar.
    Para guardar la información serializaremos el inventario.

    Habrá funciones para:
        1. Cambiar la posición de dos objetos
        2. 
    */

    // VARIABLES
    public int maxSize = 10;
    public List<ItemData> itemList = new List<ItemData>(10); // De momento no tenemos en cuenta la cantidad de cada objeto


}
