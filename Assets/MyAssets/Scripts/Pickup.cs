using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickup : MonoBehaviour
{
    public GUIActivity gui;
    public Inventory inventory;
    public bool iHaveKeys;
    public bool iHaveFuel;
    public static Pickup pickup;
    // Start is called before the first frame update
    void Start()
    {
        pickup = this;
        iHaveFuel = false;
        iHaveKeys = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F) && mItemToPickup != null)
        {
            if(mItemToPickup.Name!="Helicopter"&& mItemToPickup.Name != "FirstAid")
                inventory.AddItem(mItemToPickup);
            mItemToPickup.OnPickup();
            gui.CloseMessagePanel();
        }
    }

    public void SetKeys()
    {
        iHaveKeys = true;
    }
    public bool GetKeys()
    {
        return iHaveKeys;
    }
    public void SetFuel()
    {
        iHaveFuel = true;
    }
    public bool GetFuel()
    {
        return iHaveFuel;
    }

    IInventoryItem mItemToPickup = null;

    private void OnTriggerEnter(Collider other)
    {
        IInventoryItem item = other.GetComponent<IInventoryItem>();
        if (item != null)
        {
            //if (mLockPickup)
            //    return;

            mItemToPickup = item;
            //inventory.AddItem(item);
            //item.OnPickup();
            gui.OpenMessagePanel("");
        }
    }

    private void OnTriggerExit(Collider other)
    {
        IInventoryItem item = other.GetComponent<IInventoryItem>();
        if (item != null)
        {
            gui.CloseMessagePanel();
            mItemToPickup = null;
        }
    }
}
