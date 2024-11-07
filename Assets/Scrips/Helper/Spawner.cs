using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.Tracing;
using UnityEngine;

public abstract class Spawner : CustomBehavior
{
    [Header("Spawner")]
    [SerializeField] protected List<Transform> listPrefabs;
    [SerializeField] protected List<Transform> listPoolObjs;
    [SerializeField] protected Transform holder;
    [SerializeField] protected int spawnedCount;
    public int SpawnedCount => spawnedCount;

    protected override void LoadComponent()
    {
        base.LoadComponent();
        this.LoadPrefabs();
        this.LoadHolder();
    }
    protected virtual void LoadHolder()
    {
        if (this.holder != null) return;
        this.holder = transform.Find("Holder");
    }
    protected virtual void LoadPrefabs()
    {
        if (this.listPrefabs.Count > 0) return;
        Transform prefabs = transform.Find("Prefabs");

        foreach(Transform prefab in prefabs)
        {
            prefab.gameObject.SetActive(false);
            this.listPrefabs.Add(prefab);
        }
    }

    public virtual Transform Spawn(string namePrefab, Vector3 spawnPos, Quaternion spawnRot)
    {
        Transform prefab = this.GetPrefabsByName(namePrefab);
        if (prefab == null)
        {
            Debug.LogWarning("Prefab " + namePrefab + " not found");
            return null;
        }
        return this.Spawn(prefab, spawnPos, spawnRot);
    }

    public virtual Transform SpawnRandomPrefab(Vector3 spawnPos, Quaternion spawnRot)
    {
        int randomIndex = Random.Range(0, this.listPrefabs.Count);
        Transform prefab = this.listPrefabs[randomIndex];
        return this.Spawn(prefab, spawnPos, spawnRot);
    }

    public virtual Transform Spawn(Transform prefab, Vector3 spawnPos, Quaternion spawnRot)
    {
        Transform newPrefab = this.GetObjectFromPool(prefab);
        newPrefab.SetPositionAndRotation(spawnPos, spawnRot);
        newPrefab.SetParent(this.holder);
        this.spawnedCount += 1;
        return newPrefab;
    }
    public virtual Transform GetPrefabsByName(string namePrefab)
    {
        foreach(Transform prefab in this.listPrefabs)
        {
            if(prefab.name == namePrefab) return prefab;
        }
        return null;
    }
    public virtual Transform GetRandomPrefab()
    {
        int random = Random.Range(0, this.listPrefabs.Count);
        return this.listPrefabs[random];
    }
    protected virtual Transform GetObjectFromPool(Transform prefab)
    {
        foreach (Transform poolObj in this.listPoolObjs)
        {
            if (poolObj.name == prefab.name)
            {
                this.listPoolObjs.Remove(poolObj);
                return poolObj;
            }
        }

        Transform newPrefab = Instantiate(prefab);
        newPrefab.name = prefab.name;
        return newPrefab;
    }
    public virtual void Despawn(Transform obj)
    {
        if (this.listPoolObjs.Contains(obj)) return;

        this.listPoolObjs.Add(obj);
        obj.gameObject.SetActive(false);
        this.spawnedCount -= 1;
    }
}
