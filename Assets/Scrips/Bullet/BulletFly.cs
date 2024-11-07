using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletFly : CustomBehavior
{
    [SerializeField] protected Vector3 direction;
    [SerializeField] protected float speed;
    protected override void ResetValue()
    {
        base.ResetValue();
        this.direction = Vector3.right;
        this.speed = 6f;
    }
    protected virtual void Update()
    {
        this.Flying();
    }
    protected virtual void Flying()
    {
        transform.parent.Translate(this.direction * this.speed * Time.deltaTime); 
    }
}
