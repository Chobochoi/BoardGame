using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThrowControl : MonoBehaviour
{
    public GameObject snow;
    public Transform snowPos;
    
    void Start()
    {
        
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Fire();
        }
    }

    void Fire()
    {
        Instantiate(snow, snowPos.position, snowPos.rotation);
    }
}
