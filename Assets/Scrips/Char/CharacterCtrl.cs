using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterCtrl : ObjectHasAnimatorCtrl
{
    [Header("Character Ctrl")]
    [SerializeField] protected DamageReceiver damageReceiver;
    [SerializeField] protected CharStatus charStatus;
    public DamageReceiver DamageReceiver => damageReceiver;
    public CharStatus CharStatus => charStatus;
    
    protected override void LoadComponent()
    {
        base.LoadComponent();
        this.LoadDamageReceiver();
        this.LoadCharStatus();
    }
    protected virtual void LoadDamageReceiver()
    {
        if (this.damageReceiver != null) return;
        this.damageReceiver = GetComponentInChildren<DamageReceiver>();
    }

    protected virtual void LoadCharStatus()
    {
        if(this.charStatus != null) return;
        this.charStatus = GetComponentInChildren<CharStatus>();
    }
}
