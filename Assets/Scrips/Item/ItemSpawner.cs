using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemSpawner : Spawner
{
    private static ItemSpawner instance;
    protected static string medkit = "Medkit";
    public static ItemSpawner Instance => instance;
    public static string Medkit => medkit;

    protected override void Awake()
    {
        base.Awake();
        if (ItemSpawner.instance != null) Debug.LogError("Only one ItemSpawner allow to exists");
        ItemSpawner.instance = this;
    }
}
