using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloseUIGuideButton : BaseButton
{
    [Header("Close UIGuide Button")]
    [SerializeField] protected Transform uiGuide;

    protected override void LoadComponent()
    {
        base.LoadComponent();
        this.LoadUIGuide();
    }
    protected virtual void LoadUIGuide()
    {
        if (this.uiGuide != null) return;
        this.uiGuide = transform.parent;
    }
    protected override void OnClick()
    {
        this.uiGuide.gameObject.SetActive(false);
    }
}
