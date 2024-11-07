using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundScrolling : CustomBehavior
{
    [Header("Back ground Scrolling")]
    [SerializeField] protected BackgroundCtrl backgroundCtrl;
    [SerializeField] protected float speed;
    [SerializeField] protected Vector3 direction;

    protected override void ResetValue()
    {
        base.ResetValue();
        this.speed = 1f;
        this.direction = Vector3.right;
    }
    protected override void LoadComponent()
    {
        base.LoadComponent();
        this.LoadBackgroundCtrl();
    }

    protected virtual void LoadBackgroundCtrl()
    {
        if (this.backgroundCtrl != null) return;
        this.backgroundCtrl = transform.parent.GetComponent<BackgroundCtrl>();
    }
    
    protected virtual void Update()
    {
        this.UpdateDirection();
        this.Scrolling();
    }

    protected virtual void UpdateDirection()
    {
        if(this.backgroundCtrl.Model.position.x < this.backgroundCtrl.StartScroll.position.x)
        {
            this.direction = Vector3.right;
        }else if(this.backgroundCtrl.Model.position.x > this.backgroundCtrl.EndScroll.position.x)
        {
            this.direction = Vector3.left;
        }
    }

    protected virtual void Scrolling()
    {
        transform.parent.Translate(this.direction * this.speed * Time.deltaTime);
    }
}
