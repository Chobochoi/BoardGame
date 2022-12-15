using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnowRemove : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.tag == "SNOW")
        {
            Destroy(collision.gameObject);
        }
    }
}
