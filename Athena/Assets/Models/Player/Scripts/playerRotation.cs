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
    private Vector2 lastMousePositionXZ;
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
        Vector3 lastMousePosition = new Vector3(Mouse.current.position.ReadValue().x, Mouse.current.position.ReadValue().y, rb.position.z);
        lastMousePosition = cam.ScreenToWorldPoint(lastMousePosition);
        lastMousePositionXZ = new Vector2(lastMousePosition.x, lastMousePosition.z);
        
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
        UnityEngine.Debug.Log(string.Format("{0}: ({1};{2};{3})",name,v.x,v.y,v.z));
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
        // 1. Obtengo la posición de la cámara dentro del juego, y la del objeto
        Vector3 mousePosition3D = new Vector3(Mouse.current.position.ReadValue().x, Mouse.current.position.ReadValue().y, rb.position.z); // La ultima coordenada es la distancia al plano de lectura.
        mousePosition3D = cam.ScreenToWorldPoint(mousePosition3D); 
        Vector2 mousePositionXZ = new Vector2(mousePosition3D.x, mousePosition3D.y);
        //representarVector(mousePositionXZ, "mousePositionXZ");
        //representarVector(lastMousePositionXZ, "lastMousePositionXZ");

        Vector3 objectPosition = rb.position;
        Vector2 objectPositionXZ = new Vector2(objectPosition.x, objectPosition.z);
        representarVector(objectPosition, "objectPosition");

        // 2. Calculo la distancia entre mousePosition y lastMousePosition
        float distanceMouses = (mousePositionXZ - lastMousePositionXZ).magnitude;
        //UnityEngine.Debug.Log("Distancia entre ratones: " + distanceMouses);

        // 3. Calculo la distancia entre el objeto y lastMousePosition
        float distanceObjectlastMouse = (lastMousePositionXZ- objectPositionXZ).magnitude;
        //UnityEngine.Debug.Log("Distancia entre objeto y lastMouse: " + distanceObjectlastMouse);

        // 4. Calculo la distancia entrer el objeto y el Mouse
        float distanceObjectMouse = (mousePositionXZ - objectPositionXZ).magnitude;
        lastMousePositionXZ = mousePositionXZ; // Actualizo la ultima posicion.
        // 5. Calculo el angulo con el teorema del coseno
        float angle = Mathf.Acos((Mathf.Pow(distanceObjectMouse, 2) + Mathf.Pow(distanceObjectlastMouse, 2) -Mathf.Pow(distanceMouses,2)) /
            (2*Mathf.Pow(distanceObjectMouse,2)*Mathf.Pow(distanceObjectlastMouse,2))) *Mathf.Rad2Deg;
        //UnityEngine.Debug.Log("Angle: " + angle);

        // 6. Roto el objeto
        rb.rotation = Quaternion.AngleAxis(angle, Vector3.up);
    }
}
