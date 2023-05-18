using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class orbitAroundObject : MonoBehaviour
{
    /* COMENTARIO PARA DESCRBIR EL SCRIPT
	
    */

    // VARIABLES
    public Rigidbody centerObject;
    public Rigidbody orbitingObject;
    public Vector3 offset;

    private Vector3 objectPosition;
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
        objectPosition = new Vector3(mousePos.x - centerPos.x, orbitingObject.position.y, mousePos.y - centerPos.y);
        objectPosition = centerObject.position + Vector3.Cross(objectPosition,Vector3.up).normalized*radius + offset; 
        orbitingObject.position = objectPosition;
    }
}
