using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.InputSystem;
[CreateAssetMenu(menuName = "Assets/InventorySystem/Inventory")]
[Serializable]
public class inventorySystem : ScriptableObject
{
    /* inventorySystem
	Nuestro inventario ser� (de momento) dos arrays de 10.
    El primero ser� itemData, para almacenar la informaci�n de los objetos
    El segundo guardar� la cantidad que tenemos de cada objeto.  
    Las primeras 5 posiciones ser�n la hotbar.
    Para guardar la informaci�n serializaremos el inventario.
    Para compartir la informaci�n entre scripts usaremos un ScriptableObject
    Habr� funciones para:
        1. Recoger objetos || DONE
        2. Cambiar la posici�n de dos objetos || DONE
        3. Tirar objetos || 
    */
    // VARIABLES
    public int maxSize = 10; // Empezando a contar desde el 1 
    public ItemData[] itemList = new ItemData[10]; // De momento no tenemos en cuenta la cantidad de cada objeto
    public int[] itemCount = new int[10];
    public void ChangeOrder(int pos1, int pos2)
    {
        // Primero comprobamos que el cambio se pueda realizar
        if (pos1 > maxSize-1 || pos2 > maxSize-1)
        {
            return; // Si no se puede, returnea
        }
        ItemData aux = itemList[pos2]; // Guardo el item de la posicion 2 
        itemList[pos2] = itemList[pos1];
        itemList[pos1] = aux;
        return;
    }
    public bool GetObject(ItemData newItem)
    {
        for (int i = 0; i < maxSize; i++)
        {
            if (itemList[i] == null)
            {
                itemList[i] = newItem;
                return true; // Avisamos de que se ha conseguido
            }
        }
        return false; // Si no se puede coger, lo dejamos ahi y avisamos del fallo
    }
    public bool DropObject(int pos)
    {
        if (itemList[pos] != null)
        {
            Instantiate(itemList[pos]); // Lo dejamos en el suelo
            itemList[pos] = null; // Lo eliminamos del inventario
            return true;
        }
        return false;
    }
}
