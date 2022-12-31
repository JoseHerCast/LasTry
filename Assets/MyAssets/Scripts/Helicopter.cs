using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Helicopter : InventoryItemBase
{
    public override string Name
    {
        get
        {
            return "Helicopter";
        }
    }
    public override void OnPickup()
    {
        if(Pickup.pickup.GetKeys() && Pickup.pickup.GetFuel())
        {
            print("Lo lograste!!");
            ScenesManager.scenesManager.Succesful();
        }
        else
        {
            print("No estas listo para irte");
        }
    }
}
