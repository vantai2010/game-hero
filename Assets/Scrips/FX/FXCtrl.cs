using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FXCtrl : CustomBehavior
{
    [Header("FX ctrl")]
    [SerializeField] protected FXDespawn fxDespawn;
    public FXDespawn FXDespawn => fxDespawn;

    protected override void LoadComponent()
    {
        base.LoadComponent();
        this.LoadFXDespawn();
    }
    protected virtual void LoadFXDespawn()
    {
        if (this.fxDespawn != null) return;
        this.fxDespawn = GetComponentInChildren<FXDespawn>();
    }
}
