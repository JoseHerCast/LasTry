using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    public float damageAmount=1f;
    public float range = 150f;
    public AudioSource shootingSound;
    public ParticleSystem shootingEffect;
    public Camera playerCam;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            Shoot();
        }
    }

    void Shoot()
    {
        RaycastHit hit;
        if (Physics.Raycast(playerCam.transform.position,playerCam.transform.forward,out hit,range))
        {
            Debug.Log(hit.transform.name);
            Target target = hit.transform.GetComponent<Target>();
            if (target != null)
            {
                target.DamageReceived(damageAmount);
            }
        }
        shootingSound.Play();
        shootingEffect.Play();
    }
}
