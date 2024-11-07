using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AbilityObjectCtrl : ObjectHasAnimatorCtrl
{
    [Header("Ability Object Ctrl")]
    [SerializeField] protected LoadTarget loadTarget;
    public LoadTarget LoadTarget => loadTarget;
    protected override void LoadComponent()
    {
        base.LoadComponent();
        this.LoadLoadTarget();
    }
    protected virtual void LoadLoadTarget()
    {
        if (this.loadTarget != null) return;
        this.loadTarget = GetComponentInChildren<LoadTarget>();
    }
    
}
