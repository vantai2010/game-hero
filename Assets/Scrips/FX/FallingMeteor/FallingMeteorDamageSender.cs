using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

[RequireComponent(typeof(CircleCollider2D))]
/*[RequireComponent(typeof(Rigidbody2D))]*/
public class FallingMeteorDamageSender : DamageSender
{
    [Header("Falling Meteor DamageSender")]
    [SerializeField] protected FallingMeteorCtrl fallingMeteorCtrl;
    [SerializeField] protected CircleCollider2D circleCollider2D;
    [SerializeField] protected Rigidbody2D _rigidbody;
    //[SerializeField] protected bool isEnableCollision;
    public Rigidbody2D Rigidbody => _rigidbody;
    protected override void ResetValue()
    {
        base.ResetValue();
        this.damage = 100;
    }
    protected override void LoadComponent()
    {
        base.LoadComponent();
        this.LoadFallingMeteorCtrl();
        this.LoadCircleCollider();
        this.LoadRigidBody();
    }
    /*protected virtual void FixedUpdate()
    {
        this.CheckEnableImpact();
    }*/

    protected void LoadFallingMeteorCtrl()
    {
        if (this.fallingMeteorCtrl != null) return;
        this.fallingMeteorCtrl = transform.parent.GetComponent<FallingMeteorCtrl>();
    }
    protected void LoadCircleCollider()
    {
        if (this.circleCollider2D != null) return;
        this.circleCollider2D = transform.GetComponent<CircleCollider2D>();
        if (this.circleCollider2D == null) return;
        this.circleCollider2D.offset = new Vector2(0.01831508f, 0.03253853f);
        this.circleCollider2D.radius = 1.120147f;
        this.circleCollider2D.isTrigger = true;
    }
    protected void LoadRigidBody()
    {
        if (this._rigidbody != null) return;
        this._rigidbody = transform.GetComponent<Rigidbody2D>();
        if (this._rigidbody == null) return;
        this._rigidbody.gravityScale = 0f;
        this._rigidbody.freezeRotation = true;
    }

    /*protected virtual void CheckEnableImpact()
    {
        Transform positionTarget = this.GetPositionTarget();
        if (positionTarget == null) return;
        float disEnable = 1f;
        float disToEndPoint = Vector3.Distance(positionTarget.position, transform.parent.position);
      
        this.isEnableCollision =  disToEndPoint <= disEnable ? true : false;
    }
    protected virtual Transform GetPositionTarget()
    {
        return this.fallingMeteorCtrl.FollowTarget.Target;
    }*/

    /*protected virtual void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("1234" + collision.gameObject.name);
        if (!this.isEnableCollision) return;
        this.Send(collision.transform);
    }*/

    protected virtual void OnTriggerEnter2D(Collider2D other)
    {
        /*if (!this.isEnableCollision) return;*/
        if (other.transform.tag == "Enemy") return;
        this.Send(other.transform);
    }
}
