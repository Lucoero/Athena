using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class playerInteract : MonoBehaviour
{
    /* playerInteract
     * Ofrece los eventos relacionados con el click derecho y el click izquierdo del raton
    */

    // VARIABLES


    // FUNCIONES
    public void OnRightClick(InputAction.CallbackContext context)
    {
        Debug.Log("He usado el click derecho");
    }
    public void OnLeftClick(InputAction.CallbackContext context)
    {
        // POR HACER: Incluir un rango efectivo de uso
        Debug.Log("He usado el click izquierdo");
    }
}
