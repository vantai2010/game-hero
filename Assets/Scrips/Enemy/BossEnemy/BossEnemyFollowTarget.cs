using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossEnemyFollowTarget : EnemyFollowTarget, IRollSkillObserver, ISummonMeteorSkillObserver
{
    [Header("Boss Enemy Follow Target")]
    [SerializeField] protected BossEnemyCtrl bossEnemyCtrl;
    
    protected override void LoadComponent()
    {
        base.LoadComponent();
        this.LoadBossEnenmyCtrl();
    }

    protected virtual void LoadBossEnenmyCtrl()
    {
        if (this.bossEnemyCtrl != null) return;
        this.bossEnemyCtrl = transform.parent.GetComponent<BossEnemyCtrl>();
    }

    protected void Start()
    {
        this.bossEnemyCtrl.RollSkill.AddObserver(this);
        this.bossEnemyCtrl.SummonMeteor.AddObserver(this);
    }
    
    public void RollSkillEnd()
    {
        this.speed = this.defaultSpeed;
    }

    public void RollSkillStart()
    {
        this.speed = this.defaultSpeed * 2f + this.defaultSpeed;
    }

    public void OnSummonMeteorSkillStart()
    {
        transform.gameObject.SetActive(false);
    }

    public void OnSummonMeteorSkillEnd()
    {
        transform.gameObject.SetActive(true);
    }
}
