using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SummonMeteor : BaseAbility
{
    [Header("Summon Meteor")]
    [SerializeField] protected List<Transform> listStartFallPoints;
    [SerializeField] protected List<Transform> listEndFallPoints;
    protected List<ISummonMeteorSkillObserver> summonMeteorSkillObservers = new List<ISummonMeteorSkillObserver>();
    protected override void ResetValue()
    {
        base.ResetValue();
        this.delay = 15f;
    }
    protected override void LoadComponent()
    {
        base.LoadComponent();
        this.LoadListEndPoints();
        this.LoadListStartPoints();
    }
    protected override void FixedUpdate()
    {
        base.FixedUpdate();
        this.Summoning();
    }
    protected virtual void LoadListEndPoints()
    {
        if (this.listEndFallPoints.Count > 0) return;
        Transform endFallSpawnPoint = transform.Find("EndFallSpawnPoint");
        foreach (Transform point in endFallSpawnPoint)
        {
            this.listEndFallPoints.Add(point);
        }
    }
    protected virtual void LoadListStartPoints()
    {
        if (this.listStartFallPoints.Count > 0) return;
        Transform startFallSpawnPoint = transform.Find("StartFallSpawnPoint");
        foreach (Transform point in startFallSpawnPoint)
        {
            this.listStartFallPoints.Add(point);
        }
    }

    public void AddObserver(ISummonMeteorSkillObserver observer)
    {
        this.summonMeteorSkillObservers.Add(observer);
    }

    protected void HandleObserversStart()
    {
        foreach(ISummonMeteorSkillObserver observer in this.summonMeteorSkillObservers)
        {
            observer.OnSummonMeteorSkillStart();
        }
    }
    protected void HandleObserversEnd()
    {
        foreach (ISummonMeteorSkillObserver observer in this.summonMeteorSkillObservers)
        {
            observer.OnSummonMeteorSkillEnd();
        }
    }

    protected void Summoning()
    {
        if (!this.isReady) return;

        this.HandleObserversStart();
        this.abilityCtrl.AbilityObjectCtrl.AnimatorManager.SetCurrentStatusId(CharacterStatusId.Hit);

        for (int i = 0; i < this.listStartFallPoints.Count; i++)
        {
            Transform startPoint = this.listStartFallPoints[i];
            Transform newMeteor = FXSpawner.Instance.Spawn(FXSpawner.FallingMeteor, startPoint.position, startPoint.rotation);
            FollowTarget meteorFollowTarget = newMeteor.GetComponent<FallingMeteorCtrl>().FollowTarget;
            if (meteorFollowTarget == null) return;

            meteorFollowTarget.SetTarget(this.listEndFallPoints[i]);
            newMeteor.gameObject.SetActive(true);
        }
        this.Active();

        Invoke(nameof(this.HandleObserversEnd), 4f);
    }
}
