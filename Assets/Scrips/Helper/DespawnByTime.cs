using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DespawnByTime : Despawn
{
    [Header("Despawn By Time")]
    [SerializeField] protected float timeLimit;
    [SerializeField] protected float timer;
    protected override void ResetValue()
    {
        base.ResetValue();
        this.timeLimit = 0.15f;
        this.timer = 0f;
    }
    protected virtual void OnEnable()
    {
        this.timer = 0f;
    }
    protected override bool CanDespawn()
    {
        this.timer += Time.fixedDeltaTime;
        if (this.timer < this.timeLimit) return false;
        return true;
    }
}
