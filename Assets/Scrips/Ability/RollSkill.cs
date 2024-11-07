using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RollSkill : BaseAbility
{
    protected List<IRollSkillObserver> rollSkillObservers = new List<IRollSkillObserver>();
    [SerializeField] protected float activeTimeLimit;
    [SerializeField] protected float currActiveTime;
    [SerializeField] protected int damageRoll;
    protected bool isRolling;

    protected override void ResetValue()
    {
        base.ResetValue();
        this.isRolling = false;
        this.damageRoll = 20;
        this.delay = 12f;
        this.activeTimeLimit = 3f;
        this.currActiveTime = 0f;
    }
    protected override void FixedUpdate()
    {
        base.FixedUpdate();
        this.Rolling();
    }
    public virtual void AddObserver(IRollSkillObserver newObserver)
    {
        this.rollSkillObservers.Add(newObserver);
    }

    protected virtual void HandleObeseverRollSkillStart()
    {
        foreach(IRollSkillObserver observer in this.rollSkillObservers)
        {
            observer.RollSkillStart();
        }
    }

    protected virtual void HandleObeseverRollSkillEnd()
    {
        foreach (IRollSkillObserver observer in this.rollSkillObservers)
        {
            observer.RollSkillEnd();
        }
    }

    protected virtual void Rolling()
    {
        if (!this.isReady) return;
        this.Active();
        this.isRolling = true;
        this.HandleObeseverRollSkillStart();
        this.abilityCtrl.AbilityObjectCtrl.AnimatorManager.SetCurrentStatusId(CharacterStatusId.Roll);
        Invoke(nameof(this.RollEnd), this.activeTimeLimit);                                             

    }

    protected virtual void RollEnd()
    {
        this.abilityCtrl.AbilityObjectCtrl.AnimatorManager.SetCurrentStatusId(CharacterStatusId.Walk);
        this.HandleObeseverRollSkillEnd();
        this.isRolling = false;
    }

    public void OnCollisionWithRoll(Collision2D collision)
    {
        //if (!this.isRolling) return;

        DamageReceiver otherDamageReceiver = collision.gameObject.GetComponentInChildren<DamageReceiver>();
        if (otherDamageReceiver == null) return;

        otherDamageReceiver.Deduct(damageRoll);

        Transform newFX = FXSpawner.Instance.Spawn(FXSpawner.ImpactFX, collision.transform.position, collision.transform.rotation);
        newFX.gameObject.SetActive(true);
    }
}
