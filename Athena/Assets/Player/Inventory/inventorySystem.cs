using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using UnityEditor;
using UnityEngine;
using UnityEngine.InputSystem;
[CreateAssetMenu(menuName = "Assets/InventorySystem/Inventory")]
[Serializable] // Esto hace que no se borre el inventario.
public class inventorySystem : ScriptableObject
{
    /* inventorySystem
	Nuestro inventario será (de momento) dos arrays de 10.
    El primero será itemData, para almacenar la información de los objetos
    El segundo guardará la cantidad que tenemos de cada objeto.  
    Las primeras 5 posiciones serán la hotbar.
    Para guardar la información serializaremos el inventario.
    Para compartir la información entre scripts usaremos un ScriptableObject
    Habrá funciones para:
        1. Recoger objetos || DONE
        2. Cambiar la posición de dos objetos || DONE
        3. Tirar objetos || 
    */
    // VARIABLES
    public int maxSize = 10; // Empezando a contar desde el 1 
    public int maxStack = 64;
    public ItemData[] itemList = new ItemData[10]; // De momento no tenemos en cuenta la cantidad de cada objeto
    public int[] itemCount = new int[10];
    public int selectedItemPos = 0; // El item seleccionado al principio es el de la pos 0.
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
    public bool GetObject(string objectFoundName)  // Cojo GameObject porque es lo maximo que me permite los raycasts
    {
        for (int i = 0; i < maxSize; i++)
        {
            if (itemList[i] == null) // Busco espacio en el inventario
            {
                // Busco un itemData que tenga este objeto asociado
                string[] assetsPropuestos = AssetDatabase.FindAssets(objectFoundName, new string[] { "Assets/ItemSystem/ItemAssets" });
                if (assetsPropuestos.Count() == 0)
                {
                    Debug.Log($"No hemos encontrado ningun asset con nombre {objectFoundName}");
                    return false;
                }
                ItemData newItem = (ItemData)AssetDatabase.LoadAssetAtPath(AssetDatabase.GUIDToAssetPath(assetsPropuestos[0]), typeof(ItemData)); // Lo cojo usando el GUID
                // Lo meto en las cajas
                itemList[i] = newItem;
                itemCount[i] = 1;
                return true; // Avisamos de que se ha conseguido para que la funcion que ha llamado siga a lo suyo
            }
            else if (itemList[i].name == objectFoundName) // Hemos encontrado el mismo objeto --> Lo sumo
            {
                if (itemCount[i] >= maxStack)
                {
                    Debug.Log($"Tengo {maxStack} o mas de {maxStack} de {itemList[i]} en la posición {i} del inventario");
                    // Sigo itinerando...
                }
                else
                {
                    itemCount[i] = itemCount[i] + 1;
                    return true;
                }
                
            }
        }
        Debug.Log("El inventario esta lleno");
        return false; // Si no se puede coger, lo dejamos ahi y avisamos del fallo
    }
    public bool DropObject()
    {
        if (itemList[selectedItemPos] != null)
        {
            Instantiate(itemList[selectedItemPos]); // Lo dejamos en el suelo
            itemList[selectedItemPos] = null; // Lo eliminamos del inventario
            return true;
        }
        Debug.Log($"No se ha podido tirar el objeto {itemList[selectedItemPos].itemName}");
        return false;
    }
}
