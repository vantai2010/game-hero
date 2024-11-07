using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjFalling : MonoBehaviour
{
    [SerializeField] protected Transform startPoint;
    [SerializeField] protected Transform endPoint;

    public void SetStartPoint(Transform startPoint)
    {
        this.startPoint = startPoint;
    }
    public void SetEndPoint(Transform endPoint)
    {
        this.endPoint = endPoint;
    }

    protected virtual void FixedUpdate()
    {
        this.Falling();
    }

    protected void Falling()
    {

    }
}
