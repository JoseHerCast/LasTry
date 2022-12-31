using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieAudio : MonoBehaviour
{
    public AudioSource normal;
    public AudioSource die;

    // Start is called before the first frame update
    void Start()
    {
        normal.Play();
        print("Playing Normal Zombie Sound");
        die.Stop();
    }

    public void IsDie()
    {
        normal.Stop();
        print("Playing Die Zombie Sound");
        die.Play();
    }
}
