using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemCtrl : CustomBehavior
{
    [Header("Bullet ctrl")]
    [SerializeField] protected ItemPickupable itemPickupable;
    public ItemPickupable ItemPickupable => itemPickupable;

    protected override void LoadComponent()
    {
        base.LoadComponent();
        this.LoadItemPickupable();
    }
    protected virtual void LoadItemPickupable()
    {
        if (this.itemPickupable != null) return;
        this.itemPickupable = GetComponentInChildren<ItemPickupable>();
    }

    
}
