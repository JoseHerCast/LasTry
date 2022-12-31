using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fuel : InventoryItemBase
{
    public override string Name
    {
        get
        {
            return "Fuel";
        }
    }
    public override void OnPickup()
    {
        gameObject.SetActive(false);
        Pickup.pickup.SetFuel();
    }
}
