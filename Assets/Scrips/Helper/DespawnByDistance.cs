using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DespawnByDistance : Despawn
{
    [Header("Despawn By Distance")]
    [SerializeField] protected Transform mainCamera;
    [SerializeField] protected float disLimit;
    [SerializeField] protected float distance;
    protected override void ResetValue()
    {
        base.ResetValue();
        this.disLimit = 30f;
    }
    protected override void LoadComponent()
    {
        base.LoadComponent();
        this.LoadMainCamera();
    }
    protected virtual void LoadMainCamera()
    {
        if (this.mainCamera != null) return;
        this.mainCamera = Transform.FindObjectOfType<Camera>().transform;
    }
    protected override bool CanDespawn()
    {
        this.distance = Vector3.Distance(this.mainCamera.position, transform.parent.position);
        if (this.distance > disLimit) return true;
        return false;
    }
}
