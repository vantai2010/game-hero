using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIloggerCtrl : CustomBehavior
{
    [Header("UI logger Ctrl")]
    [SerializeField] protected PointText pointText;
    private static UIloggerCtrl _instance;
    public static UIloggerCtrl Instance => _instance;
    public PointText PointText => pointText;
    protected override void LoadComponent()
    {
        base.LoadComponent();
        this.LoadPointText();
    }

    protected override void Awake()
    {
        base.Awake();
        if (UIloggerCtrl._instance != null) Debug.LogError("Only One UIloggerCtrl allow to exists");
        UIloggerCtrl._instance = this;
        gameObject.SetActive(false);
    }

    protected virtual void LoadPointText()
    {
        if (this.pointText != null) return;
        this.pointText = GetComponentInChildren<PointText>();
    }
}
