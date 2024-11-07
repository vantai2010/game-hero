using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawnPoint : CustomBehavior
{
    [Header("Enemy Spawn Point")]
    [SerializeField] protected List<Transform> listSpawnPoints;

    protected override void LoadComponent()
    {
        base.LoadComponent();
        this.LoadListSpawnPoints();
    }
    protected virtual void LoadListSpawnPoints()
    {
        if (this.listSpawnPoints.Count > 0) return;
        foreach(Transform point in transform)
        {
            this.listSpawnPoints.Add(point);
        }
    }

    public virtual Transform GetRandomPoint()
    {
        int randomIndex = Random.Range(0, this.listSpawnPoints.Count);
        return this.listSpawnPoints[randomIndex];
    }
}
