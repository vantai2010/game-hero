using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharStatus : CustomBehavior
{
    [Header("Char Status")]
    [SerializeField] protected ObjStatus currentStatus;
    [SerializeField] protected float timeExistPoison;
    [SerializeField] protected float timerPoison;
    public ObjStatus CurrentStatus => currentStatus;

    protected override void ResetValue()
    {
        base.ResetValue();
        this.currentStatus = ObjStatus.Normal;
        this.timeExistPoison = 3f;
    }

    protected virtual void Update()
    {
        this.CancelStatusIsPoisoned();
    }

    public void ChangeStatus(ObjStatus newStatus)
    {
        this.currentStatus = newStatus;
    }

    protected virtual void CancelStatusIsPoisoned()
    {
        if (this.currentStatus != ObjStatus.IsPoisoned) return;

        this.timerPoison += Time.deltaTime;
        if (this.timerPoison < this.timeExistPoison) return;
        this.timerPoison = 0f;

        this.currentStatus = ObjStatus.Normal;
    }

}

public enum ObjStatus
{
    Normal = 0,
    IsPoisoned = 1
}
