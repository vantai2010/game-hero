using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFollowTarget : FollowTarget
{
    [Header("Enemy Follow Target")]
    [SerializeField] protected EnemyCtrl enemyCtrl;
    protected override void ResetValue()
    {
        base.ResetValue();
        this.defaultSpeed = 0.5f;
        this.speed = this.defaultSpeed;
    }
    protected virtual void OnEnable() 
    {
        this.ChangeStatusEnemy();
    }
    protected override void LoadComponent()
    {
        base.LoadComponent();
        this.LoadEnemyCtrl();
    }
    protected override void FixedUpdate()
    {
        base.FixedUpdate();
        this.LoadTarget();
        this.ChangeLookDirection();
    }
    protected virtual void LoadEnemyCtrl()
    {
        if (this.enemyCtrl != null) return;
        this.enemyCtrl = transform.parent.GetComponent<EnemyCtrl>();
    }
    protected virtual void LoadTarget()
    {
        if (this.target != null) return;
        this.target = this.enemyCtrl.LoadTarget.Target;
    }
    protected virtual void ChangeStatusEnemy()
    {
        /*if(this.target == null)
        {
            //Debug.Log("chay vo target == null");
            this.enemyCtrl.AnimatorManager.SetCurrentStatusId(CharacterStatusId.Idle);
            return;
        }*/
        //Debug.Log("chay vo target != null");
        this.enemyCtrl.AnimatorManager.SetCurrentStatusId(CharacterStatusId.Walk);
    }

    protected virtual void ChangeLookDirection()
    {
        if (this.target == null) return;
        if(this.target.position.x > transform.parent.position.x)
        {
            transform.parent.localScale = new Vector3(1, 1, 1);
        }
        else
        {
            transform.parent.localScale = new Vector3(-1, 1, 1);
        }
    }
}
