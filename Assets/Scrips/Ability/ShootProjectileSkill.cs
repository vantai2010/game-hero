using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootProjectileSkill : BaseAbility
{
    [Header("Shoot Projectile Skill")]
    [SerializeField] protected Transform shootPoint;
    protected List<IShootProjectileSkillObserver> shootProjectileSkillObservers = new List<IShootProjectileSkillObserver> ();

    protected override void ResetValue()
    {
        base.ResetValue();
        this.timer = 0f;
        this.delay = 2f; 
    }
    protected override void LoadComponent()
    {
        base.LoadComponent();
        this.LoadShootpoint();
    }
    protected virtual void LoadShootpoint()
    {
        if (this.shootPoint != null) return;
        this.shootPoint = transform.parent.parent.Find("ShootPoint");
    }
    protected override void FixedUpdate()
    {
        base.FixedUpdate();
        this.Shooting();
    }
    public void AddObserver(IShootProjectileSkillObserver observer)
    {
        this.shootProjectileSkillObservers.Add(observer);
    }
    protected void HandleObserverOnShootProjectileSkillStart()
    {
        foreach(IShootProjectileSkillObserver observer in this.shootProjectileSkillObservers)
        {
            observer.OnShootProjectileSkillStart();
        }
    }
    protected void HandleObserverOnShootProjectileSkillEnd()
    {
        foreach (IShootProjectileSkillObserver observer in this.shootProjectileSkillObservers)
        {
            observer.OnShootProjectileSkillEnd();
        }
    }

    protected void Shooting()
    {
        if (!this.isReady) return;

        this.HandleObserverOnShootProjectileSkillStart();

        float angle = this.GetOffsetAngle();

        Transform newFireball = BulletSpawner.Instance.Spawn(BulletSpawner.Fireball, this.shootPoint.position, this.shootPoint.rotation);
        newFireball.rotation = Quaternion.Euler(new Vector3(0, 0, angle));
        newFireball.gameObject.SetActive(true);

        this.HandleObserverOnShootProjectileSkillEnd();
        this.Active();
    }

    protected float GetOffsetAngle()
    {
        Transform target = this.AbilitiesCtrl.AbilityObjectCtrl.LoadTarget.Target;

        Vector2 direction = (transform.position - target.position).normalized;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;


        if (target.position.x > transform.position.x && target.position.y > transform.position.y) return angle + 180;
        if(target.position.x > transform.position.x && target.position.y < transform.position.y) return angle + 180;
        if(target.position.x < transform.position.x && target.position.y > transform.position.y) return angle + 135;
        if(target.position.x < transform.position.x && target.position.y < transform.position.y) return angle + 180;
        return angle;
    }
}
