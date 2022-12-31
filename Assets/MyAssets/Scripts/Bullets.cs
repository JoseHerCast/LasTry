using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Bullets : MonoBehaviour
{
    public float semiBulletsIHave;
    public float autoBulletsIHave;
    public float semiBulletsInWeapon;
    public float autoBulletsInWeapon;

    public static Bullets bullets;
    // Start is called before the first frame update
    void Start()
    {
        bullets = this;
        semiBulletsIHave = 0;
        autoBulletsIHave = 0;
        semiBulletsInWeapon = 0;
        autoBulletsInWeapon = 0;
    }

    // Update is called once per frame
    void Update()
    {
 
    }
}
