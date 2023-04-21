using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public int speed = 10;
    public Rigidbody rb; // We anounce that there is a rigid body around, and we call it rb
    void Start()
    {
        rb = GetComponent<Rigidbody>(); // We search a Rigidbody object in our assets. 
        Debug.Log("Goobert");
    }
    //'Update' updates every frame (the higher the framerate the more the code is executed per second), fixedupdate updates at a specific interval,
    //decided by the engine
    void FixedUpdate()
    {
        /* METODO ORIGINAL
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
        */

        // MÉTODO Lucoero
        float xMov = Input.GetAxisRaw("Horizontal"); // If d is pressed, it returns 1. Elseif a is pressed, it returs -1
        float zMov = Input.GetAxisRaw("Vertical"); // If w is pressed, it returns 1. Elseif s is pressed, it returns -1
        rb.velocity = new Vector3(xMov, rb.velocity.y, zMov) * speed; // We introduce the new velocity.
        /* Due to changing velocity property we need friction in order to return to a static state.
         * NO KEY WILL STOP MOVEMENT because we are replacing old speeds with new ones. 
        */
    }
}
