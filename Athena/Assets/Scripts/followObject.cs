using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class followObject : MonoBehaviour
{
    public Transform Object;
    public Vector3 offset;
   
    void Update()
    {
        transform.position = Object.position + offset;
    }
}
