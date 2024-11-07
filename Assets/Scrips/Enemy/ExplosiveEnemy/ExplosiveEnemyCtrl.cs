using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosiveEnemyCtrl : EnemyCtrl
{
    [Header("Explosive Enemy Ctrl")]
    [SerializeField] protected ExplosiveEnemyFollowTarget explosiveEnemyFollowTarget;
    [SerializeField] protected ExplosiveSkill explosiveSkill;
    public ExplosiveEnemyFollowTarget ExplosiveEnemyFollowTarget => explosiveEnemyFollowTarget;
    public ExplosiveSkill ExplosiveSkill => explosiveSkill;
    protected override void LoadComponent()
    {
        base.LoadComponent();
        this.LoadExplosiveEnemyFollowTarget();
        this.LoadExplosiveSkill();
    }
    protected virtual void LoadExplosiveEnemyFollowTarget()
    {
        if (this.explosiveEnemyFollowTarget != null) return;
        this.explosiveEnemyFollowTarget = GetComponentInChildren<ExplosiveEnemyFollowTarget>();
    }
    protected virtual void LoadExplosiveSkill()
    {
        if (this.explosiveSkill != null) return;
        this.explosiveSkill = GetComponentInChildren<ExplosiveSkill>();
    }
}
