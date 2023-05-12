using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class playerInteract : MonoBehaviour
{
    /* COMENTARIO PARA DESCRBIR EL SCRIPT
	
    */

    // VARIABLES
    public PlayerInputClass playerControls;
    public InputAction interactuar;


    // FUNCIONES
    private void Interactuo(InputAction.CallbackContext context) // La variable es del tipo que hace Input al funcionar.
                                                                 // También se puede hacer con OnInteractuar() (Send messages behaviour)
    {
        // POR HACER: Hay que marcar una distancia límite de interactuación.
        Debug.Log("He interactuao Padre"); // Anuncio en Unity que, ciertamente, he funcionado
    }

    void Awake() 
    {
        playerControls = new PlayerInputClass();
    }
    public void OnEnable()
    {
        interactuar = playerControls.Player.Interactuar;
        interactuar.Enable();
        interactuar.performed += Interactuo; //  Relaciono el control interactuar con la función que ejecuta la interactuación.
    }

    public void OnDisable()
    {
        interactuar.Disable();
    }
}
