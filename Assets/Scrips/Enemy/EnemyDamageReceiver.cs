using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDamageReceiver : DamageReceiver
{
    [Header("Enemy Damage Receiver")]
    [SerializeField] protected EnemyCtrl enemyCtrl;

    protected override void LoadComponent()
    {
        base.LoadComponent();
        this.LoadEnemyCtrl();
        this.LoadDataObj();
    }

    protected virtual void LoadDataObj()
    {
        string resPath = "Enemy/" + transform.parent.name;
        EnemySO enemySO = Resources.Load<EnemySO>(resPath);
        this.maxHp = enemySO.hp;
    }
    
    protected virtual void LoadEnemyCtrl()
    {
        if (this.enemyCtrl != null) return;
        this.enemyCtrl = transform.parent.GetComponent<EnemyCtrl>();
    }
    protected override void OnDead()
    {
        this.ChangeStatusObj();
        this.DespawnObject();
    }
    protected virtual void ChangeStatusObj()
    {
        this.enemyCtrl.AnimatorManager.SetCurrentStatusId(CharacterStatusId.Death);
    }
    protected virtual void DespawnObject()
    {
        float timeFinishAnimation = this.enemyCtrl.AnimatorManager.GetTimeFinishCurrentAnimation();
        Invoke(nameof(HandleDespawnObject), timeFinishAnimation);
    }
    protected virtual void HandleDespawnObject()
    {
        this.enemyCtrl.EnemyDespawn.DespawnObject();
    }
    
}
