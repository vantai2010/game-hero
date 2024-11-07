using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosiveSkill : BaseAbility
{
    [Header("Explosive Skill")]
    [SerializeField] protected EnemyDespawn enemyDespawn;
    [SerializeField] protected float disLimit;
    [SerializeField] protected List<IExplosiveSkillObserver> observers = new List<IExplosiveSkillObserver>();
    protected override void ResetValue()
    {
        base.ResetValue();
        this.disLimit = 1.5f;
    }
    protected override void LoadComponent()
    {
        base.LoadComponent();
        this.LoadEnemyDespawn();
    }
    protected virtual void LoadEnemyDespawn()
    {
        if (this.enemyDespawn != null) return;
        this.enemyDespawn = transform.parent.parent.GetComponentInChildren<EnemyDespawn>();
    }
    protected override void FixedUpdate()
    {
        base.FixedUpdate();
        this.Explosiving();
    }

    public virtual void AddObserver(IExplosiveSkillObserver observer)
    {
        observers.Add(observer);
    }

    protected virtual void OnActiveSkill()
    {
        foreach(IExplosiveSkillObserver observer in this.observers)
        {
            observer.OnExplosiveActive();
        }
    }
    protected virtual void OnExistSkill()
    {
        foreach (IExplosiveSkillObserver observer in this.observers)
        {
            observer.OnExplosiveExist();
        }
    }

    protected virtual void Explosiving()
    {
        if (!this.isReady) return;
        if (!this.CanActive()) return;

        this.OnActiveSkill();
        this.abilityCtrl.AbilityObjectCtrl.AnimatorManager.SetCurrentStatusId(CharacterStatusId.Hit);

        this.Active();

        Invoke(nameof(this.PhaseTwoExplosiving), this.abilityCtrl.AbilityObjectCtrl.AnimatorManager.GetTimeFinishCurrentAnimation());
    }
    protected virtual void PhaseTwoExplosiving()
    {
        Transform newFX = FXSpawner.Instance.Spawn(FXSpawner.Explosive, transform.parent.parent.position, transform.parent.parent.rotation);
        newFX.gameObject.SetActive(true);

        //this.enemyDespawn.DespawnObject();
        this.OnExistSkill();
    }
    
    protected virtual bool CanActive()
    {
        Vector3 posTarget = this.abilityCtrl.AbilityObjectCtrl.LoadTarget.Target.position;
        posTarget.z = 0;
        float currentDistanceToTarget = Vector3.Distance(posTarget, transform.parent.parent.position);
        if (currentDistanceToTarget > this.disLimit) return false;
        return true;
    }
}
