using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class FXSpawner : Spawner
{
    private static FXSpawner instance;
    protected static string muzzle = "Muzzle";
    protected static string impactFX = "ImpactFX";
    protected static string explosive = "Explosive";
    protected static string fallingMeteor = "FallingMeteor";
    protected static string smokeTrail = "SmokeTrail";
    protected static string poison = "Poison";
    protected static string floatingDamageText = "FloatingDamageText";
    public static FXSpawner Instance => instance;
    public static string Muzzle => muzzle;
    public static string ImpactFX => impactFX;
    public static string Explosive => explosive;
    public static string FallingMeteor => fallingMeteor;
    public static string SmokeTrail => smokeTrail;
    public static string Poison => poison;
    public static string FloatingDamageText => floatingDamageText;

    protected override void Awake()
    {
        base.Awake();
        if (FXSpawner.instance != null) Debug.LogError("Only one FXSpawner allow to exists");
        FXSpawner.instance = this;
    }
}
