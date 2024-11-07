using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ContinueButton : BaseButton
{
    [SerializeField] protected Transform uiMenu;

    protected override void LoadComponent()
    {
        base.LoadComponent();
        this.LoadUIMenu();
    }

    protected virtual void LoadUIMenu()
    {
        if (this.uiMenu != null) return;
        this.uiMenu = transform.parent;
    }

    protected override void OnClick()
    {
        this.uiMenu.gameObject.SetActive(false);
    }

    
}
