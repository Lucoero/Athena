using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.iOS;
using UnityEngine.UIElements;

public class playerRotation2 : MonoBehaviour
{
    /* Forma 2: Calculo el angulo de rotacion con trigonometria respecto al plano xz
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

    //FUNCIONES
    void Update()
    {
        Vector3 mousePos = Mouse.current.position.ReadValue();
        Vector3 objectPos = Camera.main.WorldToScreenPoint(rb.position);
        mousePos.x = mousePos.x - objectPos.x;
        mousePos.y = mousePos.y - objectPos.y;
        float angle = Mathf.Atan2(mousePos.y, mousePos.x) * Mathf.Rad2Deg;
        rb.rotation = Quaternion.Euler(new Vector3(0f, -angle, 0f)); // No se por que con angle rota en sentido contrario. Magico.
    }
}
