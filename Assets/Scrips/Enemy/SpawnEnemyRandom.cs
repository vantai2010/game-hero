using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEnemyRandom : CustomBehavior
{
    [Header("Spawn Random")]
    [SerializeField] protected EnemySpawnPoint enemySpawnPoint;
    [SerializeField] protected EnemySpawner enemySpawner;
    [SerializeField] protected int spawnLimit;
    [SerializeField] protected float timer;
    [SerializeField] protected float timeLimit;

    protected override void ResetValue()
    {
        base.ResetValue();
        this.spawnLimit = 5;
        this.timeLimit = 1f;
        this.timer = this.timeLimit;
    }
    protected override void LoadComponent()
    {
        base.LoadComponent();
        this.LoadEnemySpawnPoint();
        this.LoadEnemySpawner();
    }
    protected virtual void FixedUpdate()
    {
        this.SpawnRandom();
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
    
    protected virtual void SpawnRandom()
    {
        if (this.enemySpawner.SpawnedCount >= this.spawnLimit) return;

        this.timer += Time.fixedDeltaTime;
        if (this.timer < this.timeLimit) return;
        this.timer = 0f;

        Transform randomPoint = this.enemySpawnPoint.GetRandomPoint();
        Transform newEnemy = this.enemySpawner.SpawnRandomPrefab(randomPoint.position, randomPoint.rotation);
        newEnemy.gameObject.SetActive(true);
    }
}
