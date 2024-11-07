using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossEnenmyHandleTrigger : CustomBehavior
{
    [SerializeField] protected RollSkill rollSkill;
    protected override void LoadComponent()
    {
        base.LoadComponent();
        this.LoadRollSkill();
    }

    protected virtual void LoadRollSkill()
    {
        if (this.rollSkill != null) return;
        this.rollSkill = GetComponentInChildren<RollSkill>();
    }

    protected virtual void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("day chay onCollisionEnter" + collision.gameObject.name);
        this.rollSkill.OnCollisionWithRoll(collision);
    }
}
