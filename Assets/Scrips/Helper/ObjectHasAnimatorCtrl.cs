using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectHasAnimatorCtrl : CustomBehavior
{
    [Header("Object Has Animator Ctrl")]
    [SerializeField] protected Animator animator;
    [SerializeField] protected AnimatorManager animatorManager;
    public Animator Animator => animator;
    public AnimatorManager AnimatorManager => animatorManager;
    protected override void LoadComponent()
    {
        base.LoadComponent();
        this.LoadAnimator();
        this.LoadAnimatorManager();

    }
    protected virtual void LoadAnimator()
    {
        if (this.animator != null) return;
        this.animator = transform.Find("Model").GetComponent<Animator>();
    }
    protected virtual void LoadAnimatorManager()
    {
        if (this.animatorManager != null) return;
        this.animatorManager = GetComponentInChildren<AnimatorManager>();
    }
}
