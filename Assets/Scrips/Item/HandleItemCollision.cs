using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandleItemCollision : CustomBehavior
{
    [Header("Handle Item Collision")]
    [SerializeField] protected ItemCtrl itemCtrl;

    protected override void LoadComponent()
    {
        base.LoadComponent();
        this.LoadItemCtrl();
    }

    protected virtual void LoadItemCtrl()
    {
        if (this.itemCtrl != null) return;
        this.itemCtrl = GetComponent<ItemCtrl>();
    }
    protected virtual void OnTriggerEnter2D(Collider2D other)
    {
        this.itemCtrl.ItemPickupable.HandleCollison(other);
    }
}
