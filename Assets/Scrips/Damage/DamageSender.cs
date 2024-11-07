using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public abstract class DamageSender : CustomBehavior
{
    [SerializeField] protected int damage;
    public virtual void Send(Transform obj)
    {
        DamageReceiver damageReceiver = obj.GetComponentInChildren<DamageReceiver>();
        if (damageReceiver == null) return;
        this.Send(damageReceiver);
        this.CreateEffect();
    }
    public virtual void Send(DamageReceiver damageReceiver)
    {
        damageReceiver.Deduct(this.damage);
    }
    protected virtual void CreateEffect()
    {

    }
}