using System;
using System.Collections;
using System.Collections.Generic;
using Unity.IO.LowLevel.Unsafe;
using UnityEngine;
using UnityEngine.InputSystem;

public class playerMovement: MonoBehaviour
{
    /* Informaci�n del M�todo 3
    Utiliza la misma librer�a que el M�todo 2, pero usando los eventos de acci�n
    de PlayerInput. Esto permite modificar mejor desde Unity y tener que programar menos.

    La programaci�n de esta parte se basa en la creaci�n de eventos llamados "acciones"
    desde el editor de Unity. Para ello basta con a�adir un "PlayerInput" al objeto que queramos
    que tenga estas acciones. Con ello crearemos una clase en C# que llamaremos aqu�.
    Yo por mi parte la he llamado PlayerInputClass. 

    Ventajas:
    - Las mismas que el M�todo 2, adem�s de mayor facilidad de edici�n.
    - No hay que tocar la clase de Control que se hace, lo cual facilita el asunto.
    Desventajas:
    - Mismas que el M�todo 2, con tal vez un c�digo un poco m�s complejo.
    */

    public int walkingSpeed = 10;
    public int runningSpeed = 15;
    public Rigidbody rb;

    private int speed;
    private Vector2 xzMove;
    private Vector2 xzSpeed;
    

    // A continuaci�n se crean eventos necesarios para la libreria Input
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
        // xzSpeed Los almacena como x e y, pero nuestra y ser� una z. 
        rb.velocity = new Vector3(xzSpeed.x, rb.velocity.y, xzSpeed.y);
    }
}
