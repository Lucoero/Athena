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
    public float rotationSpeed = 1;
    public Rigidbody rb;
    public PlayerInputClass playerControls;
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
    void Update() // Update is called once per frame
    {
        // FORMA 1: Al moverse el ratón se rota el objeto
        // Vector2 orientation = look.ReadValue<Vector2>() * rotationSpeed;
        // rb.transform.Rotate(0f, orientation.x, 0f);
        // Forma 2: El objeto apunta en la dirección del ratón
        Vector2 mousePosition = Mouse.current.position.ReadValue() * rotationSpeed;
        rb.rotation = Quaternion.Euler(0f,mousePosition.x, 0f);
    }
}
