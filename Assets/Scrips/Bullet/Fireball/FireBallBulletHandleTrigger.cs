using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireBallBulletHandleTrigger : BulletHandleTrigger
{
    protected override void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Enemy") return;
        if (other.gameObject.name == BulletSpawner.Fireball) return;
        if (other.gameObject.name == BulletSpawner.BulletOne) return;

        base.OnTriggerEnter2D(other);
    }
}
