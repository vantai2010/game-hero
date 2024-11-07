using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootWeapon : WeaponAbstract
{
    [Header("Shoot Weapon")]
    [SerializeField] protected bool isShoot;
    [SerializeField] protected float timer;
    [SerializeField] protected float timeLimit;

    protected override void ResetValue()
    {
        base.ResetValue();
        this.timer = 0.2f;
        this.timeLimit = 0.2f;
    }
    protected virtual void Update()
    {
        this.Shooting();
    }
    protected virtual bool CanShoot()
    {
        return InputManager.Instance.OnFiring == 1;
    }
    protected virtual void Shooting()
    {
        if (!this.CanShoot()) return;
        this.timer += Time.deltaTime;
        if (this.timer < this.timeLimit) return;
        this.timer = 0f;

        this.CreateFXShooting();
        this.CreateBullet();
    }
    protected virtual void CreateFXShooting()
    {
        Transform barrelPoint = this.weaponCtrl.BarrelPoint;
        Transform newMuzzle = FXSpawner.Instance.Spawn(FXSpawner.Muzzle, barrelPoint.position, barrelPoint.rotation);
        newMuzzle.gameObject.SetActive(true);
    }
    protected virtual void CreateBullet()
    {
        List<Transform> listShootPoints = this.weaponCtrl.ListShootPoints;
        foreach (Transform shootPoint in listShootPoints)
        {
            Transform newBullet = BulletSpawner.Instance.Spawn(BulletSpawner.BulletOne, shootPoint.position, shootPoint.rotation);
            BulletCtrl newBulletCtrl = newBullet.GetComponent<BulletCtrl>();
            newBulletCtrl.CheckShootBy.SetNameWeapon(transform.parent.gameObject.name.ToString());
            newBullet.gameObject.SetActive(true);
        }
    }
}
