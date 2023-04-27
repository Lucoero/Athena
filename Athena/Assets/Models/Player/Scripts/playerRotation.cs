using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class playerRotation : MonoBehaviour
{
    /* COMENTARIO PARA DESCRBIR EL SCRIPT
	Permite rotar al personaje respecto al eje y.
    Esto, en un futuro, se encargará de mover la luz de la linterna.
    El siguiente link puede ayudar:
    https://gamedevbeginner.com/input-in-unity-made-easy-complete-guide-to-the-new-system/#input_system
    */

    // VARIABLES
    int rotationSpeed = 5;
    Rigidbody rb;
    PlayerInputClass playerControls;
    private InputAction look;

    // FUNCIONES
    public void Awake()
    {
        playerControls = new PlayerInputClass();
    }
    private void OnEnable()
    {
        look = playerControls.Player.Look;
        look.Enable();
    }

    private void OnDisable()
    {
        look.Disable();
    }
    void FixedUpdate() // Update is called once per frame
    {
        Vector3 orientation = look.ReadValue<Vector3>() * rotationSpeed;
        rb.MoveRotation(Quaternion.Euler(orientation));
    }
}
