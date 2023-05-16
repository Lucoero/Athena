using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.iOS;
using UnityEngine.UIElements;

public class rotateTowardsMouse : MonoBehaviour
{
    /* Forma 2: Calculo el angulo de rotacion con trigonometria respecto al plano xz
	Permite rotar al personaje respecto al eje y.
    Esto, en un futuro, se encargará de mover la luz de la linterna.
    */

    // VARIABLES PUBLICAS
    public Rigidbody rb;

    //FUNCIONES
    void FixedUpdate()
    {
        Vector3 mousePos = Mouse.current.position.ReadValue();
        Vector3 objectPos = Camera.main.WorldToScreenPoint(rb.position);
        mousePos.x = mousePos.x - objectPos.x;
        mousePos.y = mousePos.y - objectPos.y;
        float angle = Mathf.Atan2(mousePos.y, mousePos.x) * Mathf.Rad2Deg;

        // Hay que invertir el sentido de rotación porque por defecto es antihorario.
        // El +90 es para que la cara en vez del hombro derecho sea el frente.
        rb.rotation = Quaternion.Euler(new Vector3(0f, 90f - angle , 0f)); 
    }
}
