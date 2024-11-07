using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingMeteorCtrl : CustomBehavior
{
    [Header("Falling Meteor Ctrl")]
    [SerializeField] protected FallingMeteorDamageSender damageSender;
    [SerializeField] protected FollowTarget followTarget;
    [SerializeField] protected FallingMeteorDespawn fallingMeteorDespawn;
    public FollowTarget FollowTarget => followTarget;
    public FallingMeteorDamageSender DamageSender => damageSender;
    public FallingMeteorDespawn FallingMeteorDespawn => fallingMeteorDespawn;

    protected override void LoadComponent()
    {
        base.LoadComponent();
        this.LoadDamageSender();
        this.LoadFollowTarget();
        this.LoadFallingMeteorDespawn();
    }

    protected void LoadDamageSender()
    {
        if (this.damageSender != null) return;
        this.damageSender = GetComponentInChildren<FallingMeteorDamageSender>();
    }
    protected void LoadFollowTarget()
    {
        if (this.followTarget != null) return;
        this.followTarget = GetComponentInChildren<FollowTarget>();
    }
    protected void LoadFallingMeteorDespawn()
    {
        if (this.fallingMeteorDespawn != null) return;
        this.fallingMeteorDespawn = GetComponentInChildren<FallingMeteorDespawn>();
    }
}
