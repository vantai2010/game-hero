using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explosion : CustomBehavior
{
    [Header("Explosion")]
    [SerializeField] protected FallingMeteorCtrl fallingMeteorCtrl;

    protected override void LoadComponent()
    {
        base.LoadComponent();
        this.LoadFallingMeteorCtrl();
    }

    protected void LoadFallingMeteorCtrl()
    {
        if (this.fallingMeteorCtrl != null) return;
        this.fallingMeteorCtrl = transform.parent.GetComponent<FallingMeteorCtrl>();
    }

    protected virtual void FixedUpdate()
    {
        this.ExplosionAfterDespawnMetor();
    }

    protected virtual void ExplosionAfterDespawnMetor()
    {
        
    }
}
