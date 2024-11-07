using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CircleCollider2D))]
[RequireComponent(typeof(Rigidbody2D))]
public class LoadItemCircleCollider : CustomBehavior
{
    [Header("Load Item Circle Collider")]
    [SerializeField] protected CircleCollider2D circleCollider;
    [SerializeField] protected Rigidbody2D _rigidbody2D;
    protected ItemSO itemSO;

    protected override void LoadComponent()
    {
        base.LoadComponent();
        this.LoadSO();
        this.LoadCircleCollider2D();
        this.LoadRigidbody();
    }
    protected virtual void LoadSO()
    {

        string resPath = "Item/" + transform.name;
        this.itemSO = Resources.Load<ItemSO>(resPath);
    }
    
    protected virtual void LoadCircleCollider2D()
    {
        if (this.circleCollider != null) return;
        this.circleCollider = GetComponent<CircleCollider2D>();

        if (this.circleCollider == null || this.itemSO == null) return;
        this.circleCollider.isTrigger = true;
        this.circleCollider.radius = this.itemSO.circleColliderRadius;
        this.circleCollider.offset = this.itemSO.circleColliderOffset;
        this.circleCollider.isTrigger = true;
    }
    protected virtual void LoadRigidbody()
    {
        if (this._rigidbody2D != null) return;
        this._rigidbody2D = GetComponent<Rigidbody2D>();
        if (this._rigidbody2D == null) return;
        this._rigidbody2D.gravityScale = 0f;
    }
    
}
