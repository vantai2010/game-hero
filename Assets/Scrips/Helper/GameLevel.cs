using System.Collections;
using System.Collections.Generic;
using System.Security.Authentication.ExtendedProtection;
using UnityEngine;

public class GameLevel : CustomBehavior
{
    [Header("Game level")]
    private static GameLevel _instance;
    [SerializeField] protected int currentLevel;
    [SerializeField] protected int currTime;
    [SerializeField] protected int timeToLevelUp;
    protected int timer;

    public static GameLevel Instance => _instance;
    public int CurrTime => currTime;
    public int CurrentLevel => currentLevel;
    protected override void LoadComponent()
    {
        base.LoadComponent();
    }
    protected override void ResetValue()
    {
        base.ResetValue();
        this.timer = 0;
        this.currentLevel = 1;
        this.currTime = 0;
        this.timeToLevelUp = 10;
    }
    protected override void Awake()
    {
        base.Awake();
        if (GameLevel._instance != null) Debug.LogError("Only One GameLevel allow to exists");
        GameLevel._instance = this;
    }
    
    protected virtual void Start()
    {
        InvokeRepeating(nameof(this.UpdateLevel), 1f, 1f);
    }

    protected virtual void UpdateLevel()
    {
        this.currTime += 1;
        this.timer += 1;
        if(this.timer == this.timeToLevelUp)
        {
            this.timer = 0;
            this.currentLevel += 1;
        }
    }

}
