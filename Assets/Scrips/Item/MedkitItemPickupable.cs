using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MedkitItemPickupable : ItemPickupable
{
    [Header("Medkit Item Pickupable")]
    [SerializeField] protected int recoveryHp;

    protected override void ResetValue()
    {
        base.ResetValue();
        this.recoveryHp = 40;
    }

    public override void HandleCollison(Collider2D other)
    {
        if (other.gameObject.tag != "Player") return;
        DamageReceiver damageReceiver = other.GetComponentInChildren<DamageReceiver>();
        if (damageReceiver == null) return;
        damageReceiver.Add(recoveryHp);
        ItemSpawner.Instance.Despawn(transform.parent);
    }
}
