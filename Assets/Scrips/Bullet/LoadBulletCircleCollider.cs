using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CircleCollider2D))]
[RequireComponent(typeof(Rigidbody2D))]
public class LoadBulletCircleCollider : CustomBehavior
{
    [Header("Load Bullet Circle Collider")]
    [SerializeField] protected CircleCollider2D circleCollider;
    [SerializeField] protected Rigidbody2D _rigidbody;
    protected BulletSO bulletSO;

    protected override void LoadComponent()
    {
        base.LoadComponent();
        this.LoadSO();
        this.LoadCircleCollider2D();
        this.LoadRigidbody();
    }
    protected virtual void LoadSO()
    {

        string resPath = "Bullet/" + transform.name;
        bulletSO = Resources.Load<BulletSO>(resPath);
    }
    
    protected virtual void LoadCircleCollider2D()
    {
        if (this.circleCollider != null) return;
        this.circleCollider = GetComponent<CircleCollider2D>();

        if (this.circleCollider == null || this.bulletSO == null) return;
        this.circleCollider.isTrigger = true;
        this.circleCollider.radius = this.bulletSO.circleColliderRadius;
        this.circleCollider.offset = this.bulletSO.circleColliderOffset;
    }
    protected virtual void LoadRigidbody()
    {
        if (this._rigidbody != null) return;
        this._rigidbody = GetComponent<Rigidbody2D>();

        if (this._rigidbody == null) return;
        //this._rigidbody.isKinematic = true;
        this._rigidbody.gravityScale = 0f;
    }
    
}
