using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(BoxCollider2D))]
public class CharacterLoadCollider : CustomBehavior
{
    [Header("Load Collider")]
    [SerializeField] protected Rigidbody2D _rigidbody;
    [SerializeField] protected BoxCollider2D boxCollider;
    public Rigidbody2D Rigidbody => _rigidbody;
    public BoxCollider2D BoxCollider => boxCollider;

    protected override void LoadComponent()
    {
        base.LoadComponent();
        this.LoadBoxCollier();
        this.LoadRigidbody();
    }

    
    protected virtual void LoadBoxCollier()
    {
        if (this.boxCollider != null) return;
        this.boxCollider = GetComponent<BoxCollider2D>();
        if (this.boxCollider == null) return;

        string resPath = "Character/" + transform.name;
        CharacterSO charSO = Resources.Load<CharacterSO>(resPath);
        this.boxCollider.offset = charSO.colliderOffset;
        this.boxCollider.size = charSO.colliderSize;

    }

    protected virtual void LoadRigidbody()
    {
        if (this._rigidbody != null) return;
        this._rigidbody = GetComponent<Rigidbody2D>();
        if (this._rigidbody == null) return;

        this._rigidbody.isKinematic = true;
        this._rigidbody.gravityScale = 0;
        this._rigidbody.freezeRotation = true;

    }
}
