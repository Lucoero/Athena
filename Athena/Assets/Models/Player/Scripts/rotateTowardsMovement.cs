using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class rotateTowardsMovement : MonoBehaviour
{
    /* COMENTARIO PARA DESCRBIR EL SCRIPT
	
    */

    // VARIABLES
    public PlayerInputClass Controls;
    public InputAction move;
	

    // FUNCIONES
    void OnEnable()
    {
        move = Controls.Player.Move;
        move.Enable();
    }
    void OnDisable()
    {
        move.Disable();
    }

    void Update() // Update is called once per frame
    {
        // Si la flashlight no está equipada, obten la direccion y rota

        
    }
}
