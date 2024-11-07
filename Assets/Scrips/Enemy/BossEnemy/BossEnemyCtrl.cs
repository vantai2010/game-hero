using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossEnemyCtrl : EnemyCtrl
{
    [Header("Boss Enemy Ctrl")]
    [SerializeField] protected BossEnemyFollowTarget bossEnemyFollowTarget;
    [SerializeField] protected RollSkill rollSkill;
    [SerializeField] protected SummonMeteor summonMeteor;
    public RollSkill RollSkill => rollSkill;
    public BossEnemyFollowTarget BossEnemyFollowTarget => bossEnemyFollowTarget;
    public SummonMeteor SummonMeteor => summonMeteor;
    
    protected override void LoadComponent()
    {
        base.LoadComponent();
        this.LoadBossEnemyFollowTarget();
        this.LoadRollSkill();
        this.LoadSummonMeteor();
    }
    protected virtual void LoadBossEnemyFollowTarget()
    {
        if (this.bossEnemyFollowTarget != null) return;
        this.bossEnemyFollowTarget = GetComponentInChildren<BossEnemyFollowTarget>();
    }
    protected virtual void LoadRollSkill()
    {
        if (this.rollSkill != null) return;
        this.rollSkill = GetComponentInChildren<RollSkill>();
    }
    protected virtual void LoadSummonMeteor()
    {
        if (this.summonMeteor != null) return;
        this.summonMeteor = GetComponentInChildren<SummonMeteor>();
    }
}
