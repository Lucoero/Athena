using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Mov1 : MonoBehaviour
{
    /* Información del Método 1
    Usando el legacy Input System de Unity podemos modificar la velocidad del objeto
    sin necesidad de especificar las letras aquí (se hace en el editor de Unity).
    Ventajas:
    - Código más limpio
    - Movimiento constante
    Desventajas:
    - Movimiento artificial por ausencia de inercia.
    - Por alguna razón no puedo modificar el nombre de los ejes, ya que al iniciar el juego
    se sobreescriben por los originales. --> Inflexibilidad al instanciar. Creo que es porque lo hacia mientras
    estaba ejecutado el juego, y por tanto al reiniciarlo volvia a los valores de ANTES de iniciarlo.
    */
    public int speed = 10;
    public Rigidbody rb; // We anounce that there is a rigid body around, and we call it rb.
    void Start()
    {
        rb = GetComponent<Rigidbody>(); // We search a Rigidbody object in our assets.
        Debug.Log("Goobert");
    }
    //'Update' updates every frame (the higher the framerate the more the code is executed per second), fixedupdate updates at a specific interval,
    //decided by the engine
    void Update()
    { 
        float xMov = Input.GetAxisRaw("Horizontal") * speed; // If d is pressed, it returns 1. Elseif a is pressed, it returs -1. Else,it returns 0
        float zMov = Input.GetAxisRaw("Vertical") * speed; // If w is pressed, it returns 1. Elseif s is pressed, it returns -1. Else, it returns 0
        rb.velocity = new Vector3(xMov,rb.velocity.y,zMov); // We introduce the new velocity.
        /* Due to changing velocity property we need friction in order to return to a static state.
         * NO KEY WILL STOP MOVEMENT because we are replacing old speeds with new ones. */ 
    }
}
