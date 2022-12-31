using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Objective : MonoBehaviour
{
    public Transform objective;
    public Transform tents;
    public Transform buildA;
    public Transform buildB;
    public Transform zoneA;
    public Transform zoneB;
    public Transform zoneC;

    private GenerateEnemies generateEnemiesA;
    private GenerateEnemies generateEnemiesB;
    private GenerateEnemies generateEnemiesC;

    private float distanceA;
    private float distanceB;
    private float distanceC;
    // Start is called before the first frame update
    void Start()
    {
        generateEnemiesA = zoneA.gameObject.GetComponent<GenerateEnemies>();
        generateEnemiesB = zoneB.gameObject.GetComponent<GenerateEnemies>();
        generateEnemiesC = zoneC.gameObject.GetComponent<GenerateEnemies>();
        objective.gameObject.SetActive(false);
        tents.gameObject.SetActive(false);
        buildA.gameObject.SetActive(false);
        buildB.gameObject.SetActive(false);


    }

    // Update is called once per frame
    void Update()
    {
        distanceA = Vector3.Distance(zoneA.position,transform.position);
        distanceB = Vector3.Distance(zoneB.position, transform.position);
        distanceC = Vector3.Distance(zoneC.position, transform.position);

        if (Vector3.Distance(this.transform.position, objective.position) < 200)
        {
            objective.gameObject.SetActive(true);
        }
        else
        {
            objective.gameObject.SetActive(false);
        }


        if (Vector3.Distance(this.transform.position, objective.position) < 200)
        {
            objective.gameObject.SetActive(true);
        }
        else
        {
            objective.gameObject.SetActive(false);
        }



        if (Vector3.Distance(this.transform.position, tents.position) < 200)
        {
            tents.gameObject.SetActive(true);
        }
        else
        {
            tents.gameObject.SetActive(false);
        }


        if (Vector3.Distance(this.transform.position, buildA.position) < 200)
        {
            buildA.gameObject.SetActive(true);
        }
        else
        {
            buildA.gameObject.SetActive(false);
        }


        if (Vector3.Distance(this.transform.position, buildB.position) < 200)
        {
            buildB.gameObject.SetActive(true);
        }
        else
        {
            buildB.gameObject.SetActive(false);
        }

        if (distanceA<generateEnemiesA.radius)
        {
            zoneA.gameObject.SetActive(true);
        }
        else
        {
            zoneA.gameObject.SetActive(false);
        }

        if (distanceB < generateEnemiesB.radius)
        {
            zoneB.gameObject.SetActive(true);
        }
        else
        {
            zoneB.gameObject.SetActive(false);
        }
        if (distanceC < generateEnemiesC.radius)
        {
            zoneC.gameObject.SetActive(true);
        }
        else
        {
            zoneC.gameObject.SetActive(false);
        }
    }
}
