using System;
using System.Collections;
using System.Collections.Generic;
using Unity.IO.LowLevel.Unsafe;
using UnityEngine;
using UnityEngine.InputSystem;

public class Mov3 : MonoBehaviour
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

    public int speed = 10;
    public Rigidbody rb;
    public PlayerInputClass playerControls; // De aqu� obtendr� los controles
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

    // A continuaci�n se crean eventos necesarios para la libreria Input
    public void OnEnable()
    {
        // Para el movimiento
        move = playerControls.Player.Move; // Accedo a subapartado de Player en la acci�n, y luego concretamente a su movimiento.
        move.Enable(); // Activo la entrada de Input

        // Para interactuar
        interactuar = playerControls.Player.Interactuar; // Igual que con Player.Move de arriba
        interactuar.Enable();
        interactuar.performed += Interactuo; //  Relaciono el control interactuar con la funci�n que ejecuta la interactuaci�n.
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
        Vector2 xzSpeed = move.ReadValue<Vector2>() * speed; // Los almacena como x e y, pero nuestra y ser� una z. 
        rb.velocity = new Vector3(xzSpeed.x, rb.velocity.y, xzSpeed.y);
    }
}
