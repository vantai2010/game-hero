using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosiveEnemyFollowTarget : EnemyFollowTarget, IExplosiveSkillObserver
{
    [Header("Explosive Enemy Follow Target")]
    [SerializeField] protected ExplosiveEnemyCtrl explosiveEnemyCtrl;
    protected override void LoadComponent()
    {
        base.LoadComponent();
        this.LoadExplosiveEnemyCtrl();
    }
    protected virtual void LoadExplosiveEnemyCtrl()
    {
        if (this.explosiveEnemyCtrl != null) return;
        this.explosiveEnemyCtrl = transform.parent.GetComponent<ExplosiveEnemyCtrl>();
    }
    protected virtual void Start()
    {
        this.explosiveEnemyCtrl.ExplosiveSkill.AddObserver(this);
    }
    public void OnExplosiveActive()
    {
        transform.gameObject.SetActive(false);
    }

    public void OnExplosiveExist()
    {
        transform.gameObject.SetActive(true);
    }
}
