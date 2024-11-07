using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamFollowChar : FollowTarget
{
    [Header("Cam Follow Char")]
    [SerializeField] protected float minX = -9.99f; /*-21.1f*/
    [SerializeField] protected float maxX = 7.8f; /*18.89f*/
    [SerializeField] protected float minY = -13.9f; /*-19.09f*/
    [SerializeField] protected float maxY = 13.6f; /*18.7f*/

    protected override void ResetValue()
    {
        base.ResetValue();
        this.minX = -9.99f;
        this.maxX = 7.8f;
        this.minY = -13.9f;
        this.maxY = 13.6f;
    }
    protected override Vector3 GetNewPos()
    {
        Vector3 newPos = base.GetNewPos();

        newPos.x = Mathf.Clamp(newPos.x, minX, maxX);
        newPos.y = Mathf.Clamp(newPos.y, minY, maxY);

        return newPos;
    }

    /*[SerializeField] protected Transform target;
    [SerializeField] protected float speed = 2f;
    [SerializeField] protected float minX = -21.1f;
    [SerializeField] protected float maxX = 18.89f;
    [SerializeField] protected float minY = -19.09f;
    [SerializeField] protected float maxY = 18.7f;
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
        
        Vector3 newPos = Vector3.Lerp(transform.position, this.target.position, Time.fixedDeltaTime * speed);
        newPos.x = Mathf.Clamp(newPos.x, minX, maxX);
        newPos.y = Mathf.Clamp(newPos.y, minY, maxY);
        newPos.z = 0;
        transform.position = newPos;
        
    }*/

}
