using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public int speed = 10;
    public Rigidbody rb;
    void Start()
    {
        Debug.Log("Goobert");
    }
    //'Update' updates every frame (the higher the framerate the more the code is executed per second), fixedupdate updates at a specific interval,
    //decided by the engine
    void FixedUpdate()
    {
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
