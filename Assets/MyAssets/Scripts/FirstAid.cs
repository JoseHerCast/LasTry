using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirstAid : InventoryItemBase
{
    public LifeBar lifeBar;

    public override string Name
    {
        get
        {
            return "FirstAid";
        }
    }
    public override void OnPickup()
    {
        if (lifeBar.LifeStatus() < 1)
        {
            lifeBar.Recovery();
            transform.gameObject.SetActive(false);
        }
        else
        {
            print("Vida a tope");
        }
        //StartCoroutine(Respawn());
    }

    //private IEnumerator Respawn()
    //{
    //    transform.gameObject.SetActive(false);
    //    yield return new WaitForSeconds(10);
    //    transform.gameObject.SetActive(true);
    //}
}
