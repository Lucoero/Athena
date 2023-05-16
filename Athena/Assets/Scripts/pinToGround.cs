using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class pinToGround : MonoBehaviour
{
    /* pinToGround
	Dado un objeto, comprueba su distancia al suelo y
    lo coloca justo encima
    */

    // VARIABLES
    private Rigidbody rb;
    public Ray toGround;
    private int maxDistance = 10;
    private int speed = 5;

    // FUNCIONES
    void CheckForColliders()
    {
        if (Physics.Raycast(toGround,out RaycastHit hit))
        {
            Debug.Log("He dao");
            rb.velocity =  new Vector3 (rb.velocity.x,-speed, rb.velocity.z); // Sube para arriba
        }
    }
    void Start() 
    {
        //toGround = new Ray(rb.position, Vector3.down);
        //CheckForColliders();
    }

    
    void FixedUpdate()
    {   
    }
}
