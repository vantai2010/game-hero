using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletCtrl : CustomBehavior
{
    [Header("Bullet ctrl")]
    [SerializeField] protected BulletDespawn bulletDespawn;
    [SerializeField] protected BullelWeaponDespawn bullelWeaponDespawn;
    [SerializeField] protected DamageSender damageSender;
    [SerializeField] protected CheckShootBy checkShootBy;
    public BulletDespawn BulletDespawn => bulletDespawn;
    public BullelWeaponDespawn BullelWeaponDespawn => bullelWeaponDespawn;
    public DamageSender DamageSender => damageSender;
    public CheckShootBy CheckShootBy => checkShootBy;   

    protected override void LoadComponent()
    {
        base.LoadComponent();
        this.LoadBulletDespawn();
        this.LoadBulletWeaponDespawn();
        this.LoadDamageSender();
        this.LoadCheckShootBy();
    }
    protected virtual void LoadBulletDespawn()
    {
        if (this.bulletDespawn != null) return;
        this.bulletDespawn = GetComponentInChildren<BulletDespawn>();
    }
    protected virtual void LoadBulletWeaponDespawn()
    {
        if (this.bullelWeaponDespawn != null) return;
        this.bullelWeaponDespawn = GetComponentInChildren<BullelWeaponDespawn>();
    }

    protected virtual void LoadDamageSender()
    {
        if (this.damageSender != null) return;
        this.damageSender = GetComponentInChildren<DamageSender>();
    }
    protected virtual void LoadCheckShootBy()
    {
        if(this.checkShootBy != null) return;
        this.checkShootBy = GetComponentInChildren<CheckShootBy>(); 
    }
}
