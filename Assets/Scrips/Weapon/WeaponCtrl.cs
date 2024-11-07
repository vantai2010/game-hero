using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponCtrl : CustomBehavior
{
    [Header("Weapon Ctrl")]
    [SerializeField] protected Transform barrelPoint;
    [SerializeField] protected List<Transform> listShootPoints;
    [SerializeField] protected FollowTarget followTarget;
    public FollowTarget FollowTarget => followTarget;
    public Transform BarrelPoint => barrelPoint;
    public List<Transform> ListShootPoints => listShootPoints;
    protected override void LoadComponent()
    {
        base.LoadComponent();
        this.LoadListShootPoint();
        this.LoadBarrelPoint();
        this.LoadFollowTarget();
    }
    protected virtual void LoadListShootPoint()
    {
        if (this.listShootPoints.Count > 0) return;
        Transform shootPoints = transform.Find("ListShootPoints");
        foreach(Transform shootPoint in shootPoints)
        {
            this.listShootPoints.Add(shootPoint);
        }
    }
    protected virtual void LoadBarrelPoint()
    {
        if (this.barrelPoint != null) return;
        this.barrelPoint = transform.Find("BarrelPoint");
    }
    protected virtual void LoadFollowTarget()
    {
        if (this.followTarget != null) return;
        this.followTarget = GetComponentInChildren<FollowTarget>();
    }
}
