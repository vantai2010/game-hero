using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoisonBulletHandleTrigger : BulletHandleTrigger
{
    protected override void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Enemy") return;
        if (other.gameObject.name == BulletSpawner.PoisonBullet) return;
        if (other.gameObject.name == BulletSpawner.BulletOne) return;

        CharacterCtrl charCtrl = other.gameObject.GetComponent<CharacterCtrl>();
        if (charCtrl)
        {
            charCtrl.CharStatus.ChangeStatus(ObjStatus.IsPoisoned);
        }
        Transform newPoisonFx = FXSpawner.Instance.Spawn(FXSpawner.Poison, transform.position, transform.rotation);
        newPoisonFx.gameObject.SetActive(true);
        base.OnTriggerEnter2D(other);
    }
}
