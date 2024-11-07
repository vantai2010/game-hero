using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuButton : BaseButton
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
        this.uiMenu = GameObject.Find("UICenter").transform;
    }
    protected override void OnClick()
    {
        this.uiMenu.gameObject.SetActive(true);
    }

}
