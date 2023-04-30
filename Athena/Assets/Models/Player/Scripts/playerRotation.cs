using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.iOS;

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
    // Codigo solo para Forma 1
    public PlayerInputClass playerControls;
    public InputAction look;
    private Camera cam;
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
        Debug.Log(string.Format("{0}: ({1};{2};{3})",name,v.x,v.y,v.z));
    }
    void Update() // Update is called once per frame
    {
        // FORMA 1: Al moverse el ratón se rota el objeto
        // Vector2 orientation = look.ReadValue<Vector2>() * rotationSpeed;
        // rb.transform.Rotate(0f, orientation.x, 0f);
        // Forma 2: El objeto apunta en la dirección del ratón
        /*
        Vector2 mousePosition = Mouse.current.position.ReadValue() * rotationSpeed;
        Debug.Log(mousePosition.x);
        rb.rotation = Quaternion.Euler(0f,mousePosition.x, 0f);
        */
        // Forma 3: Calculo el angulo de rotacion con trigonometria respecto al plano xz
        // PROBLEMA: LA POSICION DEL RATON Y LA DEL OBJETO NO PARECEN TENER EL MISMO SISTEMA DE REFERENCIA. 
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Mouse.current.position.ReadValue()); // La posición, por alguna razón, es constante.
        representarVector(mousePosition, "mousePosition");
        Vector3 objectPosition = transform.position;
        //representarVector(objectPosition, "objectPosition");
        Vector3 fromObjectToMouse = mousePosition - objectPosition;
        // representarVector(fromObjectToMouse,"fromObjectToMouse");
        float angle = Mathf.Atan2(fromObjectToMouse.x,fromObjectToMouse.y)*Mathf.Rad2Deg;
        //Debug.Log("Ángulo de giro (grados): " + angle);
        rb.rotation = Quaternion.AngleAxis(angle, Vector3.up);
    }
}
