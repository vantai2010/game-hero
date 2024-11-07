using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class CharacterAbstract : CustomBehavior
{
    [Header("Char Abstract")]
    [SerializeField] protected CharacterCtrl characterCtrl;
    protected override void LoadComponent()
    {
        base.LoadComponent();
        this.LoadCharCtrl();
    }
    protected virtual void LoadCharCtrl()
    {
        if (this.characterCtrl != null) return;
        this.characterCtrl = transform.parent.GetComponent<CharacterCtrl>();
    }
}
