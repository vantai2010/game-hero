using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class LoadTarget : CustomBehavior
{
    [SerializeField] protected Transform target;
    public Transform Target => target;
    protected override void LoadComponent()
    {
        base.LoadComponent();
        this.LoadSelectTarget();
    }
    
    protected virtual void LoadSelectTarget()
    {
        if (this.target != null) return;
        this.target = Transform.FindAnyObjectByType<CharacterCtrl>().transform;
    }

    protected virtual void SetTarget(Transform target)
    {
        this.target = target;
    }
}
