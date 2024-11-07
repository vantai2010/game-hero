using System.Collections;
using System.Collections.Generic;
using UnityEditorInternal;
using UnityEngine;
using UnityEngine.UI;

public abstract class BaseButton : CustomBehavior
{
    [Header("Base Button")]
    [SerializeField] protected Button button;
    protected virtual void Start()
    {
        this.AddOnClickEvent();
    }
    protected override void LoadComponent()
    {
        base.LoadComponent();
        this.LoadButton();
    }
    protected virtual void LoadButton()
    {
        if (this.button != null) return;
        this.button = GetComponent<Button>();
    }
    protected virtual void AddOnClickEvent()
    {
        this.button.onClick.AddListener(this.OnClick);
    }
    protected abstract void OnClick();
}
