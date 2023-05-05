using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class rotateTowardsMovement : MonoBehaviour
{
    /* COMENTARIO PARA DESCRBIR EL SCRIPT
	
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
        // Si la flashlight no est� equipada, obten la direccion y rota guay
        Vector2 movDirection = move.ReadValue<Vector2>(); // Calculo 
        float angle = Mathf.Atan2(movDirection.x,movDirection.y)*Mathf.Rad2Deg;
        Quaternion Rotation = Quaternion.Euler(new Vector3(0f, -angle, 0f));
        float velocity = rb.velocity.y;
        float smoothAngle = Mathf.SmoothDampAngle(transform.eulerAngles.y, angle,ref velocity,0.1f);
        rb.rotation = Quaternion.Euler(new Vector3(0f,smoothAngle,0f));


    }
}
