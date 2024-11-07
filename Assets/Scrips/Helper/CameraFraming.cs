using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFraming : CustomBehavior
{
    [Header("Camera Framing")]
    [SerializeField] protected Camera camera;
    [SerializeField] protected FollowTarget followTarget;
    [SerializeField] protected List<Vector3> listMapCornerPoint;

    protected override void LoadComponent()
    {
        base.LoadComponent();
        this.LoadCamera();
        this.LoadFollowTarget();
        this.LoadListMapCornerPoint();
    }
    protected virtual void LoadCamera()
    {
        if (this.camera != null) return;
        this.camera = Transform.FindAnyObjectByType<Camera>();
    }
    protected virtual void LoadFollowTarget()
    {
        if (this.followTarget != null) return;
        this.followTarget = transform.parent.GetComponent<FollowTarget>();
    }
    protected virtual void LoadListMapCornerPoint()
    {
        if (this.listMapCornerPoint.Count > 0) return;
        Transform obj = GameObject.Find("MapCornerPoints").transform;
        foreach(Transform point in obj)
        {
            this.listMapCornerPoint.Add(point.position);
        }
    }

    void Update()
    {
        this.CheckCornerCam();
    }

    protected virtual void CheckCornerCam()
    {
        bool camFollowChar = true;
        Vector3 topLeft = camera.ViewportToWorldPoint(new Vector3(0, 1, camera.nearClipPlane));
        Vector3 topRight = camera.ViewportToWorldPoint(new Vector3(1, 1, camera.nearClipPlane));
        Vector3 bottomLeft = camera.ViewportToWorldPoint(new Vector3(0, 0, camera.nearClipPlane));
        Vector3 bottomRight = camera.ViewportToWorldPoint(new Vector3(1, 0, camera.nearClipPlane));

        float epsilon = 0.0001f;
        if (
            Vector3.Distance(this.listMapCornerPoint[0], topLeft) < epsilon || Vector3.Distance(this.listMapCornerPoint[1], topRight) < epsilon ||
            Vector3.Distance(this.listMapCornerPoint[2], bottomLeft) < epsilon || Vector3.Distance(this.listMapCornerPoint[3], bottomRight) < epsilon
            )
        {
            camFollowChar = false;
        }
        else
        {
            camFollowChar = true;
        }

        followTarget.enabled = camFollowChar;
    }
}
