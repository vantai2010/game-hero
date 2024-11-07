using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowTarget : CustomBehavior
{
    [SerializeField] protected Transform target;
    [SerializeField] protected float speed = 2f;
    protected float defaultSpeed;
    public Transform Target => target;
    public virtual void SetTarget(Transform target)
    {
        this.target = target;
    }
    protected virtual void FixedUpdate()
    {
        this.Following();
    }
    protected virtual void Following()
    {
        if (this.target == null) return;
        if (transform.parent == null)
        {

            Vector3 newPos = this.GetNewPos();
            transform.position = newPos;
        }
        else
        {
            Vector3 newPos = this.GetNewPos();
            transform.parent.position = newPos;
        }
        //transform.parent.localScale = target.transform.localScale;
    }

    protected virtual Vector3 GetNewPos()
    {
        Vector3 newPos = Vector3.Lerp(transform.position, this.target.position, Time.fixedDeltaTime * speed);
        newPos.z = 0;
        return newPos;
    }
}
