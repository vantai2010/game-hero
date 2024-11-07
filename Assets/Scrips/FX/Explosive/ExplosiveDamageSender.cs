using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CircleCollider2D))]
[RequireComponent(typeof(Rigidbody2D))]
public class ExplosiveDamageSender : DamageSender
{
    [SerializeField] protected FXCtrl fxCtrl;
    [SerializeField] protected CircleCollider2D circleCollider;
    [SerializeField] protected Rigidbody2D _rigidbody;
    protected override void ResetValue()
    {
        base.ResetValue();
        this.damage = 50;
    }
    protected override void LoadComponent()
    {
        base.LoadComponent();
        this.LoadFXCtrl();
        this.LoadCircleCollider2D();
        this.LoadRigidbody();
    }
    protected virtual void LoadFXCtrl()
    {
        if (this.fxCtrl != null) return;
        this.fxCtrl = transform.parent.GetComponent<FXCtrl>();
    }
    protected virtual void LoadCircleCollider2D()
    {
        if (this.circleCollider != null) return;
        this.circleCollider = GetComponent<CircleCollider2D>();

        if (this.circleCollider == null) return;
        this.circleCollider.isTrigger = true;
        this.circleCollider.radius = 0.9618334f;
        this.circleCollider.offset = new Vector2(0.08236027f, 0.1029502f);
    }
    protected virtual void LoadRigidbody()
    {
        if (this._rigidbody != null) return;
        this._rigidbody = GetComponent<Rigidbody2D>();

        if (this._rigidbody == null) return;
        this._rigidbody.isKinematic = true;
    }
    protected virtual void OnTriggerEnter2D(Collider2D other)
    {
        this.Send(other.transform);
        //this.fxCtrl.FXDespawn.DespawnObject();
    }
    /*protected override void CreateEffect()
    {
        Transform newImpactFX = FXSpawner.Instance.Spawn(FXSpawner.ImpactFX, transform.parent.position, transform.parent.rotation);
        newImpactFX.gameObject.SetActive(true);
    }*/

}
