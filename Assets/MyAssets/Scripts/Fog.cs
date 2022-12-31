using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fog : MonoBehaviour
{
    public float radius;
    public Transform fogSpawnPoint;
    public Transform player;
    private float fSPDistance;
    private float playerDistance;
    private int counter;
    // Start is called before the first frame update
    void Start()
    {
        counter = 0;
    }

    // Update is called once per frame
    void Update()
    {
        fSPDistance = Vector3.Distance(transform.position, fogSpawnPoint.position);
        playerDistance = Vector3.Distance(transform.position, player.position);
        if (counter < 1)
        {
            if (fSPDistance > radius)
            {
                Instantiate(transform.gameObject, fogSpawnPoint.position, Quaternion.identity);
                print("Se creo instancia");
                //Debug.Break();
                counter++;
            }
        }
        if (playerDistance > (2 * radius))
        {
            print("Instancia destruida");
            Destroy(transform.gameObject);
        }

    }
    void OnDrawGizmosSelected()
    {
        Gizmos.color = new Color(1, 0, 0, 0.5f);
        Gizmos.DrawSphere(transform.position,radius);
    }
}
