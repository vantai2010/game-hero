using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : Spawner
{
    private static EnemySpawner instance;
    protected static string enemyOne = "Enemy_1";
    protected static string enemyTwo = "Enemy_2";
    protected static string enemyThree = "Enemy_3";
    protected static string enemyFour = "Enemy_4";
    public static EnemySpawner Instance => instance;
    public static string EnemyOne => enemyOne;
    public static string EnemyTwo => enemyTwo;
    public static string EnemyThree => enemyThree;
    public static string EnemyFour => enemyFour;

    protected override void Awake()
    {
        base.Awake();
        if (EnemySpawner.instance != null) Debug.LogError("Only one EnemySpawner allow to exists");
        EnemySpawner.instance = this;   
    }

}
