using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallSpawnPoint : CustomBehavior
{
    [SerializeField] protected List<Transform> listFallPoints;

    protected override void LoadComponent()
    {
        base.LoadComponent();
        this.LoadListPoints();
    }

    protected virtual void LoadListPoints()
    {
        if (this.listFallPoints.Count > 0) return;
        foreach(Transform point in transform)
        {
            this.listFallPoints.Add(point);
        }
    }
}
