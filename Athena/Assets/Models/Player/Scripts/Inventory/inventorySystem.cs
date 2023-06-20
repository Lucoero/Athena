using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class inventorySystem : ScriptableObject
{
    /* inventorySystem
	Nuestro inventario ser� (de momento) dos arrays de 10.
    El primero ser� itemData, para almacenar la informaci�n de los objetos
    El segundo guardar� la cantidad que tenemos de cada objeto.  
    Las primeras 5 posiciones ser�n la hotbar.
    Para guardar la informaci�n serializaremos el inventario.

    Habr� funciones para:
        1. Cambiar la posici�n de dos objetos
        2. 
    */

    // VARIABLES
    public int maxSize = 10;
    public List<ItemData> itemList = new List<ItemData>(10); // De momento no tenemos en cuenta la cantidad de cada objeto


}
