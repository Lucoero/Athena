using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;

public class getItemInfo : MonoBehaviour, IPointerEnterHandler
{
    /* SIN TERMINAR: getItemInfo
     * Permite mostrar en pantalla la información del objeto cuando le da el raycast de la camara.
     * Para ello, este script debe estar incluido en los objetos que queramos que muestren este comportamiento
    */

    // VARIABLES
	
	

    // FUNCIONES
   public void OnPointerEnter(PointerEventData eventData)
    {
        Debug.Log($"He pasado por encima de {this.name}");
    }

}
