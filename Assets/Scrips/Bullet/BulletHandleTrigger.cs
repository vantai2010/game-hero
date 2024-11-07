using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletHandleTrigger : CustomBehavior
{
    [Header("Bullet Handle Trigger")]
    [SerializeField] protected BulletCtrl bulletCtrl;
    protected override void LoadComponent()
    {
        base.LoadComponent();
        this.LoadBulletCtrl();
    }
    protected virtual void LoadBulletCtrl()
    {
        if (this.bulletCtrl != null) return;
        this.bulletCtrl = GetComponent<BulletCtrl>();
    }
    protected virtual void OnTriggerEnter2D(Collider2D other)
    {
        if (other.transform.tag == "Item") return;
        if(gameObject.name == "Bullet_1")
        {
            this.bulletCtrl.BullelWeaponDespawn.DespawnObject();
        }
        else
        {
            this.bulletCtrl.BulletDespawn.DespawnObject();
        }
        this.bulletCtrl.DamageSender.Send(other.transform);
    }
}
