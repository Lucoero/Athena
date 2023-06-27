using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

[CreateAssetMenu (menuName = "Assets/InventorySystem/ItemData")]
public class ItemData : ScriptableObject
{
    /* itemData
     * Genera los assets de los items
    */
    
    // VARIABLES
    public string itemName;

    [field:TextArea] // Solo para que el editor de unity cambie el tipo de recuadro de escritura
	public string description;

    public GameObject model; // El modelo es el que contendrá las propiedades del objeto (es la instancia)
    public Sprite icon;

}
