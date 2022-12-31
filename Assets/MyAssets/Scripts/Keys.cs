using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Keys : InventoryItemBase
{
    public override string Name
    {
        get
        {
            return "Keys";
        }
    }
    public override void OnPickup()
    {
        gameObject.SetActive(false);
        Pickup.pickup.SetKeys();
    }
}
