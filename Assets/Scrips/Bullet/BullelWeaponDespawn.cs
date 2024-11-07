using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BullelWeaponDespawn : DespawnByTime
{
    [Header("Bullet Weapon Despawn")]
    [SerializeField] protected BulletCtrl bulletCtrl;

    protected override void ResetValue()
    {
        base.ResetValue();
        if (this.bulletCtrl.CheckShootBy.NameWeapon == "Shotgun")
        {
            this.timeLimit = 0.5f;
        }
        else
        {
            this.timeLimit = 30f;
        }
    }

    protected override void LoadComponent()
    {
        base.LoadComponent();
        this.LoadBulletCtrl();
    }
    protected virtual void LoadBulletCtrl()
    {
        if (this.bulletCtrl != null) return;
        this.bulletCtrl = transform.parent.GetComponent<BulletCtrl>();
    }

    public override void DespawnObject()
    {
        BulletSpawner.Instance.Despawn(transform.parent);
    }
}
