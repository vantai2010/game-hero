using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class LookAtMouse : WeaponAbstract
{
    protected virtual void FixedUpdate()
    {
        this.Looking();
    }
    protected virtual void Looking()
    {
        Vector3 direction = InputManager.Instance.MousePosition - transform.parent.position;
        direction.z = 0;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

        transform.parent.rotation = Quaternion.Euler(new Vector3(0, 0, angle));

        if(transform.parent.eulerAngles.z > 90 &&  transform.parent.eulerAngles.z < 270)
        {
            transform.parent.localScale = new Vector3(1, -1, 1);
            this.weaponCtrl.FollowTarget.Target.transform.localScale = new Vector3(-1, 1, 1);
        }
        else
        {
            transform.parent.localScale = new Vector3(1, 1, 1);
            this.weaponCtrl.FollowTarget.Target.transform.localScale = new Vector3(1, 1, 1);
        }
    }
}
