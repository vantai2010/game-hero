using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FXDespawn : DespawnByTime
{
    
    protected override void ResetValue()
    {
        base.ResetValue();

        string path = "FX/" +  transform.parent.name;
        FXSO skillSO = Resources.Load<FXSO>(path);
        if (skillSO == null) return;
        this.timeLimit = skillSO.timeFinish;
    }
    public override void DespawnObject()
    {
        FXSpawner.Instance.Despawn(transform.parent);
    }
}
