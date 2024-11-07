using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloatingTextDespawn : DespawnByTime
{
    protected override void ResetValue()
    {
        base.ResetValue();
        this.timeLimit = 0.8f;
    }
    public override void DespawnObject()
    {
        FXSpawner.Instance.Despawn(transform.parent);
    }
}
