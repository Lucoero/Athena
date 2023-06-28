using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class TESTItemData : MonoBehaviour
{
    /* COMENTARIO PARA DESCRBIR EL SCRIPT
	
    */

    // VARIABLES

    public ItemData ejemplo;
    // FUNCIONES
    void Start() 
    {
        Instantiate(ejemplo.model);
    }
}
