using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnowControl : MonoBehaviour
{
    public float snowDamage = 20.0f;
    public float snowForce = 200.0f;

    private Rigidbody rb;
    
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.AddForce(transform.forward * snowForce);
    }

    void Update()
    {
        
    }
}
