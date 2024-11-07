using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class WeaponAbstract: CustomBehavior
{
    [Header("Weapon Abstract")]
    [SerializeField] protected WeaponCtrl weaponCtrl;

    protected override void LoadComponent()
    {
        base.LoadComponent();
        this.LoadWeaponCtrl();
    }
    protected virtual void LoadWeaponCtrl()
    {
        if (this.weaponCtrl != null) return;
        this.weaponCtrl = transform.parent.GetComponent<WeaponCtrl>();
    }
}
