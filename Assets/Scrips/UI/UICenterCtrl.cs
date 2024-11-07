using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UICenterCtrl : CustomBehavior
{
    protected override void Awake()
    {
        base.Awake();
        this.gameObject.SetActive(false);
    }
}
