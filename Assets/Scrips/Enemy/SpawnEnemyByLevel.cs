using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEnemyByLevel : CustomBehavior
{
    [Header("Spawn Enemy By Level")]
    [SerializeField] protected EnemySpawnPoint enemySpawnPoint;
    [SerializeField] protected EnemySpawner enemySpawner;
    [SerializeField] protected int spawnLimit;
    [SerializeField] protected float timer;
    [SerializeField] protected float timeLimit;
    [SerializeField] protected List<string> namePrefabList;
    protected int currentLevel;

    protected override void ResetValue()
    {
        base.ResetValue();
        this.spawnLimit = 5;
        this.timeLimit = 1f;
        this.timer = this.timeLimit;
        this.namePrefabList = new List<string> { EnemySpawner.EnemyOne, EnemySpawner.EnemyTwo, EnemySpawner.EnemyThree, EnemySpawner.EnemyFour };
    }
    protected override void LoadComponent()
    {
        base.LoadComponent();
        this.LoadEnemySpawnPoint();
        this.LoadEnemySpawner();
    }
    protected virtual void FixedUpdate()
    {
        this.GetCurrentLevel();
        this.UpdateParamsByLevel();
        this.SpawnByLevel();
    }
    protected virtual void LoadEnemySpawnPoint()
    {
        if (this.enemySpawnPoint != null) return;
        this.enemySpawnPoint = Transform.FindAnyObjectByType<EnemySpawnPoint>();
    }
    protected virtual void LoadEnemySpawner()
    {
        if (this.enemySpawner != null) return;
        this.enemySpawner = GetComponent<EnemySpawner>();
    }

    protected virtual void SpawnByLevel()
    {
        if (this.enemySpawner.SpawnedCount >= this.spawnLimit) return;

        this.timer += Time.fixedDeltaTime;
        if (this.timer < this.timeLimit) return;
        this.timer = 0f;

        Transform randomPoint = this.enemySpawnPoint.GetRandomPoint();
        Transform newEnemy = this.enemySpawner.SpawnRandomPrefab(randomPoint.position, randomPoint.rotation);
        newEnemy.gameObject.SetActive(true);
    }

    protected virtual void GetCurrentLevel()
    {
        this.currentLevel = GameLevel.Instance.CurrentLevel;
    }
    protected virtual void UpdateParamsByLevel()
    {
        
        this.spawnLimit = this.currentLevel + 5;
    }

    

    
}
