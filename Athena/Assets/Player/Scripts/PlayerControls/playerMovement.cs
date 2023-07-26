using System;
using System.Collections;
using System.Collections.Generic;
using Unity.IO.LowLevel.Unsafe;
using UnityEngine;
using UnityEngine.InputSystem;

public class playerMovement: MonoBehaviour
{
    /* Información del Método 3
    Utiliza la misma librería que el Método 2, pero usando los eventos de acción
    de PlayerInput. Esto permite modificar mejor desde Unity y tener que programar menos.

    La programación de esta parte se basa en la creación de eventos llamados "acciones"
    desde el editor de Unity. Para ello basta con añadir un "PlayerInput" al objeto que queramos
    que tenga estas acciones. Con ello crearemos una clase en C# que llamaremos aquí.
    Yo por mi parte la he llamado PlayerInputClass. 

    Ventajas:
    - Las mismas que el Método 2, además de mayor facilidad de edición.
    - No hay que tocar la clase de Control que se hace, lo cual facilita el asunto.
    Desventajas:
    - Mismas que el Método 2, con tal vez un código un poco más complejo.
    */

    public int walkingSpeed = 10;
    public int runningSpeed = 15;
    public Rigidbody rb;

    private int speed;
    private Vector2 xzMove;
    private Vector2 xzSpeed;
    

    // A continuación se crean eventos necesarios para la libreria Input
    public void WannaRun(InputAction.CallbackContext context) // Captura si se pulsa o despulsa el shift (POR TERMINAR: Falta la stamina)
    {
        if (context.phase == InputActionPhase.Performed && speed == walkingSpeed) // Esta andando y llevas un rato pulsando el boton --> Corre. 
        {
            speed = runningSpeed;
        }
        else // Esta corriendo --> Anda
        {
            speed = walkingSpeed;
        }
    }
    public void OnMovement (InputAction.CallbackContext context)
    {
        xzMove = context.ReadValue<Vector2>(); // Ahora xz solo se actualiza cuando se PULSA un control de movimiento.
    }

    // Durante el juego
    private void Start()
    {
        speed = walkingSpeed;
    }
    void FixedUpdate()
    {
        xzSpeed = xzMove * speed;
        // xzSpeed Los almacena como x e y, pero nuestra y será una z. 
        rb.velocity = new Vector3(xzSpeed.x, rb.velocity.y, xzSpeed.y);
    }
}
