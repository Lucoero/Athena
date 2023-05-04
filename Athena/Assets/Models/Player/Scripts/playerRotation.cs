using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.iOS;
using UnityEngine.UIElements;

public class playerRotation : MonoBehaviour
{
    /* Forma 1: El objeto apunta en la dirección del ratón
	Permite rotar al personaje respecto al eje y.
    Esto, en un futuro, se encargará de mover la luz de la linterna.
    */

    // VARIABLES PUBLICAS
    public Rigidbody rb;
    public PlayerInputClass playerControls;
    public InputAction look;
   
    public void Awake()
    {
        playerControls = new PlayerInputClass();
    }
    public void OnEnable()
    {
        look = playerControls.Player.Look;
        look.Enable();
    }
    public void OnDisable()
    {
        look.Disable();
    }
    // FUNCIONES
    void FixedUpdate()
    {
        Vector3 mousePos = Mouse.current.position.ReadValue();
        Vector3 objectPos = Camera.main.WorldToScreenPoint(rb.position);
        Vector3 mouseToObject = new Vector3 (0f,rb.position.y,0f); // Hay que mantener el plano en y. 
        mouseToObject.x = mousePos.x - objectPos.x;
        mouseToObject.z = mousePos.y - objectPos.y;
        Vector3 uMouseToObject = mouseToObject.normalized;
        rb.rotation = Quaternion.LookRotation(uMouseToObject, Vector3.up); // Me convierte el vector director en un angulo de giro.
        // LookRotation, por alguna razón, me hace avanzar tambien en la direccion del raton. Desaparece con la opcion IsKinematic
    }
}
