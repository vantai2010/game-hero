using System.Collections;
using System.Collections.Generic;

#if UNITY_EDITOR
using UnityEditor.Build;
#endif

using UnityEngine;

public abstract class DamageReceiver : CustomBehavior
{
    [Header("Damage Receiver")]
    [SerializeField] protected int hp;
    [SerializeField] protected int maxHp;
    [SerializeField] protected bool isDead;
    public int Hp => hp;
    public int MaxHp => maxHp;

    protected virtual void OnEnable()
    {
        this.Reborn();
    }
    public virtual void Reborn()
    {
        this.hp = this.maxHp;
        this.isDead = false;
    }
    public virtual void Add(int deduct)
    {
        if (this.isDead) return;
        this.hp += deduct;
        if (this.hp > this.maxHp) this.hp = this.maxHp;
        this.EffectAddRecoveryHp();
    }
    public virtual void Deduct(int deduct)
    {
        //if (this.isDead) return;
        this.hp -= deduct;
        if (this.hp < 0) this.hp = 0;
        this.EffectReceivingDamage();
        this.CheckIsDead();
    }
    protected virtual void CheckIsDead()
    {
        if (!this.IsDead()) return;
        this.isDead = true;
        this.OnDead();
    }
    public virtual bool IsDead()
    {
        return this.hp <= 0;
    }
    protected abstract void OnDead();
    protected virtual void EffectReceivingDamage()
    {

    }
    protected virtual void EffectAddRecoveryHp()
    {

    }
}
