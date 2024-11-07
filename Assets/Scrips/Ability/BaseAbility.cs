using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseAbility : CustomBehavior
{
    [Header("Base ability")]
    [SerializeField] protected AbilityCtrl abilityCtrl;
    [SerializeField] protected float timer;
    [SerializeField] protected float delay;
    [SerializeField] protected bool isReady;
    public AbilityCtrl AbilitiesCtrl => abilityCtrl;
    protected override void LoadComponent()
    {
        base.LoadComponent();
        this.LoadAbilityCtrl();
    }
    protected virtual void LoadAbilityCtrl()
    {
        this.abilityCtrl = transform.parent.GetComponent<AbilityCtrl>();
    }
    protected override void ResetValue()
    {
        base.ResetValue();
        this.timer = 0f;
        this.delay = 2f;
        this.isReady = false;
    }
    protected virtual void FixedUpdate()
    {
        this.Timing();
    }
    protected virtual void Timing()
    {
        if (this.isReady) return;
        this.timer += Time.fixedDeltaTime;
        if (this.timer < this.delay) return;
        this.isReady = true;
    }
    protected virtual void Active()
    {
        this.isReady = false;
        this.timer = 0;
    }
}
