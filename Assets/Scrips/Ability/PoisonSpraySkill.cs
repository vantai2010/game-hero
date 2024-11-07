using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoisonSpraySkill : BaseAbility
{
    [Header("Poison Spray Skill")]
    [SerializeField] protected float disLimit;

    protected override void ResetValue()
    {
        base.ResetValue();
        this.disLimit = 5f;
        this.delay = 2f;
    }

    protected override void FixedUpdate()
    {
        base.FixedUpdate();
        this.Spraying();
    }

    protected void Spraying()
    {
        if (!this.isReady) return;
        if (!this.CanSpraying()) return;

        this.AbilitiesCtrl.AbilityObjectCtrl.AnimatorManager.SetPressingStatusId(CharacterStatusId.Hit);
        float timeFinishAni = this.AbilitiesCtrl.AbilityObjectCtrl.AnimatorManager.GetTimeFinishCurrentAnimation();

        Invoke(nameof(this.PhaseTwoOfSpraying), timeFinishAni);

        
        this.Active();
    }

    protected void PhaseTwoOfSpraying()
    {
        Transform newPoisonBullet = BulletSpawner.Instance.Spawn(BulletSpawner.PoisonBullet, transform.parent.parent.position, transform.parent.parent.rotation);
        newPoisonBullet.gameObject.SetActive(true);

        this.AbilitiesCtrl.AbilityObjectCtrl.AnimatorManager.SetPressingStatusId(CharacterStatusId.None);
    }

    protected bool CanSpraying()
    {
        Transform target = this.abilityCtrl.AbilityObjectCtrl.LoadTarget.Target;
        float dis = Vector3.Distance(target.position, transform.parent.position);
        return dis <= this.disLimit;
    }
}
