using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterDamageReceiver : DamageReceiver
{
    [Header("Character Damage Receiver")]
    [SerializeField] protected CharacterCtrl charCtrl;
    [SerializeField] protected float timer;
    [SerializeField] protected float poisonDamageDuration;
    [SerializeField] protected int damagePoison;
    protected override void ResetValue()
    {
        base.ResetValue();
        this.timer = 0f;
        this.poisonDamageDuration = 0.5f;
        this.damagePoison = 5;
    }
    protected override void LoadComponent()
    {
        base.LoadComponent();
        this.LoadEnemyCtrl();
        this.LoadDataObj();
    }

    protected virtual void LoadDataObj()
    {
        string resPath = "Character/" + transform.parent.name;
        CharacterSO charSO = Resources.Load<CharacterSO>(resPath);
        this.maxHp = charSO.hp;
    }
    
    protected virtual void LoadEnemyCtrl()
    {
        if (this.charCtrl != null) return;
        this.charCtrl = transform.parent.GetComponent<CharacterCtrl>();
    }

    protected virtual void Update()
    {
        this.PoisonDamageReceiver();
    }

    protected virtual void PoisonDamageReceiver()
    {
        if (this.charCtrl.CharStatus.CurrentStatus != ObjStatus.IsPoisoned) return;

        this.timer += Time.deltaTime;
        if (this.timer < this.poisonDamageDuration) return;
        this.timer = 0f;

        this.Deduct(this.damagePoison);
    }

    protected override void OnDead()
    {
        this.ChangeStatusObj();
        this.HandleCharDead();
    }

    protected virtual void ChangeStatusObj()
    {
        this.charCtrl.AnimatorManager.SetCurrentStatusId(CharacterStatusId.Death);
    }

    protected virtual void HandleCharDead()
    {
        //Time.timeScale = 0f;
        float timeFinishAnimation = this.charCtrl.AnimatorManager.GetTimeFinishCurrentAnimation();
        Invoke(nameof(EventDead), timeFinishAnimation);
    }

    protected virtual void EventDead()
    {
        Debug.Log("despawn character !!");

        UIloggerCtrl.Instance.gameObject.SetActive(true);
        UIloggerCtrl.Instance.PointText.ChangePointText(GameLevel.Instance.CurrTime.ToString());
    }

    protected override void EffectReceivingDamage()
    {
        this.charCtrl.AnimatorManager.SetPressingStatusId(CharacterStatusId.Fall);
        SliderHP.Instance.UpdateSliderHp(this.Hp, this.MaxHp);
        Invoke(nameof(this.ResetAnimation), this.charCtrl.AnimatorManager.GetTimeFinishCurrentAnimation());
    }

    protected override void EffectAddRecoveryHp()
    {
        SliderHP.Instance.UpdateSliderHp(this.Hp, this.MaxHp);
    }

    protected void ResetAnimation()
    {
        this.charCtrl.AnimatorManager.ResetPressingStatusId();
    }
}
