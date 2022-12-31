using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LifeBar : MonoBehaviour
{
    public Scrollbar lifeBar;
    public float damage;
    private float life = 1f;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        lifeBar.size = life;
    }
    public void Recovery()
    {
        life += 0.3f;
        if (life > 1f)
        {
            life = 1f;
        }
    }

    public float LifeStatus()
    {
        return life;
    }
    //On collision triggering drain players life
    private void OnTriggerStay (Collider other)
    {
        if (other.gameObject.tag == "Enemy")
        {
            //print("Colisión con enemigo");
            StartCoroutine(DrainLife());
        }
    }
    private IEnumerator DrainLife()
    {
        life -= damage;
        if(life>0)
        yield return new WaitForSeconds(2);
    }
}
