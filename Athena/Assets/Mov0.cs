using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mov0 : MonoBehaviour
{
    /* Información del Método 0
    Hace uso de fuerzas.
    * Ventajas:
    - Ya incluye inercia, lo que da realismo
    * Desventajas:
    - Tiene pinta de ser poco eficiente y engorroso
    - Estás acelerando constantemente al pulsar la tecla.
    */
    public int speed = 10;
    public Rigidbody rb;
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("Goobert");
    }

    // Update is called once per frame
    void Update()
    {
        //METODO ORIGINAL

        if (Input.GetKey("d")){
            rb.AddForce(speed, 0, 0);

        }
        if (Input.GetKey("a"))
        {
            rb.AddForce(-speed, 0, 0);

        }
        if (Input.GetKey("w"))
        {
            rb.AddForce(0, 0, speed);

        }
        if (Input.GetKey("s"))
        {
            rb.AddForce(0, 0, -speed);

        }
    }
}
