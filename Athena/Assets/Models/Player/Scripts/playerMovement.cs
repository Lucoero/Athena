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
    public int speed;
    int counter = 0;
    public Vector2 xzSpeed;
   
    public Rigidbody rb;
    public PlayerInputClass playerControls; // De aquí obtendré los controles
    private InputAction move; // Para configurar el movimiento
    private InputAction run;
    public void Awake()
    {
        playerControls = new PlayerInputClass(); // Instancio para iniciar el script.
    }
    // A continuación se crean eventos necesarios para la libreria Input
    public void OnEnable()
    {
        move = playerControls.Player.Move; // Accedo a subapartado de Player en la acción, y luego concretamente a su movimiento.
        move.Enable(); // Activo la entrada de Input

        run = playerControls.Player.Run;
        run.Enable();
        run.performed += WannaRun;
    }
    public void OnDisable()
    {
        move.Disable(); // No me hace falta redefinirlo pues ya lo he hecho en OnEnable.
        run.Disable();
    }
    public void WannaRun(InputAction.CallbackContext context) // Captura si se pulsa o despulsa el shift
    {
        counter += 1;
        if (counter%2 != 0) // Se pulsa un número impar --> Corre
        {
            speed = runningSpeed;
        }
        else // Se pulsa un número par --> Anda y resetea el counter
        {
            speed = walkingSpeed;
            counter = 0;
        }
    }
    // Durante el juego
    void FixedUpdate()
    {
        xzSpeed = move.ReadValue<Vector2>() * speed;
        // xzSpeed Los almacena como x e y, pero nuestra y será una z. 
        rb.velocity = new Vector3(xzSpeed.x, rb.velocity.y, xzSpeed.y);
    }
}
