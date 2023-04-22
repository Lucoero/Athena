using System;
using System.Collections;
using System.Collections.Generic;
using Unity.IO.LowLevel.Unsafe;
using UnityEngine;
using UnityEngine.InputSystem;

public class Mov3 : MonoBehaviour
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

    public int speed = 10;
    public Rigidbody rb;
    public PlayerInputClass playerControls; // De aquí obtendré los controles
    private InputAction move; // Para configurar el movimiento
    private InputAction interactuar; // Para configuar el interactuar
    private void Interactuo(InputAction.CallbackContext context) // La variable es del tipo que hace Input al funcionar
    {
        Debug.Log("He interactuao Padre"); // Anuncio en Unity que, ciertamente, he funcionado
    }
    public void Awake()
    {
        playerControls = new PlayerInputClass(); // Instancio para iniciar el script.
    }
    void Start()
    {
        Debug.Log("Goobert");
    }

    // A continuación se crean eventos necesarios para la libreria Input
    public void OnEnable()
    {
        // Para el movimiento
        move = playerControls.Player.Move; // Accedo a subapartado de Player en la acción, y luego concretamente a su movimiento.
        move.Enable(); // Activo la entrada de Input

        // Para interactuar
        interactuar = playerControls.Player.Interactuar; // Igual que con Player.Move de arriba
        interactuar.Enable();
        interactuar.performed += Interactuo; //  Relaciono el control interactuar con la función que ejecuta la interactuación.
    }
    public void OnDisable()
    {
        // Para el movimiento
        move.Disable(); // No me hace falta redefinirlo pues ya lo he hecho en OnEnable.

        // Para interactuar
        interactuar.Disable();
    }
    // Durante el juego
    void FixedUpdate()
    {
        Vector2 xzSpeed = move.ReadValue<Vector2>() * speed; // Los almacena como x e y, pero nuestra y será una z. 
        rb.velocity = new Vector3(xzSpeed.x, rb.velocity.y, xzSpeed.y);
    }
}
