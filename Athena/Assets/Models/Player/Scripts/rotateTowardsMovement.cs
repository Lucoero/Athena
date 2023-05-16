using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class rotateTowardsMovement : MonoBehaviour
{
    /* rotateTowardsMovement
     * Dado un objeto que se mueve con los contrles de InputSystem,
     * este rotará para mantener su "frente" en dirección al movimiento
    */

    // VARIABLES
    public Rigidbody rb;
    public PlayerInputClass Controls;
    public InputAction move;


    // FUNCIONES

    public void Awake()
    {
        Controls = new PlayerInputClass();
    }
    void OnEnable()
    {
        move = Controls.Player.Move;
        move.Enable();
    }
    void OnDisable()
    {
        move.Disable();
    }

    void FixedUpdate() // Update is called once per frame
    {
        // Si la flashlight no está equipada, obten la direccion y rota guay
        Vector2 movDirection = move.ReadValue<Vector2>(); // Calculo 
        if (movDirection.x != 0 || movDirection.y != 0 ) // Cuyo caso hay input.
        {
            float angle = Mathf.Atan2(movDirection.x, movDirection.y) * Mathf.Rad2Deg;
            float velocity = rb.velocity.y;
            float smoothAngle = Mathf.SmoothDampAngle(transform.eulerAngles.y, angle, ref velocity, 0.05f);
            rb.rotation = Quaternion.Euler(new Vector3(0f, smoothAngle, 0f));
        }
    }
}
