using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCtrl : AbilityObjectCtrl
{
    [Header("Enemy ctrl")]
    [SerializeField] protected EnemyDespawn enemyDespawn;
    [SerializeField] protected EnemyFollowTarget enemyFollowTarget;
    [SerializeField] protected BoxCollider2D boxCollider;
    public EnemyDespawn EnemyDespawn => enemyDespawn;
    public EnemyFollowTarget EnemyFollowTarget => enemyFollowTarget;
    public BoxCollider2D BoxCollider => boxCollider;
    protected override void LoadComponent()
    {
        base.LoadComponent();
        this.LoadEnemyDespawn();
        this.LoadEnenmyFollowTarget();
    }
    protected virtual void LoadEnemyDespawn()
    {
        if (this.enemyDespawn != null) return;
        this.enemyDespawn = GetComponentInChildren<EnemyDespawn>();
    }
    protected virtual void LoadEnenmyFollowTarget()
    {
        if (this.enemyFollowTarget != null) return;
        this.enemyFollowTarget = GetComponentInChildren<EnemyFollowTarget>();
    }
}
