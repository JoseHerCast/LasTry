using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyProjectile : MonoBehaviour
{
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag.Equals("Player"))
        {
            print("Colisi�n con jugador");
            Destroy(transform.gameObject);
        }
        if(collision.gameObject.tag.Equals("Ground"))
        {
            print("Colisi�n con terreno");
            Destroy(transform.gameObject);
        }
    }
}
