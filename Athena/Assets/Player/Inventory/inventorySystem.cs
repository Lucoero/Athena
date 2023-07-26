using System;
using System.Linq;
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
        3. Tirar objetos || Falta que se conserve la Tag
    */
    // VARIABLES
    public int maxSize; // Empezando a contar desde el 1 
    public int maxStack;

    public ItemData[] itemList = new ItemData[20];
    public int[] itemCount = new int[20];

    public int selectedItemPos;

    // FUNCIONES 
    public bool ChangeOrder(int pos2, int pos1 = 314)
    {
        if (pos1 == 314)
        {
            pos1 = selectedItemPos;
        } // Si no hemos entrado en el if es porque hemos metido un input en pos1
        
        // Primero comprobamos que el cambio se pueda realizar
        if (pos2 > maxSize-1 || pos1 > maxSize-1 || pos2 == pos1)
        {
            Debug.Log(maxSize);
            Debug.Log($"Oye, que me has intentado meter en la posicion del inventario {pos2} y {pos1}");
            return false; // Si no se puede, returnea
        }
        // Muevo los items
        ItemData aux = itemList[pos2]; // Guardo el item de la posicion 2 
        itemList[pos2] = itemList[pos1];
        itemList[pos1] = aux;

        // Muevo tambien las cantidades
        int aux2 = itemCount[pos2];
        itemCount[pos2] = itemCount[pos1];
        itemCount[pos1] = aux2;
        return true;
    }

    public bool GetObject(string objectFoundName, int quantity)  // Cojo el nombre del gameObject encontrado
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
                itemCount[i] = quantity;
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
        // Si no se puede coger, lo dejamos ahi y avisamos
        Debug.Log("El inventario esta lleno");
        return false; 
    }

    public bool DropObject(int pos, Vector3 placementPos) // SIN TERMINAR: Si se quiere volver a recoger se tendria que devolver la misma cantidad que se tiro.
    {
        if (itemList[pos] != null)
        { 
            GameObject item = Instantiate(itemList[pos].model, placementPos, Quaternion.identity); // Lo dejamos en el suelo.
            item.tag = "Item";
            // Le podemos añadir al nombre la cantidad que habia del item. De esta forma cuando lo recogamos podemos extraerlo
            item.name = item.name + Convert.ToString(itemCount[pos]);
            itemList[pos] = null; // Lo eliminamos del inventario
            itemCount[pos] = 0;
            return true; 
        }
        Debug.Log($"No hay objeto en esa casilla");
        return false;
    }
}
