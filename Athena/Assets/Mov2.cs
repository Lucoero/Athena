using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;
public class Mov2 : MonoBehaviour
{
    /* Información del Método 2
    Usando el nuevo Input System de Unity podemos modificar la velocidad del objeto
    sin necesidad de especificar las letras aquí (se hace en el editor de Unity),
    así como otros controles básicos (mirar, interactuar, etc).
    Si se hace a partir de variables que vamos añadiendo (Mov2) funciona, pero estaría limitado
    respecto al sistema de eventos que se puede usar (Mov3) 
    Ventajas:
    - Código más limpio.
    - Movimiento constante.
    - Se puede aplicar a controles más complejos.
    Desventajas:
    - Movimiento artificial por ausencia de inercia.
    - Requiere la instalación del Paquete InputSystem.
    - Es algo más complicado de interiorizar al principio.
    - Algo incompleto sin el uso de eventos (Mov3)
    */

    // PARTE 1
    public int speed = 10;
    public Rigidbody rb;
    public InputAction playerControls;
    // A continuación se crean eventos necesarios para la libreria Input
    private void OnEnable()
    {
       playerControls.Enable();
    }
    private void OnDisable()
    {
       playerControls.Disable();
    }
    void Start()
    {
        Debug.Log("Goobert");
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Vector2 xzSpeed = playerControls.ReadValue<Vector2>() * speed; // Los almacena como x e y, pero nuestra y será una z. 
        
        rb.velocity = new Vector3(xzSpeed.x, rb.velocity.y, xzSpeed.y);
    }
}
