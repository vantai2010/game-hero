using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundCtrl : CustomBehavior
{
    [Header("Back ground Ctrl")]
    [SerializeField] protected Transform model;
    [SerializeField] protected Transform startScroll;
    [SerializeField] protected Transform endScroll;
    public Transform Model => model;
    public Transform StartScroll => startScroll;
    public Transform EndScroll => endScroll;

    protected override void LoadComponent()
    {
        base.LoadComponent();
        this.LoadModel();
        this.LoadStartScroll();
        this.LoadEndScroll();
    }

    protected virtual void LoadModel()
    {
        if (this.model != null) return;
        this.model = transform.Find("Model").transform;
    }

    protected virtual void LoadStartScroll()
    {
        if(this.startScroll != null) return;
        this.startScroll = GameObject.Find("StartScroll").transform;
    }

    protected virtual void LoadEndScroll()
    {
        if (this.endScroll != null) return;
        this.endScroll = GameObject.Find("EndScroll").transform;
    }
}
