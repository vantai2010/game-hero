using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GenerateItem : CustomBehavior
{
    [Header("Generate Item")]
    [SerializeField] protected List<Transform> listSpawnPoints;
    [SerializeField] protected int idSelectedPoint = -1;

    protected override void LoadComponent()
    {
        base.LoadComponent();
        this.LoadListSpawnPoints();
    }

    protected virtual void LoadListSpawnPoints()
    {
        if (this.listSpawnPoints.Count > 0) return;
        Transform listRocks = GameObject.Find("Rock").transform;
        foreach(Transform rock in listRocks)
        {
            this.listSpawnPoints.Add(rock);
        }
    }

    protected virtual void FixedUpdate()
    {
        this.Generate();
    }

    protected virtual void SpawnItem(Vector3 posSpawn, Quaternion rotSpawn)
    {
        Transform newItem = ItemSpawner.Instance.Spawn(ItemSpawner.Medkit, posSpawn, rotSpawn);
        newItem.gameObject.SetActive(true);
    }

    protected virtual Transform GetRandomSpawnPoint()
    {
        if (this.listSpawnPoints.Count == 1)
        {
            return this.listSpawnPoints[0];
        }

        int index;

        do
        {
            index = Random.Range(0, this.listSpawnPoints.Count);
        } while (index == this.idSelectedPoint); 

        this.idSelectedPoint = index;

        return this.listSpawnPoints[index];
    }

    protected virtual void Generate()
    {
        if (ItemSpawner.Instance.SpawnedCount > 0) return;

        Transform spawnPoint = this.GetRandomSpawnPoint();
        this.SpawnItem(spawnPoint.position + new Vector3(0, 0.3f, 0), Quaternion.identity);
    }
}
