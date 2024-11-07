using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ObjectHasAnimatorAbstract : CustomBehavior
{
    [Header("Object Has Animator Abstract")]
    [SerializeField] protected ObjectHasAnimatorCtrl objCtrl;

    protected override void LoadComponent()
    {
        base.LoadComponent();
        this.LoadObjCtrl();
    }
    protected virtual void LoadObjCtrl()
    {
        if (this.objCtrl != null) return;
        this.objCtrl = transform.parent.GetComponent<ObjectHasAnimatorCtrl>();
    }
}
