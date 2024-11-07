using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletSpawner : Spawner
{
    private static BulletSpawner instance;
    public static BulletSpawner Instance => instance;
    protected static string bulletOne = "Bullet_1";
    protected static string fireball = "Fireball";
    protected static string poisonBullet = "PoisonBullet";
    public static string BulletOne => bulletOne;
    public static string Fireball => fireball;
    public static string PoisonBullet => poisonBullet;
    protected override void Awake()
    {
        base.Awake();
        if (BulletSpawner.instance != null) Debug.LogError("Only one BulletSpawner allow to exists");
        BulletSpawner.instance = this;
    }

}
