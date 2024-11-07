using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenUIGuideButton : BaseButton
{
    [Header("Open UIGuide Button")]
    [SerializeField] protected Transform uiGuide;

    protected override void LoadComponent()
    {
        base.LoadComponent();
        this.LoadUIGuide();
    }
    protected virtual void LoadUIGuide()
    {
        if (this.uiGuide != null) return;
        this.uiGuide = GameObject.Find("UIGuide").transform;
    }
    protected override void OnClick()
    {
        this.uiGuide.gameObject.SetActive(true);
    }
}
