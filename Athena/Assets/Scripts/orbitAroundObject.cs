using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class orbitAroundObject : MonoBehaviour
{
    /* orbitAroundObject
	Calcula la posición de un objeto respecto a otro siguiendo la linea que une el ratón y el objeto central. 
    SIN TERMINAR: No tiene script para que se mueva con el giro que da el movimiento al personaje (rotate towards movement). 
    */

    // VARIABLES
    public Rigidbody centerObject;
    public Rigidbody orbitingObject;
    public Vector3 offset;

    private Vector3 newPosition;
    private float radius;

    // FUNCIONES
    void Start() 
    {
        radius = (new Vector2 (centerObject.position.x-orbitingObject.position.x, centerObject.position.z - orbitingObject.position.z)).magnitude;
    }

    
    void FixedUpdate()
    {
        Vector2 mousePos = Mouse.current.position.ReadValue();
        Vector3 centerPos = Camera.main.WorldToScreenPoint(centerObject.position);
        // El vector del objeto es el perpendicular (el hombro está en perpendicular)
        newPosition = new Vector3(mousePos.x - centerPos.x, orbitingObject.position.y, mousePos.y - centerPos.y);
        newPosition = centerObject.position + Vector3.Cross(newPosition,Vector3.up).normalized*radius + offset; 
        orbitingObject.position = newPosition;
    }
}
