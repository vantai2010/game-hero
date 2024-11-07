using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationText : CustomBehavior
{
    [Header("Animation Text")]
    [SerializeField] protected FloatingTextCtrl floatingTextCtrl;
    [SerializeField] protected AnimationCurve opacityCurve;
    [SerializeField] protected AnimationCurve heightCurve;
    [SerializeField] protected AnimationCurve horizontalCurve;
    [SerializeField] protected float time = 0f;
    [SerializeField] protected Vector3 originPos;

    protected virtual void OnEnable()
    {
        this.originPos = transform.parent.position;
    }

    protected override void LoadComponent()
    {
        base.LoadComponent();
        this.LoadFloatingTextCtrl();
    }

    protected virtual void LoadFloatingTextCtrl()
    {
        if (this.floatingTextCtrl != null) return;
        this.floatingTextCtrl = transform.parent.GetComponent<FloatingTextCtrl>();
    }

    protected virtual void Update()
    {
        this.AnimationOpacity();
        this.AnimationPosition();
        this.time += Time.deltaTime;
        
    }

    protected virtual void AnimationOpacity()
    {
        Color currentColor = this.floatingTextCtrl.Text.color;
        currentColor.a = opacityCurve.Evaluate(this.time);

        this.floatingTextCtrl.Text.color = currentColor;

    }

    protected virtual void AnimationPosition()
    {
        transform.parent.position = originPos + new Vector3(horizontalCurve.Evaluate(this.time), heightCurve.Evaluate(this.time), 0);
    }
}
