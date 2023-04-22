using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;
public class Mov2 : MonoBehaviour
{
    /* Informaci�n del M�todo 2
    Usando el nuevo Input System de Unity podemos modificar la velocidad del objeto
    sin necesidad de especificar las letras aqu� (se hace en el editor de Unity),
    as� como otros controles b�sicos (mirar, interactuar, etc).
    Si se hace a partir de variables que vamos a�adiendo (Mov2) funciona, pero estar�a limitado
    respecto al sistema de eventos que se puede usar (Mov3) 
    Ventajas:
    - C�digo m�s limpio.
    - Movimiento constante.
    - Se puede aplicar a controles m�s complejos.
    Desventajas:
    - Movimiento artificial por ausencia de inercia.
    - Requiere la instalaci�n del Paquete InputSystem.
    - Es algo m�s complicado de interiorizar al principio.
    - Algo incompleto sin el uso de eventos (Mov3)
    */

    // PARTE 1
    public int speed = 10;
    public Rigidbody rb;
    public InputAction playerControls;
    // A continuaci�n se crean eventos necesarios para la libreria Input
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
        Vector2 xzSpeed = playerControls.ReadValue<Vector2>() * speed; // Los almacena como x e y, pero nuestra y ser� una z. 
        
        rb.velocity = new Vector3(xzSpeed.x, rb.velocity.y, xzSpeed.y);
    }
}
