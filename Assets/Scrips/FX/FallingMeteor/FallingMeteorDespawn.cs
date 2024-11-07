using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingMeteorDespawn : CustomBehavior
{
    [SerializeField] protected FallingMeteorCtrl fallingMeteorCtrl;
    protected float minDistanceToDespawn;

    protected override void ResetValue()
    {
        base.ResetValue();
        this.minDistanceToDespawn = 0.1f;
    }
    protected override void LoadComponent()
    {
        base.LoadComponent();
        this.LoadFollowTarget();
    }

    protected virtual void LoadFollowTarget()
    {
        if (this.fallingMeteorCtrl != null) return;
        this.fallingMeteorCtrl = transform.parent.GetComponent<FallingMeteorCtrl>();
    }

    protected virtual void Update()
    {
        this.DespawnFX();
    }

    protected void DespawnFX()
    {
        if (!this.CanDespawn()) return;
        FXSpawner.Instance.Despawn(transform.parent);
        Transform newSmokeTrail = FXSpawner.Instance.Spawn(FXSpawner.SmokeTrail, transform.parent.position, transform.parent.rotation);
        newSmokeTrail.gameObject.SetActive(true);
    }

    public bool CanDespawn()
    {
        Vector3 endPointPosition = this.fallingMeteorCtrl.FollowTarget.Target.position;
        float distanceToFallPoint = Vector3.Distance(endPointPosition, transform.parent.position);

        return distanceToFallPoint < this.minDistanceToDespawn;
    }
}
