using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.iOS;
using UnityEngine.UIElements;

public class playerRotation : MonoBehaviour
{
    /* COMENTARIO PARA DESCRBIR EL SCRIPT
	Permite rotar al personaje respecto al eje y.
    Esto, en un futuro, se encargará de mover la luz de la linterna.
    El siguiente link puede ayudar:
    https://gamedevbeginner.com/input-in-unity-made-easy-complete-guide-to-the-new-system/#input_system
    */

    // VARIABLES
    public float rotationSpeed = 1;
    public Rigidbody rb;
    private Camera cam;
    // Codigo solo para Forma 1
    public PlayerInputClass playerControls;
    public InputAction look;
   

    public void Awake()
    {
        playerControls = new PlayerInputClass();
    }
    public void Start()
    {
        cam = Camera.main;
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
    void representarVector(Vector3 v, string name = "vector")
    {
        UnityEngine.Debug.Log(string.Format("{0}: ( {1} ; {2} ; {3} )",name,v.x,v.y,v.z));
    }
    void Update() // Update is called once per frame
    {
        // FORMA 1: Al moverse el ratón se rota el objeto
        Vector2 orientation = look.ReadValue<Vector2>() * rotationSpeed;
        rb.transform.Rotate(0f, orientation.x, 0f);
        // Forma 2: El objeto apunta en la dirección del ratón
        /*
        Vector2 mousePosition = Mouse.current.position.ReadValue() * rotationSpeed;
        Debug.Log(mousePosition.x);
        rb.rotation = Quaternion.Euler(0f,mousePosition.x, 0f);
        */
        // Forma 3: Calculo el angulo de rotacion con trigonometria respecto al plano xz
        // 1. Obtengo la posición de la cámara fuera del juego, y la del objeto
        Vector3 mousePosition = Input.mousePosition;
        Vector3 objectScreenPosition = cam.WorldToScreenPoint(rb.position);
        Vector3 mouseToObject = mousePosition - objectScreenPosition; 
        float angle = Mathf.Atan2(Mathf.Abs(mouseToObject.z),Mathf.Abs(mouseToObject.x))*Mathf.Rad2Deg;

        // 6. Roto el objeto
        rb.rotation = Quaternion.Euler(0,angle, 0);
    }
}
