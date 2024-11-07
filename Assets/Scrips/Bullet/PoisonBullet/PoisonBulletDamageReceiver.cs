using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoisonBulletDamageReceiver : DamageReceiver
{
    [Header("Poison Bullet Damage Receiver")]
    [SerializeField] protected BulletCtrl bulletCtrl;
    protected override void ResetValue()
    {
        base.ResetValue();
        this.maxHp = 30;
    }

    protected override void LoadComponent()
    {
        base.LoadComponent();
        this.LoadBulletCtrl();
    }
    protected void LoadBulletCtrl()
    {
        if (this.bulletCtrl != null) return;
        this.bulletCtrl = transform.parent.GetComponent<BulletCtrl>();  
    }

    protected override void OnDead()
    {
        this.bulletCtrl.BulletDespawn.DespawnObject();    
    }

}
